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
            this.OscSaveOptsBtn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.OscSavePathBox = new System.Windows.Forms.TextBox();
            this.OutOscDataCheckBtn = new System.Windows.Forms.CheckBox();
            this.BrowseOscSavePathBtn = new System.Windows.Forms.Button();
            this.AvgDataCheckBtn = new System.Windows.Forms.CheckBox();
            this.AvgNoBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ChannelBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.CtrlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ConnectBtn);
            this.groupBox5.Controls.Add(this.InstrumentList);
            this.groupBox5.Controls.Add(this.RefreshBtn);
            this.groupBox5.Location = new System.Drawing.Point(16, 15);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Size = new System.Drawing.Size(412, 63);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Init";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(304, 21);
            this.ConnectBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(100, 28);
            this.ConnectBtn.TabIndex = 2;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // InstrumentList
            // 
            this.InstrumentList.FormattingEnabled = true;
            this.InstrumentList.Location = new System.Drawing.Point(116, 23);
            this.InstrumentList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.InstrumentList.Name = "InstrumentList";
            this.InstrumentList.Size = new System.Drawing.Size(179, 24);
            this.InstrumentList.TabIndex = 1;
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Location = new System.Drawing.Point(8, 23);
            this.RefreshBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(100, 28);
            this.RefreshBtn.TabIndex = 0;
            this.RefreshBtn.Text = "Refresh list";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // SendCmdBtn
            // 
            this.SendCmdBtn.Location = new System.Drawing.Point(307, 532);
            this.SendCmdBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SendCmdBtn.Name = "SendCmdBtn";
            this.SendCmdBtn.Size = new System.Drawing.Size(121, 25);
            this.SendCmdBtn.TabIndex = 10;
            this.SendCmdBtn.Text = "Send command";
            this.SendCmdBtn.UseVisualStyleBackColor = true;
            // 
            // CmdBox
            // 
            this.CmdBox.Location = new System.Drawing.Point(16, 532);
            this.CmdBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdBox.Name = "CmdBox";
            this.CmdBox.Size = new System.Drawing.Size(281, 22);
            this.CmdBox.TabIndex = 9;
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(16, 341);
            this.LogBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(411, 183);
            this.LogBox.TabIndex = 8;
            this.LogBox.Text = "";
            // 
            // CtrlBox
            // 
            this.CtrlBox.Controls.Add(this.OscSaveOptsBtn);
            this.CtrlBox.Controls.Add(this.label12);
            this.CtrlBox.Controls.Add(this.OscSavePathBox);
            this.CtrlBox.Controls.Add(this.OutOscDataCheckBtn);
            this.CtrlBox.Controls.Add(this.BrowseOscSavePathBtn);
            this.CtrlBox.Controls.Add(this.AvgDataCheckBtn);
            this.CtrlBox.Controls.Add(this.AvgNoBox);
            this.CtrlBox.Controls.Add(this.label11);
            this.CtrlBox.Controls.Add(this.ChannelBox);
            this.CtrlBox.Controls.Add(this.label1);
            this.CtrlBox.Location = new System.Drawing.Point(16, 85);
            this.CtrlBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CtrlBox.Name = "CtrlBox";
            this.CtrlBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CtrlBox.Size = new System.Drawing.Size(412, 248);
            this.CtrlBox.TabIndex = 11;
            this.CtrlBox.TabStop = false;
            this.CtrlBox.Text = "Control";
            // 
            // OscSaveOptsBtn
            // 
            this.OscSaveOptsBtn.Enabled = false;
            this.OscSaveOptsBtn.Location = new System.Drawing.Point(150, 166);
            this.OscSaveOptsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.OscSaveOptsBtn.Name = "OscSaveOptsBtn";
            this.OscSaveOptsBtn.Size = new System.Drawing.Size(113, 28);
            this.OscSaveOptsBtn.TabIndex = 19;
            this.OscSaveOptsBtn.Text = "Save options";
            this.OscSaveOptsBtn.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 203);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 16);
            this.label12.TabIndex = 20;
            this.label12.Text = "Save path";
            // 
            // OscSavePathBox
            // 
            this.OscSavePathBox.Enabled = false;
            this.OscSavePathBox.Location = new System.Drawing.Point(97, 199);
            this.OscSavePathBox.Margin = new System.Windows.Forms.Padding(4);
            this.OscSavePathBox.Name = "OscSavePathBox";
            this.OscSavePathBox.Size = new System.Drawing.Size(197, 22);
            this.OscSavePathBox.TabIndex = 24;
            // 
            // OutOscDataCheckBtn
            // 
            this.OutOscDataCheckBtn.AutoSize = true;
            this.OutOscDataCheckBtn.Enabled = false;
            this.OutOscDataCheckBtn.Location = new System.Drawing.Point(10, 171);
            this.OutOscDataCheckBtn.Margin = new System.Windows.Forms.Padding(4);
            this.OutOscDataCheckBtn.Name = "OutOscDataCheckBtn";
            this.OutOscDataCheckBtn.Size = new System.Drawing.Size(97, 20);
            this.OutOscDataCheckBtn.TabIndex = 28;
            this.OutOscDataCheckBtn.Text = "Output data";
            this.OutOscDataCheckBtn.UseVisualStyleBackColor = true;
            // 
            // BrowseOscSavePathBtn
            // 
            this.BrowseOscSavePathBtn.Enabled = false;
            this.BrowseOscSavePathBtn.Location = new System.Drawing.Point(306, 196);
            this.BrowseOscSavePathBtn.Margin = new System.Windows.Forms.Padding(4);
            this.BrowseOscSavePathBtn.Name = "BrowseOscSavePathBtn";
            this.BrowseOscSavePathBtn.Size = new System.Drawing.Size(100, 28);
            this.BrowseOscSavePathBtn.TabIndex = 22;
            this.BrowseOscSavePathBtn.Text = "Browse";
            this.BrowseOscSavePathBtn.UseVisualStyleBackColor = true;
            // 
            // AvgDataCheckBtn
            // 
            this.AvgDataCheckBtn.AutoSize = true;
            this.AvgDataCheckBtn.Enabled = false;
            this.AvgDataCheckBtn.Location = new System.Drawing.Point(10, 75);
            this.AvgDataCheckBtn.Margin = new System.Windows.Forms.Padding(4);
            this.AvgDataCheckBtn.Name = "AvgDataCheckBtn";
            this.AvgDataCheckBtn.Size = new System.Drawing.Size(119, 20);
            this.AvgDataCheckBtn.TabIndex = 27;
            this.AvgDataCheckBtn.Text = "Averaged data";
            this.AvgDataCheckBtn.UseVisualStyleBackColor = true;
            // 
            // AvgNoBox
            // 
            this.AvgNoBox.Enabled = false;
            this.AvgNoBox.Location = new System.Drawing.Point(118, 103);
            this.AvgNoBox.Margin = new System.Windows.Forms.Padding(4);
            this.AvgNoBox.Name = "AvgNoBox";
            this.AvgNoBox.Size = new System.Drawing.Size(41, 22);
            this.AvgNoBox.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 107);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 16);
            this.label11.TabIndex = 25;
            this.label11.Text = "No. of averages";
            // 
            // ChannelBox
            // 
            this.ChannelBox.Enabled = false;
            this.ChannelBox.Location = new System.Drawing.Point(118, 24);
            this.ChannelBox.Margin = new System.Windows.Forms.Padding(4);
            this.ChannelBox.Name = "ChannelBox";
            this.ChannelBox.Size = new System.Drawing.Size(41, 22);
            this.ChannelBox.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Channel";
            // 
            // OscTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 571);
            this.Controls.Add(this.CtrlBox);
            this.Controls.Add(this.SendCmdBtn);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.CmdBox);
            this.Controls.Add(this.LogBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Button OscSaveOptsBtn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox OscSavePathBox;
        private System.Windows.Forms.CheckBox OutOscDataCheckBtn;
        private System.Windows.Forms.Button BrowseOscSavePathBtn;
        private System.Windows.Forms.CheckBox AvgDataCheckBtn;
        private System.Windows.Forms.TextBox AvgNoBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ChannelBox;
        private System.Windows.Forms.Label label1;
    }
}