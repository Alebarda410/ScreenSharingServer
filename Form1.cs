using Server.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        private Telepathy.Server _server;

        private Thread _broadcastThread;

        private PerformanceCounter _cpuUsing;

        private readonly Image _bitmapPointer = Resources.pointer;

        private Bitmap _screenBitmap, _sendBitmap;

        private Screen _curScreen;

        private Rectangle _windowSize;
        private DateTime _time;


        private int _port, _maxCon, _countCurrentCon, _sleepTime;
        private bool _pause = true;
        private bool _waitOffOn, _imgResize;

        private readonly ManualResetEvent _mre = new(true);

        private ToolStripMenuItem _waitBtn, _stopBtn, _pauseBtn;

        private readonly List<int> _currentConnection = new();
        private readonly List<int> _waitConnection = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void WaitOffOn_Click(object sender, EventArgs e)
        {
            if (_waitOffOn)
            {
                _waitBtn.Text = @"Выкл ожидание";
                WaitOffOn.Text = @"Выкл ожидание";
                _waitOffOn = false;
            }
            else
            {
                _waitBtn.Text = @"Вкл ожидание";
                WaitOffOn.Text = @"Вкл ожидание";
                AccessAll();
                _waitOffOn = true;
            }
        }

        private void AccessAllBtn_Click(object sender, EventArgs e)
        {
            AccessAll();
        }

        private void AccessAll()
        {
            if (_waitConnection.Count == 0) return;

            _currentConnection.AddRange(_waitConnection);
            CurrentListBox.Items.AddRange(WaitListBox.Items);

            _waitConnection.Clear();
            WaitListBox.Items.Clear();

            WaitListCount.Text = $@"{_waitConnection.Count}";
            CurrentListCount.Text = $@"{_currentConnection.Count}";

            foreach (var tempItem in CurrentListBox.Items)
            {
                AddLog($"Запрос {tempItem} на добавление одобрен");
            }
        }

        private void Con(int id)
        {
            Invoke(new Action(() =>
            {
                _countCurrentCon++;
                if (_countCurrentCon > _maxCon)
                {
                    _server.Disconnect(id);
                }
            }));
        }

        private void Dis(int id)
        {
            _countCurrentCon--;

            if (_currentConnection.Contains(id))
            {
                var tempId = _currentConnection.IndexOf(id);

                AddLog($"Соединение с {CurrentListBox.Items[tempId]} потеряно");

                CurrentListBox.Items.RemoveAt(tempId);
                _currentConnection.RemoveAt(tempId);

                CurrentListCount.Text = $@"{_currentConnection.Count}";
            }
            else if (_waitConnection.Contains(id))
            {
                var tempId = _waitConnection.IndexOf(id);

                AddLog($"Соединение с {WaitListBox.Items[tempId]} потеряно");

                WaitListBox.Items.RemoveAt(tempId);
                _waitConnection.RemoveAt(tempId);

                WaitListCount.Text = $@"{_waitConnection.Count}";
            }
        }

        private void Dat(int id, ArraySegment<byte> msg)
        {
            var tempName = Encoding.UTF8.GetString(msg);

            if (_waitOffOn)
            {
                AddLog($"Запрос {tempName} на добавление одобрен");

                CurrentListBox.Items.Add(tempName);
                _currentConnection.Add(id);

                CurrentListCount.Text = $@"{_currentConnection.Count}";
            }
            else
            {
                AddLog($"{tempName} находится в зале ожидания");

                WaitListBox.Items.Add(tempName);
                _waitConnection.Add(id);

                WaitListCount.Text = $@"{_waitConnection.Count}";
            }
        }

        public void Broadcast()
        {
            try
            {
                Task taskSend = Task.Run(() => true);
                while (true)
                {
                    _mre.WaitOne();
                    var crs = Cursor.Position;
                    crs.X -= _windowSize.Left;
                    crs.Y -= _windowSize.Top;
                    var paramImg = (Bitmap)_screenBitmap.Clone();
                    Parallel.Invoke(() => ImageResize(paramImg),
                        () =>
                        {
                            using var g = Graphics.FromImage(_screenBitmap);
                            g.CopyFromScreen(_windowSize.Left, _windowSize.Top,
                                0, 0, _windowSize.Size);
                            g.DrawImage(_bitmapPointer, crs.X, crs.Y);
                        });
                    taskSend.Wait();
                    taskSend = Task.Run(ImageSend);
                    if (_sleepTime != 0) Thread.Sleep(_sleepTime);
                }
            }
            catch (Exception) {/**/}
        }

        public void ImageResize(Bitmap img)
        {
            if (_imgResize)
            {
                _sendBitmap = new Bitmap(img,
                    (int)(_curScreen.Bounds.Width / 1.41),
                    (int)(_curScreen.Bounds.Height / 1.41));
            }
            else
            {
                _sendBitmap = img;
            }
        }

        public void ImageSend()
        {
            MemoryStream memoryStream;
            //_imgSendStopwatch.Restart();
            using (memoryStream = new MemoryStream())
            {
                _sendBitmap.Save(memoryStream, ImageFormat.Jpeg);
            }
            var btBuf = new ArraySegment<byte>(memoryStream.GetBuffer());

            Parallel.ForEach(_currentConnection, (par) =>
            {
                _server.Send(par, btBuf);
            });
        }

        private void SaveLogs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            var substitution = $"{DateTime.Now.Date}".Split()[0];
            const string pattern = @"(?=([^\\\\]){1,}$)";
            var input = saveFileDialog1.FileName;

            var regex = new Regex(pattern);
            var filename = regex.Replace(input, $"{substitution} - ", 1);

            File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show(@"Журнал сохранен");
        }

        private void ClearLogs_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            for (var i = WaitListBox.SelectedIndices.Count - 1; i >= 0; i--)
            {
                var index = WaitListBox.SelectedIndices[i];
                AddLog($"Запрос {WaitListBox.Items[index]} на добавление одобрен");
                _currentConnection.Add(_waitConnection[index]);
                CurrentListBox.Items.Add(WaitListBox.Items[index]);
                _waitConnection[index] = -1;
                WaitListBox.Items.RemoveAt(index);
            }
            _waitConnection.RemoveAll(x => x == -1);
            WaitListCount.Text = $@"{_waitConnection.Count}";
            CurrentListCount.Text = $@"{_currentConnection.Count}";
            AddButton.Enabled = false;
            NoAddButton.Enabled = false;
        }
        private void NoAddButton_Click(object sender, EventArgs e)
        {
            for (var i = WaitListBox.SelectedIndices.Count - 1; i >= 0; i--)
            {
                var index = WaitListBox.SelectedIndices[i];
                _server.Disconnect(_waitConnection[index]);
                AddLog($"Запрос {WaitListBox.Items[index]} на добавление отклонен");
                _waitConnection[index] = -1;
                WaitListBox.Items.RemoveAt(index);
            }
            _waitConnection.RemoveAll(x => x == -1);
            WaitListCount.Text = $@"{_waitConnection.Count}";
            AddButton.Enabled = false;
            NoAddButton.Enabled = false;
        }

        private void KickButton_Click(object sender, EventArgs e)
        {
            for (var i = CurrentListBox.SelectedIndices.Count - 1; i >= 0; i--)
            {
                var index = CurrentListBox.SelectedIndices[i];
                _server.Disconnect(_currentConnection[index]);
                AddLog($"Запрос {CurrentListBox.Items[index]} на добавление отклонен");
                _currentConnection[index] = -1;
                CurrentListBox.Items.RemoveAt(index);
            }
            _currentConnection.RemoveAll(x => x == -1);
            CurrentListCount.Text = $@"{_currentConnection.Count}";
            KickButton.Enabled = false;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!IsCorrect(MaxConBox.Text, out _maxCon, 1))
            {
                MessageBox.Show(@"Кол-во клиентов должно быть положительным числом больше одного!",
                    @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsCorrect(PortBox.Text, out _port, 10000, 60000))
            {
                MessageBox.Show(@"Номер порта должен находиться между 10000 и 60000!",
                    @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_server.Start(_port)) AddLog("Трансляция запущена");
            else
            {
                MessageBox.Show(@"Не удалось запустить трансляцию, смените порт и повторите попытку!",
                    @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            StartButton.Enabled = false;
            _pauseBtn.Enabled = true;
            _stopBtn.Enabled = true;
            PauseButton.Enabled = true;
            StopButton.Enabled = true;
            ScreenComBox.Enabled = false;
            MaxConBox.Enabled = false;
            PortBox.Enabled = false;
            timer1.Start();
            _windowSize = _curScreen.Bounds;
            _screenBitmap = new Bitmap(_windowSize.Width, _windowSize.Height);
            _broadcastThread = new Thread(Broadcast)
            {
                IsBackground = true,
                Priority = ThreadPriority.Highest
            };
            _broadcastThread.Start();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (_pause)
            {
                _mre.Reset();
                _pause = false;
                ScreenComBox.Enabled = true;
                MaxConBox.Enabled = true;
                PauseButton.Text = @"Возобновить";
                _pauseBtn.Text = @"Возобновить";
                AddLog("Трансляция поставлена на паузу");
            }
            else
            {
                if (!IsCorrect(MaxConBox.Text, out _maxCon, 1))
                {
                    MessageBox.Show(@"Кол-во клиентов должно быть положительным числом больше одного!",
                        @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_maxCon < _countCurrentCon)
                {
                    MessageBox.Show(@"Новое колво клиентов должно быть больше или равно текущему количеству подключений!",
                        @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _windowSize = _curScreen.Bounds;
                _screenBitmap = new Bitmap(_windowSize.Width, _windowSize.Height);
                _mre.Set();
                _pause = true;
                ScreenComBox.Enabled = false;
                MaxConBox.Enabled = false;
                PauseButton.Text = @"Пауза";
                _pauseBtn.Text = @"Пауза";
                AddLog("Трансляция возоблена");
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            StopButton.Enabled = false;
            _pauseBtn.Enabled = false;
            _stopBtn.Enabled = false;
            PauseButton.Enabled = false;
            StartButton.Enabled = true;
            KickButton.Enabled = false;
            AddButton.Enabled = false;
            NoAddButton.Enabled = false;
            ScreenComBox.Enabled = true;
            MaxConBox.Enabled = true;
            PortBox.Enabled = true;

            _server.Stop();
            timer1.Stop();

            CurrentListBox.Items.Clear();
            WaitListBox.Items.Clear();
            _currentConnection.Clear();
            _waitConnection.Clear();

            WaitListCount.Text = $@"{_waitConnection.Count}";
            CurrentListCount.Text = $@"{_currentConnection.Count}";
            PauseButton.Text = @"Пауза";

            if (!_pause)
            {
                _mre.Set();
                _pause = true;
            }
            _broadcastThread.Interrupt();
            AddLog("Трансляция окончена");
            Thread.Sleep(1000);

            WindowState = FormWindowState.Normal;
        }

        public static string LtS(long l)
        {
            return $"{l}";
        }

        private void Init()
        {
            var contextMenu1 = new ContextMenuStrip();
            _waitBtn = new ToolStripMenuItem();
            _pauseBtn = new ToolStripMenuItem();
            var accessAllBtn = new ToolStripMenuItem();
            _stopBtn = new ToolStripMenuItem();
            contextMenu1.Items.AddRange(new ToolStripItem[] { _waitBtn, _pauseBtn, accessAllBtn, _stopBtn });

            _waitBtn.Text = @"Выкл ожидание";
            _pauseBtn.Text = @"Пауза";
            accessAllBtn.Text = @"Разрешить доступ";
            _stopBtn.Text = @"Закончить трансляцию";

            _stopBtn.Enabled = false;
            _pauseBtn.Enabled = false;

            _waitBtn.Click += WaitOffOn_Click;
            accessAllBtn.Click += AccessAllBtn_Click;
            _stopBtn.Click += StopButton_Click;
            _pauseBtn.Click += PauseButton_Click;

            notifyIcon1.ContextMenuStrip = contextMenu1;

            _cpuUsing = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            _server = new Telepathy.Server(512 * 1024)
            {
                OnConnected = Con,
                OnData = Dat,
                OnDisconnected = Dis
            };
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            Init();
            GetLocalAddress();
            if (Screen.AllScreens.Length == 1)
            {
                ScreenComBox.Visible = false;
                toolStripSeparator1.Visible = false;
                toolStripLabel1.Visible = false;
                _curScreen = Screen.AllScreens[0];
                return;
            }
            foreach (var t in Screen.AllScreens)
                ScreenComBox.Items.Add(t.DeviceName);
            ScreenComBox.SelectedIndex = 0;
            AddLog($"Текущий монитор {Screen.FromControl(this).DeviceName}");
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                AddLog("В свернутом режиме доступно управление через значек уведомлений!");
            }
            else if (WindowState == FormWindowState.Normal)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void WaitListBox_Click(object sender, EventArgs e)
        {
            if (WaitListBox.SelectedItem == null) return;

            AddButton.Enabled = true;
            NoAddButton.Enabled = true;
            KickButton.Enabled = false;
        }

        private void CurrentListBox_Click(object sender, EventArgs e)
        {
            if (CurrentListBox.SelectedItem == null) return;

            AddButton.Enabled = false;
            NoAddButton.Enabled = false;
            KickButton.Enabled = true;
        }

        private void ScreenComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _curScreen = Screen.AllScreens[ScreenComBox.SelectedIndex];
        }

        private static int Map(int value, int fromLow, int fromHigh, int toLow, int toHigh)
        {
            return ((toHigh - toLow) / (fromHigh - fromLow)) * (value - fromLow) + toLow;
        }
        private void Balanced(int cpuAvg)
        {
            try
            {
                _sleepTime = cpuAvg >= 85 ? 
                    Map(cpuAvg, 85, 100, 10, 100) :
                    0;
            }
            catch (UnauthorizedAccessException)
            {
                AddLog("Запустите программу с правами администратора для избежания проблем с производительностью!");
            }
        }

        private readonly List<float> _cpuUseList = new();
        private void timer1_Tick(object sender, EventArgs e)
        {
            _server.Tick(30);
            _cpuUseList.Add(_cpuUsing.NextValue());
            if (_cpuUseList.Count > 10)
            {
                _cpuUseList.RemoveAt(0);
            }
            Balanced((int)_cpuUseList.Average());
            GC.Collect();
        }

        private void ImgResize_Click(object sender, EventArgs e)
        {            ImgResize.Checked = !_imgResize;
            _imgResize = ImgResize.Checked;
        }

        public static bool IsCorrect(string arg, out int numb, int lf = 0, int rt = int.MaxValue - 1)
        {
            if (!int.TryParse(arg, out numb)) return false;
            return numb >= lf && numb <= rt;
        }

        public void AddLog(string str)
        {
            _time = DateTime.Now;
            richTextBox1.AppendText($"[{_time.Hour}:{_time.Minute}:{_time.Second}] {str}\n");
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.BalloonTipText = str;
                notifyIcon1.BalloonTipTitle = @"Уведомление";
                notifyIcon1.ShowBalloonTip(1000);
            }
        }

        public void GetLocalAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                AddLog("Сеть не обнаружена!");

            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    AddLog($"Адрес для подключения со сторонних устройств  - {ip}");
        }
    }
}
