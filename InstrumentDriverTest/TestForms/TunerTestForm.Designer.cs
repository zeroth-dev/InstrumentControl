namespace InstrumentDriverTest.TestForms
{
    partial class TunerTestForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ZImagBox = new System.Windows.Forms.TextBox();
            this.ZRealBox = new System.Windows.Forms.TextBox();
            this.MoveTunerBtn = new System.Windows.Forms.Button();
            this.BrowseTunerCharFileBtn = new System.Windows.Forms.Button();
            this.TunerCharFileBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BrowseCtrlDriverPathBtn = new System.Windows.Forms.Button();
            this.CtrlDriverBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.SendCmdBtn.Click += new System.EventHandler(this.SendCmdBtn_Click);
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
            this.LogBox.Location = new System.Drawing.Point(12, 280);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(309, 146);
            this.LogBox.TabIndex = 8;
            this.LogBox.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ZImagBox);
            this.groupBox1.Controls.Add(this.ZRealBox);
            this.groupBox1.Controls.Add(this.MoveTunerBtn);
            this.groupBox1.Controls.Add(this.BrowseTunerCharFileBtn);
            this.groupBox1.Controls.Add(this.TunerCharFileBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.BrowseCtrlDriverPathBtn);
            this.groupBox1.Controls.Add(this.CtrlDriverBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 205);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Imaginary";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Real";
            // 
            // ZImagBox
            // 
            this.ZImagBox.Location = new System.Drawing.Point(162, 92);
            this.ZImagBox.Name = "ZImagBox";
            this.ZImagBox.Size = new System.Drawing.Size(71, 20);
            this.ZImagBox.TabIndex = 18;
            // 
            // ZRealBox
            // 
            this.ZRealBox.Location = new System.Drawing.Point(85, 92);
            this.ZRealBox.Name = "ZRealBox";
            this.ZRealBox.Size = new System.Drawing.Size(71, 20);
            this.ZRealBox.TabIndex = 17;
            // 
            // MoveTunerBtn
            // 
            this.MoveTunerBtn.Location = new System.Drawing.Point(6, 91);
            this.MoveTunerBtn.Name = "MoveTunerBtn";
            this.MoveTunerBtn.Size = new System.Drawing.Size(75, 23);
            this.MoveTunerBtn.TabIndex = 16;
            this.MoveTunerBtn.Text = "Move tuner";
            this.MoveTunerBtn.UseVisualStyleBackColor = true;
            this.MoveTunerBtn.Click += new System.EventHandler(this.MoveTunerBtn_Click);
            // 
            // BrowseTunerCharFileBtn
            // 
            this.BrowseTunerCharFileBtn.Location = new System.Drawing.Point(231, 45);
            this.BrowseTunerCharFileBtn.Name = "BrowseTunerCharFileBtn";
            this.BrowseTunerCharFileBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseTunerCharFileBtn.TabIndex = 14;
            this.BrowseTunerCharFileBtn.Text = "Browse";
            this.BrowseTunerCharFileBtn.UseVisualStyleBackColor = true;
            this.BrowseTunerCharFileBtn.Click += new System.EventHandler(this.BrowseTunerCharFileBtn_Click);
            // 
            // TunerCharFileBox
            // 
            this.TunerCharFileBox.Location = new System.Drawing.Point(87, 47);
            this.TunerCharFileBox.Name = "TunerCharFileBox";
            this.TunerCharFileBox.Size = new System.Drawing.Size(138, 20);
            this.TunerCharFileBox.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tuner char file";
            // 
            // BrowseCtrlDriverPathBtn
            // 
            this.BrowseCtrlDriverPathBtn.Location = new System.Drawing.Point(231, 17);
            this.BrowseCtrlDriverPathBtn.Name = "BrowseCtrlDriverPathBtn";
            this.BrowseCtrlDriverPathBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseCtrlDriverPathBtn.TabIndex = 3;
            this.BrowseCtrlDriverPathBtn.Text = "Browse";
            this.BrowseCtrlDriverPathBtn.UseVisualStyleBackColor = true;
            this.BrowseCtrlDriverPathBtn.Click += new System.EventHandler(this.BrowseCtrlDriverPath_Click);
            // 
            // CtrlDriverBox
            // 
            this.CtrlDriverBox.Location = new System.Drawing.Point(87, 19);
            this.CtrlDriverBox.Name = "CtrlDriverBox";
            this.CtrlDriverBox.Size = new System.Drawing.Size(138, 20);
            this.CtrlDriverBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ctrl driver path";
            // 
            // TunerTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 464);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SendCmdBtn);
            this.Controls.Add(this.CmdBox);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.groupBox5);
            this.Name = "TunerTestForm";
            this.Text = "TunerTestForm";
            this.groupBox5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BrowseCtrlDriverPathBtn;
        private System.Windows.Forms.TextBox CtrlDriverBox;
        private System.Windows.Forms.Button BrowseTunerCharFileBtn;
        private System.Windows.Forms.TextBox TunerCharFileBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ZImagBox;
        private System.Windows.Forms.TextBox ZRealBox;
        private System.Windows.Forms.Button MoveTunerBtn;
        private System.Windows.Forms.Label label4;
    }
}