namespace InstrumentDriverTest.TestForms
{
    partial class SATestForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SendCmdBtn = new System.Windows.Forms.Button();
            this.CmdBox = new System.Windows.Forms.TextBox();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.FreqBandBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FreqBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.HarmBox = new System.Windows.Forms.TextBox();
            this.BaseHarmBox = new System.Windows.Forms.TextBox();
            this.ScndHarmBox = new System.Windows.Forms.TextBox();
            this.TrdHarmBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ConnectBtn);
            this.groupBox5.Controls.Add(this.InstrumentList);
            this.groupBox5.Controls.Add(this.RefreshBtn);
            this.groupBox5.Location = new System.Drawing.Point(13, 13);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(416, 63);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Init";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(304, 21);
            this.ConnectBtn.Margin = new System.Windows.Forms.Padding(4);
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
            this.InstrumentList.Margin = new System.Windows.Forms.Padding(4);
            this.InstrumentList.Name = "InstrumentList";
            this.InstrumentList.Size = new System.Drawing.Size(179, 24);
            this.InstrumentList.TabIndex = 1;
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Location = new System.Drawing.Point(8, 23);
            this.RefreshBtn.Margin = new System.Windows.Forms.Padding(4);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(100, 28);
            this.RefreshBtn.TabIndex = 0;
            this.RefreshBtn.Text = "Refresh list";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TrdHarmBox);
            this.groupBox1.Controls.Add(this.ScndHarmBox);
            this.groupBox1.Controls.Add(this.BaseHarmBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.HarmBox);
            this.groupBox1.Controls.Add(this.FreqBandBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FreqBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 264);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setup";
            // 
            // SendCmdBtn
            // 
            this.SendCmdBtn.Location = new System.Drawing.Point(304, 514);
            this.SendCmdBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SendCmdBtn.Name = "SendCmdBtn";
            this.SendCmdBtn.Size = new System.Drawing.Size(121, 25);
            this.SendCmdBtn.TabIndex = 10;
            this.SendCmdBtn.Text = "Send command";
            this.SendCmdBtn.UseVisualStyleBackColor = true;
            // 
            // CmdBox
            // 
            this.CmdBox.Location = new System.Drawing.Point(13, 514);
            this.CmdBox.Margin = new System.Windows.Forms.Padding(4);
            this.CmdBox.Name = "CmdBox";
            this.CmdBox.Size = new System.Drawing.Size(281, 22);
            this.CmdBox.TabIndex = 9;
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(13, 354);
            this.LogBox.Margin = new System.Windows.Forms.Padding(4);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(411, 152);
            this.LogBox.TabIndex = 8;
            this.LogBox.Text = "";
            // 
            // FreqBandBox
            // 
            this.FreqBandBox.FormattingEnabled = true;
            this.FreqBandBox.Location = new System.Drawing.Point(162, 56);
            this.FreqBandBox.Margin = new System.Windows.Forms.Padding(4);
            this.FreqBandBox.Name = "FreqBandBox";
            this.FreqBandBox.Size = new System.Drawing.Size(68, 24);
            this.FreqBandBox.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Central frequency";
            // 
            // FreqBox
            // 
            this.FreqBox.Location = new System.Drawing.Point(7, 56);
            this.FreqBox.Margin = new System.Windows.Forms.Padding(4);
            this.FreqBox.Name = "FreqBox";
            this.FreqBox.Size = new System.Drawing.Size(132, 22);
            this.FreqBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Harmonics";
            // 
            // HarmBox
            // 
            this.HarmBox.Location = new System.Drawing.Point(7, 102);
            this.HarmBox.Margin = new System.Windows.Forms.Padding(4);
            this.HarmBox.Name = "HarmBox";
            this.HarmBox.Size = new System.Drawing.Size(132, 22);
            this.HarmBox.TabIndex = 14;
            // 
            // BaseHarmBox
            // 
            this.BaseHarmBox.Location = new System.Drawing.Point(7, 235);
            this.BaseHarmBox.Margin = new System.Windows.Forms.Padding(4);
            this.BaseHarmBox.Name = "BaseHarmBox";
            this.BaseHarmBox.Size = new System.Drawing.Size(72, 22);
            this.BaseHarmBox.TabIndex = 16;
            // 
            // ScndHarmBox
            // 
            this.ScndHarmBox.Location = new System.Drawing.Point(87, 235);
            this.ScndHarmBox.Margin = new System.Windows.Forms.Padding(4);
            this.ScndHarmBox.Name = "ScndHarmBox";
            this.ScndHarmBox.Size = new System.Drawing.Size(72, 22);
            this.ScndHarmBox.TabIndex = 17;
            // 
            // TrdHarmBox
            // 
            this.TrdHarmBox.Location = new System.Drawing.Point(167, 235);
            this.TrdHarmBox.Margin = new System.Windows.Forms.Padding(4);
            this.TrdHarmBox.Name = "TrdHarmBox";
            this.TrdHarmBox.Size = new System.Drawing.Size(72, 22);
            this.TrdHarmBox.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 215);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "1st harm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 215);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "2nd harm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 215);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "3rd harm";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 144);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 25);
            this.button1.TabIndex = 11;
            this.button1.Text = "Measure";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SATestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 549);
            this.Controls.Add(this.SendCmdBtn);
            this.Controls.Add(this.CmdBox);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Name = "SATestForm";
            this.Text = "SATestForm";
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SendCmdBtn;
        private System.Windows.Forms.TextBox CmdBox;
        private System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.ComboBox FreqBandBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FreqBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TrdHarmBox;
        private System.Windows.Forms.TextBox ScndHarmBox;
        private System.Windows.Forms.TextBox BaseHarmBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox HarmBox;
    }
}