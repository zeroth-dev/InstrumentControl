namespace InstrumentDriverTest.TestForms
{
    partial class RFSrcTest
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FreqBandBox = new System.Windows.Forms.ComboBox();
            this.TurnOffBtn = new System.Windows.Forms.Button();
            this.TurnOnBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ApplyBtn = new System.Windows.Forms.Button();
            this.CWFreqBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PowerBox = new System.Windows.Forms.TextBox();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ConnectBtn);
            this.groupBox5.Controls.Add(this.InstrumentList);
            this.groupBox5.Controls.Add(this.RefreshBtn);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(310, 51);
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
            this.SendCmdBtn.Enabled = false;
            this.SendCmdBtn.Location = new System.Drawing.Point(231, 432);
            this.SendCmdBtn.Name = "SendCmdBtn";
            this.SendCmdBtn.Size = new System.Drawing.Size(91, 20);
            this.SendCmdBtn.TabIndex = 11;
            this.SendCmdBtn.Text = "Send command";
            this.SendCmdBtn.UseVisualStyleBackColor = true;
            this.SendCmdBtn.Click += new System.EventHandler(this.SendCmdBtn_Click);
            // 
            // CmdBox
            // 
            this.CmdBox.Location = new System.Drawing.Point(13, 432);
            this.CmdBox.Name = "CmdBox";
            this.CmdBox.Size = new System.Drawing.Size(212, 20);
            this.CmdBox.TabIndex = 10;
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(13, 302);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(309, 124);
            this.LogBox.TabIndex = 9;
            this.LogBox.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FreqBandBox);
            this.groupBox2.Controls.Add(this.TurnOffBtn);
            this.groupBox2.Controls.Add(this.TurnOnBtn);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ApplyBtn);
            this.groupBox2.Controls.Add(this.CWFreqBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.PowerBox);
            this.groupBox2.Location = new System.Drawing.Point(13, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 227);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RF source setup";
            // 
            // FreqBandBox
            // 
            this.FreqBandBox.FormattingEnabled = true;
            this.FreqBandBox.Location = new System.Drawing.Point(135, 50);
            this.FreqBandBox.Name = "FreqBandBox";
            this.FreqBandBox.Size = new System.Drawing.Size(52, 21);
            this.FreqBandBox.TabIndex = 7;
            // 
            // TurnOffBtn
            // 
            this.TurnOffBtn.Enabled = false;
            this.TurnOffBtn.Location = new System.Drawing.Point(19, 184);
            this.TurnOffBtn.Name = "TurnOffBtn";
            this.TurnOffBtn.Size = new System.Drawing.Size(75, 23);
            this.TurnOffBtn.TabIndex = 6;
            this.TurnOffBtn.Text = "Turn Off";
            this.TurnOffBtn.UseVisualStyleBackColor = true;
            this.TurnOffBtn.Click += new System.EventHandler(this.TurnOffBtn_Click);
            // 
            // TurnOnBtn
            // 
            this.TurnOnBtn.Enabled = false;
            this.TurnOnBtn.Location = new System.Drawing.Point(19, 155);
            this.TurnOnBtn.Name = "TurnOnBtn";
            this.TurnOnBtn.Size = new System.Drawing.Size(75, 23);
            this.TurnOnBtn.TabIndex = 4;
            this.TurnOnBtn.Text = "Turn On";
            this.TurnOnBtn.UseVisualStyleBackColor = true;
            this.TurnOnBtn.Click += new System.EventHandler(this.TurnOnBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Set CW";
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.Enabled = false;
            this.ApplyBtn.Location = new System.Drawing.Point(19, 125);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.Size = new System.Drawing.Size(75, 23);
            this.ApplyBtn.TabIndex = 4;
            this.ApplyBtn.Text = "Apply";
            this.ApplyBtn.UseVisualStyleBackColor = true;
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // CWFreqBox
            // 
            this.CWFreqBox.Location = new System.Drawing.Point(19, 50);
            this.CWFreqBox.Name = "CWFreqBox";
            this.CWFreqBox.Size = new System.Drawing.Size(100, 20);
            this.CWFreqBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Set power (dBm)";
            // 
            // PowerBox
            // 
            this.PowerBox.Location = new System.Drawing.Point(19, 89);
            this.PowerBox.Name = "PowerBox";
            this.PowerBox.Size = new System.Drawing.Size(100, 20);
            this.PowerBox.TabIndex = 5;
            // 
            // RFSrcTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 459);
            this.Controls.Add(this.SendCmdBtn);
            this.Controls.Add(this.CmdBox);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Name = "RFSrcTest";
            this.Text = "RFSrcTest";
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox FreqBandBox;
        private System.Windows.Forms.Button TurnOffBtn;
        private System.Windows.Forms.Button TurnOnBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ApplyBtn;
        private System.Windows.Forms.TextBox CWFreqBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PowerBox;
    }
}