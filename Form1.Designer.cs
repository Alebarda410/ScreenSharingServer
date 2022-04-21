
namespace Server
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.StartButton = new System.Windows.Forms.ToolStripButton();
            this.StopButton = new System.Windows.Forms.ToolStripButton();
            this.PauseButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ScreenComBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.PortBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.MaxConBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.WaitOffOn = new System.Windows.Forms.ToolStripButton();
            this.ImgResize = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WaitListBox = new System.Windows.Forms.ListBox();
            this.CurrentListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveLogs = new System.Windows.Forms.Button();
            this.ClearLogs = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.KickButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.NoAddButton = new System.Windows.Forms.Button();
            this.WaitListCount = new System.Windows.Forms.Label();
            this.CurrentListCount = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartButton,
            this.StopButton,
            this.PauseButton,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.ScreenComBox,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.PortBox,
            this.toolStripSeparator3,
            this.toolStripLabel3,
            this.MaxConBox,
            this.toolStripSeparator4,
            this.WaitOffOn,
            this.ImgResize});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1095, 29);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // StartButton
            // 
            this.StartButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StartButton.Image = ((System.Drawing.Image)(resources.GetObject("StartButton.Image")));
            this.StartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(55, 26);
            this.StartButton.Text = "Старт";
            this.StartButton.ToolTipText = "Нажмите на эту кнопку чтобы начать трансляцию";
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StopButton.Enabled = false;
            this.StopButton.Image = ((System.Drawing.Image)(resources.GetObject("StopButton.Image")));
            this.StopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(49, 26);
            this.StopButton.Text = "Стоп";
            this.StopButton.ToolTipText = "Нажмите на эту кнопку чтобы заончить трансляцию";
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PauseButton.Enabled = false;
            this.PauseButton.Image = ((System.Drawing.Image)(resources.GetObject("PauseButton.Image")));
            this.PauseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(56, 26);
            this.PauseButton.Text = "Пауза";
            this.PauseButton.ToolTipText = "Нажмите на эту кнопку чтобы приотонавить/возобновить трансляцию";
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(76, 26);
            this.toolStripLabel1.Text = "Монитор";
            // 
            // ScreenComBox
            // 
            this.ScreenComBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ScreenComBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ScreenComBox.Name = "ScreenComBox";
            this.ScreenComBox.Size = new System.Drawing.Size(121, 29);
            this.ScreenComBox.SelectedIndexChanged += new System.EventHandler(this.ScreenComBox_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(46, 26);
            this.toolStripLabel2.Text = "Порт";
            // 
            // PortBox
            // 
            this.PortBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(100, 29);
            this.PortBox.Text = "12345";
            this.PortBox.ToolTipText = "Порт старта трансляции";
            this.PortBox.TextChanged += new System.EventHandler(this.PortBox_TextChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(129, 26);
            this.toolStripLabel3.Text = "Кол-во клиентов";
            // 
            // MaxConBox
            // 
            this.MaxConBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaxConBox.Name = "MaxConBox";
            this.MaxConBox.Size = new System.Drawing.Size(100, 29);
            this.MaxConBox.Text = "30";
            this.MaxConBox.ToolTipText = "Максимальное количество подключений которое будет потдерживать приложение";
            this.MaxConBox.TextChanged += new System.EventHandler(this.MaxConBox_TextChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 29);
            // 
            // WaitOffOn
            // 
            this.WaitOffOn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.WaitOffOn.Image = ((System.Drawing.Image)(resources.GetObject("WaitOffOn.Image")));
            this.WaitOffOn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.WaitOffOn.Name = "WaitOffOn";
            this.WaitOffOn.Size = new System.Drawing.Size(127, 26);
            this.WaitOffOn.Text = "Выкл ожидание";
            this.WaitOffOn.ToolTipText = "Запустить всех из списка ожидания и отключить зал ожидания";
            this.WaitOffOn.Click += new System.EventHandler(this.WaitOffOn_Click);
            // 
            // ImgResize
            // 
            this.ImgResize.BackColor = System.Drawing.SystemColors.Control;
            this.ImgResize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ImgResize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ImgResize.Name = "ImgResize";
            this.ImgResize.Size = new System.Drawing.Size(151, 26);
            this.ImgResize.Text = "Экономия трафика";
            this.ImgResize.Click += new System.EventHandler(this.ImgResize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Журнал трансляции";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox1.Location = new System.Drawing.Point(12, 58);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(560, 382);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(578, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Список ожидающих";
            // 
            // WaitListBox
            // 
            this.WaitListBox.FormattingEnabled = true;
            this.WaitListBox.ItemHeight = 21;
            this.WaitListBox.Location = new System.Drawing.Point(578, 58);
            this.WaitListBox.Name = "WaitListBox";
            this.WaitListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.WaitListBox.Size = new System.Drawing.Size(250, 382);
            this.WaitListBox.TabIndex = 4;
            this.WaitListBox.Click += new System.EventHandler(this.WaitListBox_Click);
            // 
            // CurrentListBox
            // 
            this.CurrentListBox.FormattingEnabled = true;
            this.CurrentListBox.ItemHeight = 21;
            this.CurrentListBox.Location = new System.Drawing.Point(834, 58);
            this.CurrentListBox.Name = "CurrentListBox";
            this.CurrentListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.CurrentListBox.Size = new System.Drawing.Size(250, 382);
            this.CurrentListBox.TabIndex = 5;
            this.CurrentListBox.Click += new System.EventHandler(this.CurrentListBox_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(834, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Подключенные";
            // 
            // SaveLogs
            // 
            this.SaveLogs.Location = new System.Drawing.Point(12, 446);
            this.SaveLogs.Name = "SaveLogs";
            this.SaveLogs.Size = new System.Drawing.Size(278, 35);
            this.SaveLogs.TabIndex = 7;
            this.SaveLogs.Text = "Сохранить журнал";
            this.SaveLogs.UseVisualStyleBackColor = true;
            this.SaveLogs.Click += new System.EventHandler(this.SaveLogs_Click);
            // 
            // ClearLogs
            // 
            this.ClearLogs.Location = new System.Drawing.Point(294, 446);
            this.ClearLogs.Name = "ClearLogs";
            this.ClearLogs.Size = new System.Drawing.Size(278, 35);
            this.ClearLogs.TabIndex = 8;
            this.ClearLogs.Text = "Очистить журнал";
            this.ClearLogs.UseVisualStyleBackColor = true;
            this.ClearLogs.Click += new System.EventHandler(this.ClearLogs_Click);
            // 
            // AddButton
            // 
            this.AddButton.Enabled = false;
            this.AddButton.Location = new System.Drawing.Point(578, 446);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(165, 35);
            this.AddButton.TabIndex = 9;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // KickButton
            // 
            this.KickButton.Enabled = false;
            this.KickButton.Location = new System.Drawing.Point(919, 446);
            this.KickButton.Name = "KickButton";
            this.KickButton.Size = new System.Drawing.Size(165, 35);
            this.KickButton.TabIndex = 11;
            this.KickButton.Text = "Исключить";
            this.KickButton.UseVisualStyleBackColor = true;
            this.KickButton.Click += new System.EventHandler(this.KickButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.FileName = "logs";
            this.saveFileDialog1.Title = "Сохранение журнала";
            // 
            // NoAddButton
            // 
            this.NoAddButton.Enabled = false;
            this.NoAddButton.Location = new System.Drawing.Point(749, 446);
            this.NoAddButton.Name = "NoAddButton";
            this.NoAddButton.Size = new System.Drawing.Size(165, 35);
            this.NoAddButton.TabIndex = 12;
            this.NoAddButton.Text = "Отклонить";
            this.NoAddButton.UseVisualStyleBackColor = true;
            this.NoAddButton.Click += new System.EventHandler(this.NoAddButton_Click);
            // 
            // WaitListCount
            // 
            this.WaitListCount.AutoSize = true;
            this.WaitListCount.Location = new System.Drawing.Point(809, 35);
            this.WaitListCount.Name = "WaitListCount";
            this.WaitListCount.Size = new System.Drawing.Size(19, 21);
            this.WaitListCount.TabIndex = 13;
            this.WaitListCount.Text = "0";
            // 
            // CurrentListCount
            // 
            this.CurrentListCount.AutoSize = true;
            this.CurrentListCount.Location = new System.Drawing.Point(1063, 35);
            this.CurrentListCount.Name = "CurrentListCount";
            this.CurrentListCount.Size = new System.Drawing.Size(19, 21);
            this.CurrentListCount.TabIndex = 14;
            this.CurrentListCount.Text = "0";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Server";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 497);
            this.Controls.Add(this.CurrentListCount);
            this.Controls.Add(this.WaitListCount);
            this.Controls.Add(this.NoAddButton);
            this.Controls.Add(this.KickButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ClearLogs);
            this.Controls.Add(this.SaveLogs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CurrentListBox);
            this.Controls.Add(this.WaitListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 526);
            this.Name = "Form1";
            this.Text = "Server";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton StartButton;
        private System.Windows.Forms.ToolStripButton StopButton;
        private System.Windows.Forms.ToolStripButton PauseButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox ScreenComBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox PortBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox MaxConBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox WaitListBox;
        private System.Windows.Forms.ListBox CurrentListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveLogs;
        private System.Windows.Forms.Button ClearLogs;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button NoAddButton;
        private System.Windows.Forms.Button KickButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label WaitListCount;
        private System.Windows.Forms.Label CurrentListCount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton WaitOffOn;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripButton ImgResize;
    }
}

