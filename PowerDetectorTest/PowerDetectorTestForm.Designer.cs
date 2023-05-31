namespace PowerDetectorTest
{
    partial class PowerDetectorTestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.ConnectOscBtn = new System.Windows.Forms.Button();
            this.ConnectRFBtn = new System.Windows.Forms.Button();
            this.OscInstrumentList = new System.Windows.Forms.ComboBox();
            this.ConnectWGBtn = new System.Windows.Forms.Button();
            this.RFInstrumentList = new System.Windows.Forms.ComboBox();
            this.label41 = new System.Windows.Forms.Label();
            this.WGInstrumentList = new System.Windows.Forms.ComboBox();
            this.RefreshListBtn = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.SaveImgBtn = new System.Windows.Forms.Button();
            this.BrowseImgPathBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ImgPathBox = new System.Windows.Forms.TextBox();
            this.TurnAMOnOffBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.BrowseSaveFileBtn = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.FileNameBox = new System.Windows.Forms.TextBox();
            this.StartLabel = new System.Windows.Forms.Label();
            this.StopLabel = new System.Windows.Forms.Label();
            this.StepLabel = new System.Windows.Forms.Label();
            this.StepBox = new System.Windows.Forms.TextBox();
            this.StopBox = new System.Windows.Forms.TextBox();
            this.TurnOnRFBtn = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.ApplyRFBtn = new System.Windows.Forms.Button();
            this.CWFreqBox = new System.Windows.Forms.TextBox();
            this.StartBox = new System.Windows.Forms.TextBox();
            this.SetRFPowerBox = new System.Windows.Forms.Label();
            this.FFTPeakBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.StepFreqBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.StopFreqBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.StartFreqBox = new System.Windows.Forms.TextBox();
            this.ApplyWGbtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TurnOnWGBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.VoltageBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.groupBox17.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.label43);
            this.groupBox17.Controls.Add(this.label42);
            this.groupBox17.Controls.Add(this.ConnectOscBtn);
            this.groupBox17.Controls.Add(this.ConnectRFBtn);
            this.groupBox17.Controls.Add(this.OscInstrumentList);
            this.groupBox17.Controls.Add(this.ConnectWGBtn);
            this.groupBox17.Controls.Add(this.RFInstrumentList);
            this.groupBox17.Controls.Add(this.label41);
            this.groupBox17.Controls.Add(this.WGInstrumentList);
            this.groupBox17.Controls.Add(this.RefreshListBtn);
            this.groupBox17.Location = new System.Drawing.Point(12, 12);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(293, 141);
            this.groupBox17.TabIndex = 18;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "GPIB setup";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(1, 116);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(67, 13);
            this.label43.TabIndex = 26;
            this.label43.Text = "Oscilloscope";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(6, 89);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(56, 13);
            this.label42.TabIndex = 25;
            this.label42.Text = "RF source";
            // 
            // ConnectOscBtn
            // 
            this.ConnectOscBtn.Location = new System.Drawing.Point(210, 111);
            this.ConnectOscBtn.Name = "ConnectOscBtn";
            this.ConnectOscBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectOscBtn.TabIndex = 2;
            this.ConnectOscBtn.Text = "Connect";
            this.ConnectOscBtn.UseVisualStyleBackColor = true;
            this.ConnectOscBtn.Click += new System.EventHandler(this.ConnectOscBtn_Click);
            // 
            // ConnectRFBtn
            // 
            this.ConnectRFBtn.Location = new System.Drawing.Point(210, 84);
            this.ConnectRFBtn.Name = "ConnectRFBtn";
            this.ConnectRFBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectRFBtn.TabIndex = 2;
            this.ConnectRFBtn.Text = "Connect";
            this.ConnectRFBtn.UseVisualStyleBackColor = true;
            this.ConnectRFBtn.Click += new System.EventHandler(this.ConnectRFBtn_Click);
            // 
            // OscInstrumentList
            // 
            this.OscInstrumentList.FormattingEnabled = true;
            this.OscInstrumentList.Location = new System.Drawing.Point(69, 112);
            this.OscInstrumentList.Name = "OscInstrumentList";
            this.OscInstrumentList.Size = new System.Drawing.Size(135, 21);
            this.OscInstrumentList.TabIndex = 1;
            // 
            // ConnectWGBtn
            // 
            this.ConnectWGBtn.Location = new System.Drawing.Point(210, 57);
            this.ConnectWGBtn.Name = "ConnectWGBtn";
            this.ConnectWGBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectWGBtn.TabIndex = 2;
            this.ConnectWGBtn.Text = "Connect";
            this.ConnectWGBtn.UseVisualStyleBackColor = true;
            this.ConnectWGBtn.Click += new System.EventHandler(this.ConnectWGBtn_Click);
            // 
            // RFInstrumentList
            // 
            this.RFInstrumentList.FormattingEnabled = true;
            this.RFInstrumentList.Location = new System.Drawing.Point(69, 85);
            this.RFInstrumentList.Name = "RFInstrumentList";
            this.RFInstrumentList.Size = new System.Drawing.Size(135, 21);
            this.RFInstrumentList.TabIndex = 1;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(3, 61);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(65, 13);
            this.label41.TabIndex = 24;
            this.label41.Text = "Waveform g";
            // 
            // WGInstrumentList
            // 
            this.WGInstrumentList.FormattingEnabled = true;
            this.WGInstrumentList.Location = new System.Drawing.Point(69, 58);
            this.WGInstrumentList.Name = "WGInstrumentList";
            this.WGInstrumentList.Size = new System.Drawing.Size(135, 21);
            this.WGInstrumentList.TabIndex = 1;
            // 
            // RefreshListBtn
            // 
            this.RefreshListBtn.Location = new System.Drawing.Point(6, 19);
            this.RefreshListBtn.Name = "RefreshListBtn";
            this.RefreshListBtn.Size = new System.Drawing.Size(75, 23);
            this.RefreshListBtn.TabIndex = 3;
            this.RefreshListBtn.Text = "Refresh list";
            this.RefreshListBtn.UseVisualStyleBackColor = true;
            this.RefreshListBtn.Click += new System.EventHandler(this.RefreshListBtn_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.SaveImgBtn);
            this.groupBox9.Controls.Add(this.BrowseImgPathBtn);
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Controls.Add(this.ImgPathBox);
            this.groupBox9.Controls.Add(this.TurnAMOnOffBtn);
            this.groupBox9.Controls.Add(this.StopBtn);
            this.groupBox9.Controls.Add(this.ProgressLabel);
            this.groupBox9.Controls.Add(this.label35);
            this.groupBox9.Controls.Add(this.BrowseSaveFileBtn);
            this.groupBox9.Controls.Add(this.label40);
            this.groupBox9.Controls.Add(this.StartBtn);
            this.groupBox9.Controls.Add(this.FileNameBox);
            this.groupBox9.Controls.Add(this.StartLabel);
            this.groupBox9.Controls.Add(this.StopLabel);
            this.groupBox9.Controls.Add(this.StepLabel);
            this.groupBox9.Controls.Add(this.StepBox);
            this.groupBox9.Controls.Add(this.StopBox);
            this.groupBox9.Controls.Add(this.TurnOnRFBtn);
            this.groupBox9.Controls.Add(this.label36);
            this.groupBox9.Controls.Add(this.label38);
            this.groupBox9.Controls.Add(this.ApplyRFBtn);
            this.groupBox9.Controls.Add(this.CWFreqBox);
            this.groupBox9.Controls.Add(this.StartBox);
            this.groupBox9.Controls.Add(this.SetRFPowerBox);
            this.groupBox9.Controls.Add(this.FFTPeakBox);
            this.groupBox9.Location = new System.Drawing.Point(310, 17);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox9.Size = new System.Drawing.Size(324, 422);
            this.groupBox9.TabIndex = 19;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "RF setup";
            // 
            // SaveImgBtn
            // 
            this.SaveImgBtn.Location = new System.Drawing.Point(196, 328);
            this.SaveImgBtn.Name = "SaveImgBtn";
            this.SaveImgBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveImgBtn.TabIndex = 37;
            this.SaveImgBtn.Text = "Save image";
            this.SaveImgBtn.UseVisualStyleBackColor = true;
            this.SaveImgBtn.Click += new System.EventHandler(this.SaveImgBtn_Click);
            // 
            // BrowseImgPathBtn
            // 
            this.BrowseImgPathBtn.Location = new System.Drawing.Point(115, 328);
            this.BrowseImgPathBtn.Name = "BrowseImgPathBtn";
            this.BrowseImgPathBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseImgPathBtn.TabIndex = 36;
            this.BrowseImgPathBtn.Text = "Browse";
            this.BrowseImgPathBtn.UseVisualStyleBackColor = true;
            this.BrowseImgPathBtn.Click += new System.EventHandler(this.BrowseImgPathBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 315);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Save image";
            // 
            // ImgPathBox
            // 
            this.ImgPathBox.Location = new System.Drawing.Point(9, 331);
            this.ImgPathBox.Name = "ImgPathBox";
            this.ImgPathBox.Size = new System.Drawing.Size(100, 20);
            this.ImgPathBox.TabIndex = 34;
            // 
            // TurnAMOnOffBtn
            // 
            this.TurnAMOnOffBtn.Location = new System.Drawing.Point(167, 142);
            this.TurnAMOnOffBtn.Name = "TurnAMOnOffBtn";
            this.TurnAMOnOffBtn.Size = new System.Drawing.Size(75, 23);
            this.TurnAMOnOffBtn.TabIndex = 33;
            this.TurnAMOnOffBtn.Text = "Turn AM On";
            this.TurnAMOnOffBtn.UseVisualStyleBackColor = true;
            this.TurnAMOnOffBtn.Click += new System.EventHandler(this.TurnAMOnOffBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(104, 259);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(91, 23);
            this.StopBtn.TabIndex = 32;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Location = new System.Drawing.Point(60, 285);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(24, 13);
            this.ProgressLabel.TabIndex = 30;
            this.ProgressLabel.Text = "0/0";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(7, 285);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(54, 13);
            this.label35.TabIndex = 31;
            this.label35.Text = "Progress: ";
            // 
            // BrowseSaveFileBtn
            // 
            this.BrowseSaveFileBtn.Location = new System.Drawing.Point(113, 224);
            this.BrowseSaveFileBtn.Name = "BrowseSaveFileBtn";
            this.BrowseSaveFileBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseSaveFileBtn.TabIndex = 29;
            this.BrowseSaveFileBtn.Text = "Browse";
            this.BrowseSaveFileBtn.UseVisualStyleBackColor = true;
            this.BrowseSaveFileBtn.Click += new System.EventHandler(this.BrowseSaveFileBtn_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(5, 211);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(52, 13);
            this.label40.TabIndex = 25;
            this.label40.Text = "File name";
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(7, 259);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(91, 23);
            this.StartBtn.TabIndex = 20;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // FileNameBox
            // 
            this.FileNameBox.Location = new System.Drawing.Point(7, 227);
            this.FileNameBox.Name = "FileNameBox";
            this.FileNameBox.Size = new System.Drawing.Size(100, 20);
            this.FileNameBox.TabIndex = 24;
            // 
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.Location = new System.Drawing.Point(5, 100);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(29, 13);
            this.StartLabel.TabIndex = 28;
            this.StartLabel.Text = "Start";
            // 
            // StopLabel
            // 
            this.StopLabel.AutoSize = true;
            this.StopLabel.Location = new System.Drawing.Point(67, 100);
            this.StopLabel.Name = "StopLabel";
            this.StopLabel.Size = new System.Drawing.Size(29, 13);
            this.StopLabel.TabIndex = 27;
            this.StopLabel.Text = "Stop";
            // 
            // StepLabel
            // 
            this.StepLabel.AutoSize = true;
            this.StepLabel.Location = new System.Drawing.Point(129, 100);
            this.StepLabel.Name = "StepLabel";
            this.StepLabel.Size = new System.Drawing.Size(29, 13);
            this.StepLabel.TabIndex = 26;
            this.StepLabel.Text = "Step";
            // 
            // StepBox
            // 
            this.StepBox.Location = new System.Drawing.Point(129, 116);
            this.StepBox.Name = "StepBox";
            this.StepBox.Size = new System.Drawing.Size(56, 20);
            this.StepBox.TabIndex = 25;
            // 
            // StopBox
            // 
            this.StopBox.Location = new System.Drawing.Point(67, 116);
            this.StopBox.Name = "StopBox";
            this.StopBox.Size = new System.Drawing.Size(56, 20);
            this.StopBox.TabIndex = 24;
            // 
            // TurnOnRFBtn
            // 
            this.TurnOnRFBtn.Location = new System.Drawing.Point(86, 142);
            this.TurnOnRFBtn.Name = "TurnOnRFBtn";
            this.TurnOnRFBtn.Size = new System.Drawing.Size(75, 23);
            this.TurnOnRFBtn.TabIndex = 4;
            this.TurnOnRFBtn.Text = "Turn On";
            this.TurnOnRFBtn.UseVisualStyleBackColor = true;
            this.TurnOnRFBtn.Click += new System.EventHandler(this.TurnOnRFBtn_Click);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(6, 172);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(53, 13);
            this.label36.TabIndex = 19;
            this.label36.Text = "FFT peak";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(7, 28);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(117, 13);
            this.label38.TabIndex = 12;
            this.label38.Text = "Carrier frequency [GHz]";
            // 
            // ApplyRFBtn
            // 
            this.ApplyRFBtn.Location = new System.Drawing.Point(5, 142);
            this.ApplyRFBtn.Name = "ApplyRFBtn";
            this.ApplyRFBtn.Size = new System.Drawing.Size(75, 23);
            this.ApplyRFBtn.TabIndex = 4;
            this.ApplyRFBtn.Text = "Apply";
            this.ApplyRFBtn.UseVisualStyleBackColor = true;
            this.ApplyRFBtn.Click += new System.EventHandler(this.ApplyRFBtn_Click);
            // 
            // CWFreqBox
            // 
            this.CWFreqBox.Location = new System.Drawing.Point(5, 46);
            this.CWFreqBox.Name = "CWFreqBox";
            this.CWFreqBox.Size = new System.Drawing.Size(100, 20);
            this.CWFreqBox.TabIndex = 2;
            // 
            // StartBox
            // 
            this.StartBox.Location = new System.Drawing.Point(5, 116);
            this.StartBox.Name = "StartBox";
            this.StartBox.Size = new System.Drawing.Size(56, 20);
            this.StartBox.TabIndex = 5;
            // 
            // SetRFPowerBox
            // 
            this.SetRFPowerBox.AutoSize = true;
            this.SetRFPowerBox.Location = new System.Drawing.Point(5, 78);
            this.SetRFPowerBox.Name = "SetRFPowerBox";
            this.SetRFPowerBox.Size = new System.Drawing.Size(124, 13);
            this.SetRFPowerBox.TabIndex = 6;
            this.SetRFPowerBox.Text = "Set sweep options [dBm]";
            // 
            // FFTPeakBox
            // 
            this.FFTPeakBox.Enabled = false;
            this.FFTPeakBox.Location = new System.Drawing.Point(5, 188);
            this.FFTPeakBox.Name = "FFTPeakBox";
            this.FFTPeakBox.Size = new System.Drawing.Size(55, 20);
            this.FFTPeakBox.TabIndex = 16;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(12, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 216);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Waveform generator setup";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.StepFreqBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.StopFreqBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.StartFreqBox);
            this.groupBox3.Controls.Add(this.ApplyWGbtn);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.TurnOnWGBtn);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.VoltageBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(279, 191);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Source";
            // 
            // StepFreqBox
            // 
            this.StepFreqBox.Location = new System.Drawing.Point(130, 101);
            this.StepFreqBox.Name = "StepFreqBox";
            this.StepFreqBox.Size = new System.Drawing.Size(56, 20);
            this.StepFreqBox.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Start";
            // 
            // StopFreqBox
            // 
            this.StopFreqBox.Location = new System.Drawing.Point(68, 101);
            this.StopFreqBox.Name = "StopFreqBox";
            this.StopFreqBox.Size = new System.Drawing.Size(56, 20);
            this.StopFreqBox.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Stop";
            // 
            // StartFreqBox
            // 
            this.StartFreqBox.Location = new System.Drawing.Point(6, 101);
            this.StartFreqBox.Name = "StartFreqBox";
            this.StartFreqBox.Size = new System.Drawing.Size(56, 20);
            this.StartFreqBox.TabIndex = 34;
            // 
            // ApplyWGbtn
            // 
            this.ApplyWGbtn.Location = new System.Drawing.Point(6, 135);
            this.ApplyWGbtn.Name = "ApplyWGbtn";
            this.ApplyWGbtn.Size = new System.Drawing.Size(75, 23);
            this.ApplyWGbtn.TabIndex = 4;
            this.ApplyWGbtn.Text = "Apply";
            this.ApplyWGbtn.UseVisualStyleBackColor = true;
            this.ApplyWGbtn.Click += new System.EventHandler(this.ApplyWGbtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(130, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Step";
            // 
            // TurnOnWGBtn
            // 
            this.TurnOnWGBtn.Location = new System.Drawing.Point(87, 135);
            this.TurnOnWGBtn.Name = "TurnOnWGBtn";
            this.TurnOnWGBtn.Size = new System.Drawing.Size(75, 23);
            this.TurnOnWGBtn.TabIndex = 8;
            this.TurnOnWGBtn.Text = "Turn On";
            this.TurnOnWGBtn.UseVisualStyleBackColor = true;
            this.TurnOnWGBtn.Click += new System.EventHandler(this.TurnOnWGBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Set frequency sweep options [MHz]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Vpp";
            // 
            // VoltageBox
            // 
            this.VoltageBox.Location = new System.Drawing.Point(6, 39);
            this.VoltageBox.Name = "VoltageBox";
            this.VoltageBox.Size = new System.Drawing.Size(100, 20);
            this.VoltageBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Set voltage";
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(639, 17);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(286, 421);
            this.LogBox.TabIndex = 35;
            this.LogBox.Text = "";
            // 
            // PowerDetectorTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 450);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox17);
            this.Name = "PowerDetectorTestForm";
            this.Text = "PowerDetectorTest";
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Button ConnectOscBtn;
        private System.Windows.Forms.Button ConnectRFBtn;
        private System.Windows.Forms.ComboBox OscInstrumentList;
        private System.Windows.Forms.Button ConnectWGBtn;
        private System.Windows.Forms.ComboBox RFInstrumentList;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.ComboBox WGInstrumentList;
        private System.Windows.Forms.Button RefreshListBtn;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button BrowseSaveFileBtn;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.TextBox FileNameBox;
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label StopLabel;
        private System.Windows.Forms.Label StepLabel;
        private System.Windows.Forms.TextBox StepBox;
        private System.Windows.Forms.TextBox StopBox;
        private System.Windows.Forms.Button TurnOnRFBtn;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button ApplyRFBtn;
        private System.Windows.Forms.TextBox CWFreqBox;
        private System.Windows.Forms.TextBox StartBox;
        private System.Windows.Forms.Label SetRFPowerBox;
        private System.Windows.Forms.TextBox FFTPeakBox;
        private System.Windows.Forms.Button TurnAMOnOffBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox StepFreqBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox StopFreqBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox StartFreqBox;
        private System.Windows.Forms.Button ApplyWGbtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button TurnOnWGBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox VoltageBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveImgBtn;
        private System.Windows.Forms.Button BrowseImgPathBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ImgPathBox;
        private System.Windows.Forms.RichTextBox LogBox;
    }
}

