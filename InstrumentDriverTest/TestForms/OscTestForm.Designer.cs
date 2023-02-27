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
            this.ChannelBox = new System.Windows.Forms.TextBox();
            this.ChannelLabel = new System.Windows.Forms.Label();
            this.AvgNumLabel = new System.Windows.Forms.Label();
            this.AvgNoBox = new System.Windows.Forms.TextBox();
            this.GetAvgDataBtn = new System.Windows.Forms.Button();
            this.GetNormDataBtn = new System.Windows.Forms.Button();
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
            this.groupBox5.Size = new System.Drawing.Size(309, 51);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Init";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(228, 17);
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
            this.InstrumentList.Size = new System.Drawing.Size(135, 21);
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
            this.SendCmdBtn.Location = new System.Drawing.Point(230, 432);
            this.SendCmdBtn.Name = "SendCmdBtn";
            this.SendCmdBtn.Size = new System.Drawing.Size(91, 20);
            this.SendCmdBtn.TabIndex = 10;
            this.SendCmdBtn.Text = "Send command";
            this.SendCmdBtn.UseVisualStyleBackColor = true;
            // 
            // CmdBox
            // 
            this.CmdBox.Location = new System.Drawing.Point(12, 432);
            this.CmdBox.Name = "CmdBox";
            this.CmdBox.Size = new System.Drawing.Size(212, 20);
            this.CmdBox.TabIndex = 9;
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(12, 215);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(309, 211);
            this.LogBox.TabIndex = 8;
            this.LogBox.Text = "";
            // 
            // CtrlBox
            // 
            this.CtrlBox.Controls.Add(this.ChannelBox);
            this.CtrlBox.Controls.Add(this.ChannelLabel);
            this.CtrlBox.Controls.Add(this.AvgNumLabel);
            this.CtrlBox.Controls.Add(this.AvgNoBox);
            this.CtrlBox.Controls.Add(this.GetAvgDataBtn);
            this.CtrlBox.Controls.Add(this.GetNormDataBtn);
            this.CtrlBox.Location = new System.Drawing.Point(12, 69);
            this.CtrlBox.Name = "CtrlBox";
            this.CtrlBox.Size = new System.Drawing.Size(309, 140);
            this.CtrlBox.TabIndex = 11;
            this.CtrlBox.TabStop = false;
            this.CtrlBox.Text = "Control";
            // 
            // ChannelBox
            // 
            this.ChannelBox.Location = new System.Drawing.Point(58, 25);
            this.ChannelBox.Name = "ChannelBox";
            this.ChannelBox.Size = new System.Drawing.Size(32, 20);
            this.ChannelBox.TabIndex = 5;
            // 
            // ChannelLabel
            // 
            this.ChannelLabel.AutoSize = true;
            this.ChannelLabel.Location = new System.Drawing.Point(6, 28);
            this.ChannelLabel.Name = "ChannelLabel";
            this.ChannelLabel.Size = new System.Drawing.Size(46, 13);
            this.ChannelLabel.TabIndex = 4;
            this.ChannelLabel.Text = "Channel";
            // 
            // AvgNumLabel
            // 
            this.AvgNumLabel.AutoSize = true;
            this.AvgNumLabel.Location = new System.Drawing.Point(165, 98);
            this.AvgNumLabel.Name = "AvgNumLabel";
            this.AvgNumLabel.Size = new System.Drawing.Size(83, 13);
            this.AvgNumLabel.TabIndex = 3;
            this.AvgNumLabel.Text = "No. of averages";
            // 
            // AvgNoBox
            // 
            this.AvgNoBox.Location = new System.Drawing.Point(127, 95);
            this.AvgNoBox.Name = "AvgNoBox";
            this.AvgNoBox.Size = new System.Drawing.Size(32, 20);
            this.AvgNoBox.TabIndex = 2;
            // 
            // GetAvgDataBtn
            // 
            this.GetAvgDataBtn.Location = new System.Drawing.Point(6, 93);
            this.GetAvgDataBtn.Name = "GetAvgDataBtn";
            this.GetAvgDataBtn.Size = new System.Drawing.Size(115, 23);
            this.GetAvgDataBtn.TabIndex = 1;
            this.GetAvgDataBtn.Text = "Get averaged data";
            this.GetAvgDataBtn.UseVisualStyleBackColor = true;
            this.GetAvgDataBtn.Click += new System.EventHandler(this.GetAvgDataBtn_Click);
            // 
            // GetNormDataBtn
            // 
            this.GetNormDataBtn.Location = new System.Drawing.Point(6, 51);
            this.GetNormDataBtn.Name = "GetNormDataBtn";
            this.GetNormDataBtn.Size = new System.Drawing.Size(115, 23);
            this.GetNormDataBtn.TabIndex = 0;
            this.GetNormDataBtn.Text = "Get pure data";
            this.GetNormDataBtn.UseVisualStyleBackColor = true;
            this.GetNormDataBtn.Click += new System.EventHandler(this.GetNormDataBtn_Click);
            // 
            // OscTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 464);
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
        private System.Windows.Forms.Label AvgNumLabel;
        private System.Windows.Forms.TextBox AvgNoBox;
        private System.Windows.Forms.Button GetAvgDataBtn;
        private System.Windows.Forms.Button GetNormDataBtn;
        private System.Windows.Forms.TextBox ChannelBox;
        private System.Windows.Forms.Label ChannelLabel;
    }
}