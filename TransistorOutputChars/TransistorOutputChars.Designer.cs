namespace TransistorOutputChars
{
    partial class TransistorOutputCharsForm
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
            this.ConnectDCBtn = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.DCInstrumentList = new System.Windows.Forms.ComboBox();
            this.RefreshListBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Src1CurrentBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Src1MinVBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Src1MaxVBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Src1StepVBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Src2StepVBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Src2MaxVBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Src2CurrentBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Src2MinVBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.MaxPowerBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.BrowseSaveFileBtn = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.FileNameBox = new System.Windows.Forms.TextBox();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.groupBox17.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.ConnectDCBtn);
            this.groupBox17.Controls.Add(this.label41);
            this.groupBox17.Controls.Add(this.DCInstrumentList);
            this.groupBox17.Controls.Add(this.RefreshListBtn);
            this.groupBox17.Location = new System.Drawing.Point(12, 12);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(293, 89);
            this.groupBox17.TabIndex = 18;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "GPIB setup";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BrowseSaveFileBtn);
            this.groupBox2.Controls.Add(this.label40);
            this.groupBox2.Controls.Add(this.FileNameBox);
            this.groupBox2.Controls.Add(this.StartBtn);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.MaxPowerBox);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(12, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 227);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DC setup";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.Src1StepVBox);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.Src1MaxVBox);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.Src1CurrentBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.Src1MinVBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(269, 188);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Source 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "A";
            // 
            // Src1CurrentBox
            // 
            this.Src1CurrentBox.Location = new System.Drawing.Point(6, 101);
            this.Src1CurrentBox.Name = "Src1CurrentBox";
            this.Src1CurrentBox.Size = new System.Drawing.Size(75, 20);
            this.Src1CurrentBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Set current";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "V";
            // 
            // Src1MinVBox
            // 
            this.Src1MinVBox.Location = new System.Drawing.Point(6, 58);
            this.Src1MinVBox.Name = "Src1MinVBox";
            this.Src1MinVBox.Size = new System.Drawing.Size(75, 20);
            this.Src1MinVBox.TabIndex = 2;
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Min";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(87, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Max";
            // 
            // Src1MaxVBox
            // 
            this.Src1MaxVBox.Location = new System.Drawing.Point(87, 58);
            this.Src1MaxVBox.Name = "Src1MaxVBox";
            this.Src1MaxVBox.Size = new System.Drawing.Size(75, 20);
            this.Src1MaxVBox.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(168, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Step";
            // 
            // Src1StepVBox
            // 
            this.Src1StepVBox.Location = new System.Drawing.Point(168, 58);
            this.Src1StepVBox.Name = "Src1StepVBox";
            this.Src1StepVBox.Size = new System.Drawing.Size(75, 20);
            this.Src1StepVBox.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Src2StepVBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Src2MaxVBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.Src2CurrentBox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.Src2MinVBox);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(281, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 188);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Step";
            // 
            // Src2StepVBox
            // 
            this.Src2StepVBox.Location = new System.Drawing.Point(168, 58);
            this.Src2StepVBox.Name = "Src2StepVBox";
            this.Src2StepVBox.Size = new System.Drawing.Size(75, 20);
            this.Src2StepVBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Max";
            // 
            // Src2MaxVBox
            // 
            this.Src2MaxVBox.Location = new System.Drawing.Point(87, 58);
            this.Src2MaxVBox.Name = "Src2MaxVBox";
            this.Src2MaxVBox.Size = new System.Drawing.Size(75, 20);
            this.Src2MaxVBox.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Min";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(84, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "A";
            // 
            // Src2CurrentBox
            // 
            this.Src2CurrentBox.Location = new System.Drawing.Point(6, 101);
            this.Src2CurrentBox.Name = "Src2CurrentBox";
            this.Src2CurrentBox.Size = new System.Drawing.Size(75, 20);
            this.Src2CurrentBox.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Set current";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(249, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "V";
            // 
            // Src2MinVBox
            // 
            this.Src2MinVBox.Location = new System.Drawing.Point(6, 58);
            this.Src2MinVBox.Name = "Src2MinVBox";
            this.Src2MinVBox.Size = new System.Drawing.Size(75, 20);
            this.Src2MinVBox.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Set voltage";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(556, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Max power";
            // 
            // MaxPowerBox
            // 
            this.MaxPowerBox.Location = new System.Drawing.Point(556, 77);
            this.MaxPowerBox.Name = "MaxPowerBox";
            this.MaxPowerBox.Size = new System.Drawing.Size(75, 20);
            this.MaxPowerBox.TabIndex = 13;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(637, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(18, 13);
            this.label17.TabIndex = 16;
            this.label17.Text = "W";
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(556, 164);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 25;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // BrowseSaveFileBtn
            // 
            this.BrowseSaveFileBtn.Location = new System.Drawing.Point(662, 121);
            this.BrowseSaveFileBtn.Name = "BrowseSaveFileBtn";
            this.BrowseSaveFileBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseSaveFileBtn.TabIndex = 32;
            this.BrowseSaveFileBtn.Text = "Browse";
            this.BrowseSaveFileBtn.UseVisualStyleBackColor = true;
            this.BrowseSaveFileBtn.Click += new System.EventHandler(this.BrowseSaveFileBtn_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(554, 108);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(52, 13);
            this.label40.TabIndex = 31;
            this.label40.Text = "File name";
            // 
            // FileNameBox
            // 
            this.FileNameBox.Location = new System.Drawing.Point(556, 124);
            this.FileNameBox.Name = "FileNameBox";
            this.FileNameBox.Size = new System.Drawing.Size(100, 20);
            this.FileNameBox.TabIndex = 30;
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(311, 19);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(477, 82);
            this.LogBox.TabIndex = 20;
            this.LogBox.Text = "";
            // 
            // TransistorOutputChars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 350);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox17);
            this.Name = "TransistorOutputChars";
            this.Text = "Output characteristics";
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Button ConnectDCBtn;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.ComboBox DCInstrumentList;
        private System.Windows.Forms.Button RefreshListBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Src2StepVBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Src2MaxVBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Src2CurrentBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox Src2MinVBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Src1StepVBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Src1MaxVBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Src1CurrentBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Src1MinVBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox MaxPowerBox;
        private System.Windows.Forms.Button BrowseSaveFileBtn;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox FileNameBox;
        private System.Windows.Forms.RichTextBox LogBox;
    }
}

