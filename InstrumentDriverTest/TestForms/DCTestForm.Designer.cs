namespace InstrumentDriverTest.TestForms
{
    partial class DCTestForm
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
            this.Src1VoltageBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TurnOffSrc2Btn = new System.Windows.Forms.Button();
            this.TurnOnSrc2Btn = new System.Windows.Forms.Button();
            this.ApplySrc2Btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Src2CurrentBox = new System.Windows.Forms.TextBox();
            this.Src2VoltageBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TurnOffSrc1Btn = new System.Windows.Forms.Button();
            this.TurnOnSrc1Btn = new System.Windows.Forms.Button();
            this.ApplySrc1btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Src1CurrentBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.InstrumentList = new System.Windows.Forms.ComboBox();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.CmdBox = new System.Windows.Forms.TextBox();
            this.SendCmdBtn = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Src1VoltageBox
            // 
            this.Src1VoltageBox.Location = new System.Drawing.Point(6, 39);
            this.Src1VoltageBox.Name = "Src1VoltageBox";
            this.Src1VoltageBox.Size = new System.Drawing.Size(100, 20);
            this.Src1VoltageBox.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(12, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 227);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DC setup test";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TurnOffSrc2Btn);
            this.groupBox4.Controls.Add(this.TurnOnSrc2Btn);
            this.groupBox4.Controls.Add(this.ApplySrc2Btn);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.Src2CurrentBox);
            this.groupBox4.Controls.Add(this.Src2VoltageBox);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(155, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(148, 202);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Source 2";
            // 
            // TurnOffSrc2Btn
            // 
            this.TurnOffSrc2Btn.Enabled = false;
            this.TurnOffSrc2Btn.Location = new System.Drawing.Point(6, 173);
            this.TurnOffSrc2Btn.Name = "TurnOffSrc2Btn";
            this.TurnOffSrc2Btn.Size = new System.Drawing.Size(75, 23);
            this.TurnOffSrc2Btn.TabIndex = 9;
            this.TurnOffSrc2Btn.Text = "Turn Off";
            this.TurnOffSrc2Btn.UseVisualStyleBackColor = true;
            this.TurnOffSrc2Btn.Click += new System.EventHandler(this.TurnOffSrc2Btn_Click);
            // 
            // TurnOnSrc2Btn
            // 
            this.TurnOnSrc2Btn.Enabled = false;
            this.TurnOnSrc2Btn.Location = new System.Drawing.Point(6, 144);
            this.TurnOnSrc2Btn.Name = "TurnOnSrc2Btn";
            this.TurnOnSrc2Btn.Size = new System.Drawing.Size(75, 23);
            this.TurnOnSrc2Btn.TabIndex = 8;
            this.TurnOnSrc2Btn.Text = "Turn On";
            this.TurnOnSrc2Btn.UseVisualStyleBackColor = true;
            this.TurnOnSrc2Btn.Click += new System.EventHandler(this.TurnOnSrc2Btn_Click);
            // 
            // ApplySrc2Btn
            // 
            this.ApplySrc2Btn.Enabled = false;
            this.ApplySrc2Btn.Location = new System.Drawing.Point(6, 115);
            this.ApplySrc2Btn.Name = "ApplySrc2Btn";
            this.ApplySrc2Btn.Size = new System.Drawing.Size(75, 23);
            this.ApplySrc2Btn.TabIndex = 8;
            this.ApplySrc2Btn.Text = "Apply";
            this.ApplySrc2Btn.UseVisualStyleBackColor = true;
            this.ApplySrc2Btn.Click += new System.EventHandler(this.ApplySrc2Btn_Click);
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
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Set voltage";
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
            this.groupBox3.Controls.Add(this.TurnOffSrc1Btn);
            this.groupBox3.Controls.Add(this.TurnOnSrc1Btn);
            this.groupBox3.Controls.Add(this.ApplySrc1btn);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.Src1CurrentBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.Src1VoltageBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(143, 202);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Source 1";
            // 
            // TurnOffSrc1Btn
            // 
            this.TurnOffSrc1Btn.Enabled = false;
            this.TurnOffSrc1Btn.Location = new System.Drawing.Point(6, 173);
            this.TurnOffSrc1Btn.Name = "TurnOffSrc1Btn";
            this.TurnOffSrc1Btn.Size = new System.Drawing.Size(75, 23);
            this.TurnOffSrc1Btn.TabIndex = 6;
            this.TurnOffSrc1Btn.Text = "Turn Off";
            this.TurnOffSrc1Btn.UseVisualStyleBackColor = true;
            this.TurnOffSrc1Btn.Click += new System.EventHandler(this.TurnOffSrc1Btn_Click);
            // 
            // TurnOnSrc1Btn
            // 
            this.TurnOnSrc1Btn.Enabled = false;
            this.TurnOnSrc1Btn.Location = new System.Drawing.Point(6, 144);
            this.TurnOnSrc1Btn.Name = "TurnOnSrc1Btn";
            this.TurnOnSrc1Btn.Size = new System.Drawing.Size(75, 23);
            this.TurnOnSrc1Btn.TabIndex = 4;
            this.TurnOnSrc1Btn.Text = "Turn On";
            this.TurnOnSrc1Btn.UseVisualStyleBackColor = true;
            this.TurnOnSrc1Btn.Click += new System.EventHandler(this.TurnOnSrc1Btn_Click);
            // 
            // ApplySrc1btn
            // 
            this.ApplySrc1btn.Enabled = false;
            this.ApplySrc1btn.Location = new System.Drawing.Point(6, 114);
            this.ApplySrc1btn.Name = "ApplySrc1btn";
            this.ApplySrc1btn.Size = new System.Drawing.Size(75, 23);
            this.ApplySrc1btn.TabIndex = 4;
            this.ApplySrc1btn.Text = "Apply";
            this.ApplySrc1btn.UseVisualStyleBackColor = true;
            this.ApplySrc1btn.Click += new System.EventHandler(this.ApplySrc1btn_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Set voltage";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ConnectBtn);
            this.groupBox5.Controls.Add(this.InstrumentList);
            this.groupBox5.Controls.Add(this.RefreshBtn);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(309, 51);
            this.groupBox5.TabIndex = 4;
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
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(12, 302);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(309, 124);
            this.LogBox.TabIndex = 5;
            this.LogBox.Text = "";
            // 
            // CmdBox
            // 
            this.CmdBox.Location = new System.Drawing.Point(12, 432);
            this.CmdBox.Name = "CmdBox";
            this.CmdBox.Size = new System.Drawing.Size(212, 20);
            this.CmdBox.TabIndex = 6;
            // 
            // SendCmdBtn
            // 
            this.SendCmdBtn.Location = new System.Drawing.Point(230, 432);
            this.SendCmdBtn.Name = "SendCmdBtn";
            this.SendCmdBtn.Size = new System.Drawing.Size(91, 20);
            this.SendCmdBtn.TabIndex = 7;
            this.SendCmdBtn.Text = "Send command";
            this.SendCmdBtn.UseVisualStyleBackColor = true;
            this.SendCmdBtn.Click += new System.EventHandler(this.SendCmdBtn_Click);
            // 
            // DCTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 464);
            this.Controls.Add(this.SendCmdBtn);
            this.Controls.Add(this.CmdBox);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Name = "DCTestForm";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Src1VoltageBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button TurnOffSrc1Btn;
        private System.Windows.Forms.Button TurnOnSrc1Btn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button ApplySrc2Btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Src2CurrentBox;
        private System.Windows.Forms.TextBox Src2VoltageBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ApplySrc1btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Src1CurrentBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.ComboBox InstrumentList;
        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.TextBox CmdBox;
        private System.Windows.Forms.Button SendCmdBtn;
        private System.Windows.Forms.Button TurnOffSrc2Btn;
        private System.Windows.Forms.Button TurnOnSrc2Btn;
    }
}