namespace MaxEfficiencySweep
{
    partial class MaxEffSweepForm
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
            this.ConnectSABtn = new System.Windows.Forms.Button();
            this.ConnectRFBtn = new System.Windows.Forms.Button();
            this.SAInstrumentList = new System.Windows.Forms.ComboBox();
            this.ConnectDCBtn = new System.Windows.Forms.Button();
            this.RFInstrumentList = new System.Windows.Forms.ComboBox();
            this.label41 = new System.Windows.Forms.Label();
            this.DCInstrumentList = new System.Windows.Forms.ComboBox();
            this.RefreshListBtn = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.BrowseSaveFileBtn = new System.Windows.Forms.Button();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.StopBtn = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.FileNameBox = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.AttBox = new System.Windows.Forms.TextBox();
            this.FreqBandBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TurnOnRFBtn = new System.Windows.Forms.Button();
            this.PreampGainBox = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.ApplyRFBtn = new System.Windows.Forms.Button();
            this.CWFreqBox = new System.Windows.Forms.TextBox();
            this.PowerBox = new System.Windows.Forms.TextBox();
            this.EffBox = new System.Windows.Forms.TextBox();
            this.SetRFPowerBox = new System.Windows.Forms.Label();
            this.BaseHarmBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ApplyDCSrc2Btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Src2CurrentBox = new System.Windows.Forms.TextBox();
            this.Src2VoltageBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ApplyDCSrc1btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Src1CurrentBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Src1VoltageBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TurnOnDCSrcBtn = new System.Windows.Forms.Button();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.groupBox17.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.label43);
            this.groupBox17.Controls.Add(this.label42);
            this.groupBox17.Controls.Add(this.ConnectSABtn);
            this.groupBox17.Controls.Add(this.ConnectRFBtn);
            this.groupBox17.Controls.Add(this.SAInstrumentList);
            this.groupBox17.Controls.Add(this.ConnectDCBtn);
            this.groupBox17.Controls.Add(this.RFInstrumentList);
            this.groupBox17.Controls.Add(this.label41);
            this.groupBox17.Controls.Add(this.DCInstrumentList);
            this.groupBox17.Controls.Add(this.RefreshListBtn);
            this.groupBox17.Location = new System.Drawing.Point(12, 12);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(293, 141);
            this.groupBox17.TabIndex = 10;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "GPIB setup";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(6, 116);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(52, 13);
            this.label43.TabIndex = 26;
            this.label43.Text = "Spectrum";
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
            // ConnectSABtn
            // 
            this.ConnectSABtn.Location = new System.Drawing.Point(210, 111);
            this.ConnectSABtn.Name = "ConnectSABtn";
            this.ConnectSABtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectSABtn.TabIndex = 2;
            this.ConnectSABtn.Text = "Connect";
            this.ConnectSABtn.UseVisualStyleBackColor = true;
            this.ConnectSABtn.Click += new System.EventHandler(this.ConnectSABtn_Click);
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
            // SAInstrumentList
            // 
            this.SAInstrumentList.FormattingEnabled = true;
            this.SAInstrumentList.Location = new System.Drawing.Point(69, 112);
            this.SAInstrumentList.Name = "SAInstrumentList";
            this.SAInstrumentList.Size = new System.Drawing.Size(135, 21);
            this.SAInstrumentList.TabIndex = 1;
            // 
            // ConnectDCBtn
            // 
            this.ConnectDCBtn.Location = new System.Drawing.Point(210, 57);
            this.ConnectDCBtn.Name = "ConnectDCBtn";
            this.ConnectDCBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectDCBtn.TabIndex = 2;
            this.ConnectDCBtn.Text = "Connect";
            this.ConnectDCBtn.UseVisualStyleBackColor = true;
            this.ConnectDCBtn.Click += new System.EventHandler(this.ConnectDCBtn_Click);
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
            this.label41.Location = new System.Drawing.Point(6, 61);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(57, 13);
            this.label41.TabIndex = 24;
            this.label41.Text = "DC source";
            // 
            // DCInstrumentList
            // 
            this.DCInstrumentList.FormattingEnabled = true;
            this.DCInstrumentList.Location = new System.Drawing.Point(69, 58);
            this.DCInstrumentList.Name = "DCInstrumentList";
            this.DCInstrumentList.Size = new System.Drawing.Size(135, 21);
            this.DCInstrumentList.TabIndex = 1;
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
            this.groupBox9.Controls.Add(this.BrowseSaveFileBtn);
            this.groupBox9.Controls.Add(this.ProgressLabel);
            this.groupBox9.Controls.Add(this.StopBtn);
            this.groupBox9.Controls.Add(this.label40);
            this.groupBox9.Controls.Add(this.label35);
            this.groupBox9.Controls.Add(this.FileNameBox);
            this.groupBox9.Controls.Add(this.label39);
            this.groupBox9.Controls.Add(this.StartBtn);
            this.groupBox9.Controls.Add(this.label27);
            this.groupBox9.Controls.Add(this.AttBox);
            this.groupBox9.Controls.Add(this.FreqBandBox);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.TurnOnRFBtn);
            this.groupBox9.Controls.Add(this.PreampGainBox);
            this.groupBox9.Controls.Add(this.label36);
            this.groupBox9.Controls.Add(this.label38);
            this.groupBox9.Controls.Add(this.ApplyRFBtn);
            this.groupBox9.Controls.Add(this.CWFreqBox);
            this.groupBox9.Controls.Add(this.PowerBox);
            this.groupBox9.Controls.Add(this.EffBox);
            this.groupBox9.Controls.Add(this.SetRFPowerBox);
            this.groupBox9.Controls.Add(this.BaseHarmBox);
            this.groupBox9.Location = new System.Drawing.Point(310, 12);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox9.Size = new System.Drawing.Size(324, 384);
            this.groupBox9.TabIndex = 16;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "RF setup";
            // 
            // BrowseSaveFileBtn
            // 
            this.BrowseSaveFileBtn.Location = new System.Drawing.Point(113, 296);
            this.BrowseSaveFileBtn.Name = "BrowseSaveFileBtn";
            this.BrowseSaveFileBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseSaveFileBtn.TabIndex = 41;
            this.BrowseSaveFileBtn.Text = "Browse";
            this.BrowseSaveFileBtn.UseVisualStyleBackColor = true;
            this.BrowseSaveFileBtn.Click += new System.EventHandler(this.BrowseSaveFileBtn_Click);
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Location = new System.Drawing.Point(57, 351);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(24, 13);
            this.ProgressLabel.TabIndex = 37;
            this.ProgressLabel.Text = "0/0";
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(103, 325);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(91, 23);
            this.StopBtn.TabIndex = 26;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(5, 283);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(52, 13);
            this.label40.TabIndex = 40;
            this.label40.Text = "File name";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(6, 351);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(54, 13);
            this.label35.TabIndex = 38;
            this.label35.Text = "Progress: ";
            // 
            // FileNameBox
            // 
            this.FileNameBox.Location = new System.Drawing.Point(7, 299);
            this.FileNameBox.Name = "FileNameBox";
            this.FileNameBox.Size = new System.Drawing.Size(100, 20);
            this.FileNameBox.TabIndex = 39;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(3, 209);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(117, 13);
            this.label39.TabIndex = 23;
            this.label39.Text = "Output attenuation [dB]";
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(6, 325);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(91, 23);
            this.StartBtn.TabIndex = 25;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(2, 124);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(88, 13);
            this.label27.TabIndex = 9;
            this.label27.Text = "Preamp gain [dB]";
            // 
            // AttBox
            // 
            this.AttBox.Location = new System.Drawing.Point(126, 206);
            this.AttBox.Name = "AttBox";
            this.AttBox.Size = new System.Drawing.Size(55, 20);
            this.AttBox.TabIndex = 22;
            // 
            // FreqBandBox
            // 
            this.FreqBandBox.FormattingEnabled = true;
            this.FreqBandBox.Location = new System.Drawing.Point(111, 45);
            this.FreqBandBox.Name = "FreqBandBox";
            this.FreqBandBox.Size = new System.Drawing.Size(52, 21);
            this.FreqBandBox.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(64, 244);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Efficiency";
            // 
            // TurnOnRFBtn
            // 
            this.TurnOnRFBtn.Location = new System.Drawing.Point(86, 166);
            this.TurnOnRFBtn.Name = "TurnOnRFBtn";
            this.TurnOnRFBtn.Size = new System.Drawing.Size(75, 23);
            this.TurnOnRFBtn.TabIndex = 4;
            this.TurnOnRFBtn.Text = "Turn On";
            this.TurnOnRFBtn.UseVisualStyleBackColor = true;
            this.TurnOnRFBtn.Click += new System.EventHandler(this.TurnOnRFBtn_Click);
            // 
            // PreampGainBox
            // 
            this.PreampGainBox.Location = new System.Drawing.Point(5, 140);
            this.PreampGainBox.Name = "PreampGainBox";
            this.PreampGainBox.Size = new System.Drawing.Size(100, 20);
            this.PreampGainBox.TabIndex = 8;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(6, 244);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(29, 13);
            this.label36.TabIndex = 19;
            this.label36.Text = "Pout";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(7, 28);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(57, 13);
            this.label38.TabIndex = 12;
            this.label38.Text = "Frequency";
            // 
            // ApplyRFBtn
            // 
            this.ApplyRFBtn.Location = new System.Drawing.Point(5, 166);
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
            // PowerBox
            // 
            this.PowerBox.Location = new System.Drawing.Point(5, 91);
            this.PowerBox.Name = "PowerBox";
            this.PowerBox.Size = new System.Drawing.Size(276, 20);
            this.PowerBox.TabIndex = 5;
            // 
            // EffBox
            // 
            this.EffBox.Enabled = false;
            this.EffBox.Location = new System.Drawing.Point(66, 260);
            this.EffBox.Name = "EffBox";
            this.EffBox.Size = new System.Drawing.Size(55, 20);
            this.EffBox.TabIndex = 17;
            // 
            // SetRFPowerBox
            // 
            this.SetRFPowerBox.AutoSize = true;
            this.SetRFPowerBox.Location = new System.Drawing.Point(5, 75);
            this.SetRFPowerBox.Name = "SetRFPowerBox";
            this.SetRFPowerBox.Size = new System.Drawing.Size(276, 13);
            this.SetRFPowerBox.TabIndex = 6;
            this.SetRFPowerBox.Text = "Set wanted input power values (comma separated) [dBm]";
            // 
            // BaseHarmBox
            // 
            this.BaseHarmBox.Enabled = false;
            this.BaseHarmBox.Location = new System.Drawing.Point(5, 260);
            this.BaseHarmBox.Name = "BaseHarmBox";
            this.BaseHarmBox.Size = new System.Drawing.Size(55, 20);
            this.BaseHarmBox.TabIndex = 16;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.TurnOnDCSrcBtn);
            this.groupBox2.Location = new System.Drawing.Point(12, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 236);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DC setup";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ApplyDCSrc2Btn);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.Src2CurrentBox);
            this.groupBox4.Controls.Add(this.Src2VoltageBox);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(145, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(140, 147);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Source 2";
            // 
            // ApplyDCSrc2Btn
            // 
            this.ApplyDCSrc2Btn.Enabled = false;
            this.ApplyDCSrc2Btn.Location = new System.Drawing.Point(6, 115);
            this.ApplyDCSrc2Btn.Name = "ApplyDCSrc2Btn";
            this.ApplyDCSrc2Btn.Size = new System.Drawing.Size(75, 23);
            this.ApplyDCSrc2Btn.TabIndex = 8;
            this.ApplyDCSrc2Btn.Text = "Apply";
            this.ApplyDCSrc2Btn.UseVisualStyleBackColor = true;
            this.ApplyDCSrc2Btn.Click += new System.EventHandler(this.ApplyDCSrc2Btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "A";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Set voltage values";
            // 
            // Src2CurrentBox
            // 
            this.Src2CurrentBox.Location = new System.Drawing.Point(6, 78);
            this.Src2CurrentBox.Name = "Src2CurrentBox";
            this.Src2CurrentBox.Size = new System.Drawing.Size(100, 20);
            this.Src2CurrentBox.TabIndex = 11;
            // 
            // Src2VoltageBox
            // 
            this.Src2VoltageBox.Location = new System.Drawing.Point(6, 39);
            this.Src2VoltageBox.Name = "Src2VoltageBox";
            this.Src2VoltageBox.Size = new System.Drawing.Size(100, 20);
            this.Src2VoltageBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Set current";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(112, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "V";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ApplyDCSrc1btn);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.Src1CurrentBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.Src1VoltageBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(132, 147);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Source 1";
            // 
            // ApplyDCSrc1btn
            // 
            this.ApplyDCSrc1btn.Enabled = false;
            this.ApplyDCSrc1btn.Location = new System.Drawing.Point(6, 114);
            this.ApplyDCSrc1btn.Name = "ApplyDCSrc1btn";
            this.ApplyDCSrc1btn.Size = new System.Drawing.Size(75, 23);
            this.ApplyDCSrc1btn.TabIndex = 4;
            this.ApplyDCSrc1btn.Text = "Apply";
            this.ApplyDCSrc1btn.UseVisualStyleBackColor = true;
            this.ApplyDCSrc1btn.Click += new System.EventHandler(this.ApplyDCSrc1btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "A";
            // 
            // Src1CurrentBox
            // 
            this.Src1CurrentBox.Location = new System.Drawing.Point(6, 78);
            this.Src1CurrentBox.Name = "Src1CurrentBox";
            this.Src1CurrentBox.Size = new System.Drawing.Size(100, 20);
            this.Src1CurrentBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Set current";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "V";
            // 
            // Src1VoltageBox
            // 
            this.Src1VoltageBox.Location = new System.Drawing.Point(6, 39);
            this.Src1VoltageBox.Name = "Src1VoltageBox";
            this.Src1VoltageBox.Size = new System.Drawing.Size(100, 20);
            this.Src1VoltageBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Set voltage values";
            // 
            // TurnOnDCSrcBtn
            // 
            this.TurnOnDCSrcBtn.Enabled = false;
            this.TurnOnDCSrcBtn.Location = new System.Drawing.Point(107, 172);
            this.TurnOnDCSrcBtn.Name = "TurnOnDCSrcBtn";
            this.TurnOnDCSrcBtn.Size = new System.Drawing.Size(75, 23);
            this.TurnOnDCSrcBtn.TabIndex = 8;
            this.TurnOnDCSrcBtn.Text = "Turn On";
            this.TurnOnDCSrcBtn.UseVisualStyleBackColor = true;
            this.TurnOnDCSrcBtn.Click += new System.EventHandler(this.TurnOnDCSrcBtn_Click);
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(12, 401);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(622, 146);
            this.LogBox.TabIndex = 36;
            this.LogBox.Text = "";
            // 
            // MaxEffSweepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 559);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox17);
            this.Name = "MaxEffSweepForm";
            this.Text = "Maximum efficiency sweep";
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Button ConnectSABtn;
        private System.Windows.Forms.Button ConnectRFBtn;
        private System.Windows.Forms.ComboBox SAInstrumentList;
        private System.Windows.Forms.Button ConnectDCBtn;
        private System.Windows.Forms.ComboBox RFInstrumentList;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.ComboBox DCInstrumentList;
        private System.Windows.Forms.Button RefreshListBtn;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox AttBox;
        private System.Windows.Forms.ComboBox FreqBandBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button TurnOnRFBtn;
        private System.Windows.Forms.TextBox PreampGainBox;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button ApplyRFBtn;
        private System.Windows.Forms.TextBox CWFreqBox;
        private System.Windows.Forms.TextBox PowerBox;
        private System.Windows.Forms.TextBox EffBox;
        private System.Windows.Forms.Label SetRFPowerBox;
        private System.Windows.Forms.TextBox BaseHarmBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button ApplyDCSrc2Btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Src2CurrentBox;
        private System.Windows.Forms.TextBox Src2VoltageBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ApplyDCSrc1btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Src1CurrentBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Src1VoltageBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TurnOnDCSrcBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button BrowseSaveFileBtn;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox FileNameBox;
    }
}

