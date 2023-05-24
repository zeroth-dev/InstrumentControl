namespace InstrumentDriverTest.TestForms
{
    partial class OscTestForm
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.InstrumentList = new System.Windows.Forms.ComboBox();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.SendCmdBtn = new System.Windows.Forms.Button();
            this.CmdBox = new System.Windows.Forms.TextBox();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.CtrlBox = new System.Windows.Forms.GroupBox();
            this.GetFFTBtn = new System.Windows.Forms.Button();
            this.GetDataBtn = new System.Windows.Forms.Button();
            this.SaveFFTDataBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.FFTSavePathBox = new System.Windows.Forms.TextBox();
            this.BrowseFFTPathBtn = new System.Windows.Forms.Button();
            this.SaveOscDataBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.DataFilePathBox = new System.Windows.Forms.TextBox();
            this.BrowseOscDataPathBox = new System.Windows.Forms.Button();
            this.SaveImgBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.AvgTypeBtn = new System.Windows.Forms.RadioButton();
            this.NormTypeBtn = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.ImgSavePathBox = new System.Windows.Forms.TextBox();
            this.BrowseOscSavePathBtn = new System.Windows.Forms.Button();
            this.AvgNoBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ChannelBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FFTPeakBtn = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.CtrlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ConnectBtn);
            this.groupBox5.Controls.Add(this.InstrumentList);
            this.groupBox5.Controls.Add(this.RefreshBtn);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(352, 51);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Init";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(271, 19);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectBtn.TabIndex = 2;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // InstrumentList
            // 
            this.InstrumentList.FormattingEnabled = true;
            this.InstrumentList.Location = new System.Drawing.Point(87, 19);
            this.InstrumentList.Name = "InstrumentList";
            this.InstrumentList.Size = new System.Drawing.Size(178, 21);
            this.InstrumentList.TabIndex = 1;
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Location = new System.Drawing.Point(6, 19);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(75, 23);
            this.RefreshBtn.TabIndex = 0;
            this.RefreshBtn.Text = "Refresh list";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // SendCmdBtn
            // 
            this.SendCmdBtn.Location = new System.Drawing.Point(273, 503);
            this.SendCmdBtn.Name = "SendCmdBtn";
            this.SendCmdBtn.Size = new System.Drawing.Size(91, 20);
            this.SendCmdBtn.TabIndex = 10;
            this.SendCmdBtn.Text = "Send command";
            this.SendCmdBtn.UseVisualStyleBackColor = true;
            // 
            // CmdBox
            // 
            this.CmdBox.Location = new System.Drawing.Point(12, 503);
            this.CmdBox.Name = "CmdBox";
            this.CmdBox.Size = new System.Drawing.Size(255, 20);
            this.CmdBox.TabIndex = 9;
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(12, 348);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(352, 149);
            this.LogBox.TabIndex = 8;
            this.LogBox.Text = "";
            // 
            // CtrlBox
            // 
            this.CtrlBox.Controls.Add(this.FFTPeakBtn);
            this.CtrlBox.Controls.Add(this.GetFFTBtn);
            this.CtrlBox.Controls.Add(this.GetDataBtn);
            this.CtrlBox.Controls.Add(this.SaveFFTDataBtn);
            this.CtrlBox.Controls.Add(this.label4);
            this.CtrlBox.Controls.Add(this.FFTSavePathBox);
            this.CtrlBox.Controls.Add(this.BrowseFFTPathBtn);
            this.CtrlBox.Controls.Add(this.SaveOscDataBtn);
            this.CtrlBox.Controls.Add(this.label3);
            this.CtrlBox.Controls.Add(this.DataFilePathBox);
            this.CtrlBox.Controls.Add(this.BrowseOscDataPathBox);
            this.CtrlBox.Controls.Add(this.SaveImgBtn);
            this.CtrlBox.Controls.Add(this.label2);
            this.CtrlBox.Controls.Add(this.AvgTypeBtn);
            this.CtrlBox.Controls.Add(this.NormTypeBtn);
            this.CtrlBox.Controls.Add(this.label12);
            this.CtrlBox.Controls.Add(this.ImgSavePathBox);
            this.CtrlBox.Controls.Add(this.BrowseOscSavePathBtn);
            this.CtrlBox.Controls.Add(this.AvgNoBox);
            this.CtrlBox.Controls.Add(this.label11);
            this.CtrlBox.Controls.Add(this.ChannelBox);
            this.CtrlBox.Controls.Add(this.label1);
            this.CtrlBox.Location = new System.Drawing.Point(12, 69);
            this.CtrlBox.Name = "CtrlBox";
            this.CtrlBox.Size = new System.Drawing.Size(352, 273);
            this.CtrlBox.TabIndex = 11;
            this.CtrlBox.TabStop = false;
            this.CtrlBox.Text = "Control";
            // 
            // GetFFTBtn
            // 
            this.GetFFTBtn.Enabled = false;
            this.GetFFTBtn.Location = new System.Drawing.Point(207, 90);
            this.GetFFTBtn.Name = "GetFFTBtn";
            this.GetFFTBtn.Size = new System.Drawing.Size(75, 23);
            this.GetFFTBtn.TabIndex = 42;
            this.GetFFTBtn.Text = "Get fft";
            this.GetFFTBtn.UseVisualStyleBackColor = true;
            this.GetFFTBtn.Click += new System.EventHandler(this.GetFFTBtn_Click);
            // 
            // GetDataBtn
            // 
            this.GetDataBtn.Enabled = false;
            this.GetDataBtn.Location = new System.Drawing.Point(126, 90);
            this.GetDataBtn.Name = "GetDataBtn";
            this.GetDataBtn.Size = new System.Drawing.Size(75, 23);
            this.GetDataBtn.TabIndex = 41;
            this.GetDataBtn.Text = "Get data";
            this.GetDataBtn.UseVisualStyleBackColor = true;
            this.GetDataBtn.Click += new System.EventHandler(this.GetDataBtn_Click);
            // 
            // SaveFFTDataBtn
            // 
            this.SaveFFTDataBtn.Enabled = false;
            this.SaveFFTDataBtn.Location = new System.Drawing.Point(244, 221);
            this.SaveFFTDataBtn.Name = "SaveFFTDataBtn";
            this.SaveFFTDataBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveFFTDataBtn.TabIndex = 40;
            this.SaveFFTDataBtn.Text = "Save fft";
            this.SaveFFTDataBtn.UseVisualStyleBackColor = true;
            this.SaveFFTDataBtn.Click += new System.EventHandler(this.SaveFFTDataBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "FFT save path";
            // 
            // FFTSavePathBox
            // 
            this.FFTSavePathBox.Enabled = false;
            this.FFTSavePathBox.Location = new System.Drawing.Point(6, 224);
            this.FFTSavePathBox.Name = "FFTSavePathBox";
            this.FFTSavePathBox.Size = new System.Drawing.Size(149, 20);
            this.FFTSavePathBox.TabIndex = 39;
            // 
            // BrowseFFTPathBtn
            // 
            this.BrowseFFTPathBtn.Enabled = false;
            this.BrowseFFTPathBtn.Location = new System.Drawing.Point(163, 221);
            this.BrowseFFTPathBtn.Name = "BrowseFFTPathBtn";
            this.BrowseFFTPathBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseFFTPathBtn.TabIndex = 38;
            this.BrowseFFTPathBtn.Text = "Browse";
            this.BrowseFFTPathBtn.UseVisualStyleBackColor = true;
            this.BrowseFFTPathBtn.Click += new System.EventHandler(this.BrowseFFTPathBtn_Click);
            // 
            // SaveOscDataBtn
            // 
            this.SaveOscDataBtn.Enabled = false;
            this.SaveOscDataBtn.Location = new System.Drawing.Point(244, 180);
            this.SaveOscDataBtn.Name = "SaveOscDataBtn";
            this.SaveOscDataBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveOscDataBtn.TabIndex = 36;
            this.SaveOscDataBtn.Text = "Save data";
            this.SaveOscDataBtn.UseVisualStyleBackColor = true;
            this.SaveOscDataBtn.Click += new System.EventHandler(this.SaveOscDataBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Data save path";
            // 
            // DataFilePathBox
            // 
            this.DataFilePathBox.Enabled = false;
            this.DataFilePathBox.Location = new System.Drawing.Point(6, 183);
            this.DataFilePathBox.Name = "DataFilePathBox";
            this.DataFilePathBox.Size = new System.Drawing.Size(149, 20);
            this.DataFilePathBox.TabIndex = 35;
            // 
            // BrowseOscDataPathBox
            // 
            this.BrowseOscDataPathBox.Enabled = false;
            this.BrowseOscDataPathBox.Location = new System.Drawing.Point(163, 180);
            this.BrowseOscDataPathBox.Name = "BrowseOscDataPathBox";
            this.BrowseOscDataPathBox.Size = new System.Drawing.Size(75, 23);
            this.BrowseOscDataPathBox.TabIndex = 34;
            this.BrowseOscDataPathBox.Text = "Browse";
            this.BrowseOscDataPathBox.UseVisualStyleBackColor = true;
            this.BrowseOscDataPathBox.Click += new System.EventHandler(this.BrowseOscDataPathBox_Click);
            // 
            // SaveImgBtn
            // 
            this.SaveImgBtn.Enabled = false;
            this.SaveImgBtn.Location = new System.Drawing.Point(244, 135);
            this.SaveImgBtn.Name = "SaveImgBtn";
            this.SaveImgBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveImgBtn.TabIndex = 32;
            this.SaveImgBtn.Text = "Save image";
            this.SaveImgBtn.UseVisualStyleBackColor = true;
            this.SaveImgBtn.Click += new System.EventHandler(this.SaveImgBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Acquisition type";
            // 
            // AvgTypeBtn
            // 
            this.AvgTypeBtn.AutoSize = true;
            this.AvgTypeBtn.Location = new System.Drawing.Point(72, 67);
            this.AvgTypeBtn.Name = "AvgTypeBtn";
            this.AvgTypeBtn.Size = new System.Drawing.Size(65, 17);
            this.AvgTypeBtn.TabIndex = 30;
            this.AvgTypeBtn.TabStop = true;
            this.AvgTypeBtn.Text = "Average";
            this.AvgTypeBtn.UseVisualStyleBackColor = true;
            this.AvgTypeBtn.CheckedChanged += new System.EventHandler(this.AvgTypeBtn_CheckedChanged);
            // 
            // NormTypeBtn
            // 
            this.NormTypeBtn.AutoSize = true;
            this.NormTypeBtn.Location = new System.Drawing.Point(8, 67);
            this.NormTypeBtn.Name = "NormTypeBtn";
            this.NormTypeBtn.Size = new System.Drawing.Size(58, 17);
            this.NormTypeBtn.TabIndex = 29;
            this.NormTypeBtn.TabStop = true;
            this.NormTypeBtn.Text = "Normal";
            this.NormTypeBtn.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 122);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Image save path";
            // 
            // ImgSavePathBox
            // 
            this.ImgSavePathBox.Enabled = false;
            this.ImgSavePathBox.Location = new System.Drawing.Point(6, 138);
            this.ImgSavePathBox.Name = "ImgSavePathBox";
            this.ImgSavePathBox.Size = new System.Drawing.Size(149, 20);
            this.ImgSavePathBox.TabIndex = 24;
            // 
            // BrowseOscSavePathBtn
            // 
            this.BrowseOscSavePathBtn.Enabled = false;
            this.BrowseOscSavePathBtn.Location = new System.Drawing.Point(163, 135);
            this.BrowseOscSavePathBtn.Name = "BrowseOscSavePathBtn";
            this.BrowseOscSavePathBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseOscSavePathBtn.TabIndex = 22;
            this.BrowseOscSavePathBtn.Text = "Browse";
            this.BrowseOscSavePathBtn.UseVisualStyleBackColor = true;
            this.BrowseOscSavePathBtn.Click += new System.EventHandler(this.BrowseOscSavePathBtn_Click);
            // 
            // AvgNoBox
            // 
            this.AvgNoBox.Enabled = false;
            this.AvgNoBox.Location = new System.Drawing.Point(88, 90);
            this.AvgNoBox.Name = "AvgNoBox";
            this.AvgNoBox.Size = new System.Drawing.Size(32, 20);
            this.AvgNoBox.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "No. of averages";
            // 
            // ChannelBox
            // 
            this.ChannelBox.Enabled = false;
            this.ChannelBox.Location = new System.Drawing.Point(88, 20);
            this.ChannelBox.Name = "ChannelBox";
            this.ChannelBox.Size = new System.Drawing.Size(32, 20);
            this.ChannelBox.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Channel";
            // 
            // FFTPeakBtn
            // 
            this.FFTPeakBtn.Enabled = false;
            this.FFTPeakBtn.Location = new System.Drawing.Point(207, 61);
            this.FFTPeakBtn.Name = "FFTPeakBtn";
            this.FFTPeakBtn.Size = new System.Drawing.Size(75, 23);
            this.FFTPeakBtn.TabIndex = 43;
            this.FFTPeakBtn.Text = "Get fft peak";
            this.FFTPeakBtn.UseVisualStyleBackColor = true;
            this.FFTPeakBtn.Click += new System.EventHandler(this.FFTPeakBtn_Click);
            // 
            // OscTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 535);
            this.Controls.Add(this.CtrlBox);
            this.Controls.Add(this.SendCmdBtn);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.CmdBox);
            this.Controls.Add(this.LogBox);
            this.Name = "OscTestForm";
            this.Text = "OscTestForm";
            this.groupBox5.ResumeLayout(false);
            this.CtrlBox.ResumeLayout(false);
            this.CtrlBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.ComboBox InstrumentList;
        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.Button SendCmdBtn;
        private System.Windows.Forms.TextBox CmdBox;
        private System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.GroupBox CtrlBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox ImgSavePathBox;
        private System.Windows.Forms.Button BrowseOscSavePathBtn;
        private System.Windows.Forms.TextBox AvgNoBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ChannelBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton AvgTypeBtn;
        private System.Windows.Forms.RadioButton NormTypeBtn;
        private System.Windows.Forms.Button SaveImgBtn;
        private System.Windows.Forms.Button SaveOscDataBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DataFilePathBox;
        private System.Windows.Forms.Button BrowseOscDataPathBox;
        private System.Windows.Forms.Button SaveFFTDataBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FFTSavePathBox;
        private System.Windows.Forms.Button BrowseFFTPathBtn;
        private System.Windows.Forms.Button GetFFTBtn;
        private System.Windows.Forms.Button GetDataBtn;
        private System.Windows.Forms.Button FFTPeakBtn;
    }
}