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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.InitBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TunerSelectBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TunerCharFileBox = new System.Windows.Forms.TextBox();
            this.BrowseTunerCharFileBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ReadmeBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ExeFilePathBox = new System.Windows.Forms.TextBox();
            this.BrowseExeFileBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CtrlDriverBox = new System.Windows.Forms.TextBox();
            this.BrowseCtrlDriverPathBtn = new System.Windows.Forms.Button();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.GammaAngleBox = new System.Windows.Forms.TextBox();
            this.GammaRadiusBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.GammaImagBox = new System.Windows.Forms.TextBox();
            this.GammaRealBox = new System.Windows.Forms.TextBox();
            this.MoveTunerReflRPhiBtn = new System.Windows.Forms.Button();
            this.MoveTunerReflRIBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.TunerSelectCtrlBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ZImagBox = new System.Windows.Forms.TextBox();
            this.ZRealBox = new System.Windows.Forms.TextBox();
            this.MoveTunerZBtn = new System.Windows.Forms.Button();
            this.FreqBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(514, 297);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Init";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.InitBtn);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.TunerSelectBox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.TunerCharFileBox);
            this.groupBox3.Controls.Add(this.BrowseTunerCharFileBtn);
            this.groupBox3.Location = new System.Drawing.Point(9, 130);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(499, 132);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tuner";
            // 
            // InitBtn
            // 
            this.InitBtn.Location = new System.Drawing.Point(205, 103);
            this.InitBtn.Name = "InitBtn";
            this.InitBtn.Size = new System.Drawing.Size(75, 23);
            this.InitBtn.TabIndex = 17;
            this.InitBtn.Text = "Init";
            this.InitBtn.UseVisualStyleBackColor = true;
            this.InitBtn.Click += new System.EventHandler(this.InitBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Select tuner";
            // 
            // TunerSelectBox
            // 
            this.TunerSelectBox.FormattingEnabled = true;
            this.TunerSelectBox.Location = new System.Drawing.Point(87, 27);
            this.TunerSelectBox.Name = "TunerSelectBox";
            this.TunerSelectBox.Size = new System.Drawing.Size(121, 21);
            this.TunerSelectBox.TabIndex = 0;
            this.TunerSelectBox.SelectedIndexChanged += new System.EventHandler(this.TunerSelectBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tuner char file";
            // 
            // TunerCharFileBox
            // 
            this.TunerCharFileBox.Location = new System.Drawing.Point(87, 72);
            this.TunerCharFileBox.Name = "TunerCharFileBox";
            this.TunerCharFileBox.Size = new System.Drawing.Size(325, 20);
            this.TunerCharFileBox.TabIndex = 15;
            // 
            // BrowseTunerCharFileBtn
            // 
            this.BrowseTunerCharFileBtn.Location = new System.Drawing.Point(418, 69);
            this.BrowseTunerCharFileBtn.Name = "BrowseTunerCharFileBtn";
            this.BrowseTunerCharFileBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseTunerCharFileBtn.TabIndex = 14;
            this.BrowseTunerCharFileBtn.Text = "Browse";
            this.BrowseTunerCharFileBtn.UseVisualStyleBackColor = true;
            this.BrowseTunerCharFileBtn.Click += new System.EventHandler(this.BrowseTunerCharFileBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ReadmeBtn);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.ExeFilePathBox);
            this.groupBox2.Controls.Add(this.BrowseExeFileBtn);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.CtrlDriverBox);
            this.groupBox2.Controls.Add(this.BrowseCtrlDriverPathBtn);
            this.groupBox2.Location = new System.Drawing.Point(9, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 105);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controller";
            // 
            // ReadmeBtn
            // 
            this.ReadmeBtn.Location = new System.Drawing.Point(205, 76);
            this.ReadmeBtn.Name = "ReadmeBtn";
            this.ReadmeBtn.Size = new System.Drawing.Size(75, 23);
            this.ReadmeBtn.TabIndex = 16;
            this.ReadmeBtn.Text = "README";
            this.ReadmeBtn.UseVisualStyleBackColor = true;
            this.ReadmeBtn.Click += new System.EventHandler(this.ReadmeBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Exe file path:";
            // 
            // ExeFilePathBox
            // 
            this.ExeFilePathBox.Location = new System.Drawing.Point(87, 50);
            this.ExeFilePathBox.Name = "ExeFilePathBox";
            this.ExeFilePathBox.Size = new System.Drawing.Size(325, 20);
            this.ExeFilePathBox.TabIndex = 15;
            // 
            // BrowseExeFileBtn
            // 
            this.BrowseExeFileBtn.Location = new System.Drawing.Point(418, 48);
            this.BrowseExeFileBtn.Name = "BrowseExeFileBtn";
            this.BrowseExeFileBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseExeFileBtn.TabIndex = 14;
            this.BrowseExeFileBtn.Text = "Browse";
            this.BrowseExeFileBtn.UseVisualStyleBackColor = true;
            this.BrowseExeFileBtn.Click += new System.EventHandler(this.BrowseExeFileBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Driver path:";
            // 
            // CtrlDriverBox
            // 
            this.CtrlDriverBox.Location = new System.Drawing.Point(87, 24);
            this.CtrlDriverBox.Name = "CtrlDriverBox";
            this.CtrlDriverBox.Size = new System.Drawing.Size(325, 20);
            this.CtrlDriverBox.TabIndex = 12;
            // 
            // BrowseCtrlDriverPathBtn
            // 
            this.BrowseCtrlDriverPathBtn.Location = new System.Drawing.Point(418, 22);
            this.BrowseCtrlDriverPathBtn.Name = "BrowseCtrlDriverPathBtn";
            this.BrowseCtrlDriverPathBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseCtrlDriverPathBtn.TabIndex = 3;
            this.BrowseCtrlDriverPathBtn.Text = "Browse";
            this.BrowseCtrlDriverPathBtn.UseVisualStyleBackColor = true;
            this.BrowseCtrlDriverPathBtn.Click += new System.EventHandler(this.BrowseCtrlDriverPath_Click);
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(12, 444);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(514, 215);
            this.LogBox.TabIndex = 8;
            this.LogBox.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.FreqBox);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.GammaAngleBox);
            this.groupBox1.Controls.Add(this.GammaRadiusBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.GammaImagBox);
            this.groupBox1.Controls.Add(this.GammaRealBox);
            this.groupBox1.Controls.Add(this.MoveTunerReflRPhiBtn);
            this.groupBox1.Controls.Add(this.MoveTunerReflRIBtn);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TunerSelectCtrlBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ZImagBox);
            this.groupBox1.Controls.Add(this.ZRealBox);
            this.groupBox1.Controls.Add(this.MoveTunerZBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 280);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 158);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(156, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Angle [rad]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Radius";
            // 
            // GammaAngleBox
            // 
            this.GammaAngleBox.Location = new System.Drawing.Point(214, 123);
            this.GammaAngleBox.Name = "GammaAngleBox";
            this.GammaAngleBox.Size = new System.Drawing.Size(71, 20);
            this.GammaAngleBox.TabIndex = 28;
            // 
            // GammaRadiusBox
            // 
            this.GammaRadiusBox.Location = new System.Drawing.Point(76, 123);
            this.GammaRadiusBox.Name = "GammaRadiusBox";
            this.GammaRadiusBox.Size = new System.Drawing.Size(71, 20);
            this.GammaRadiusBox.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(156, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Imaginary";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Real";
            // 
            // GammaImagBox
            // 
            this.GammaImagBox.Location = new System.Drawing.Point(214, 94);
            this.GammaImagBox.Name = "GammaImagBox";
            this.GammaImagBox.Size = new System.Drawing.Size(71, 20);
            this.GammaImagBox.TabIndex = 24;
            // 
            // GammaRealBox
            // 
            this.GammaRealBox.Location = new System.Drawing.Point(76, 94);
            this.GammaRealBox.Name = "GammaRealBox";
            this.GammaRealBox.Size = new System.Drawing.Size(71, 20);
            this.GammaRealBox.TabIndex = 23;
            // 
            // MoveTunerReflRPhiBtn
            // 
            this.MoveTunerReflRPhiBtn.Location = new System.Drawing.Point(297, 121);
            this.MoveTunerReflRPhiBtn.Name = "MoveTunerReflRPhiBtn";
            this.MoveTunerReflRPhiBtn.Size = new System.Drawing.Size(87, 23);
            this.MoveTunerReflRPhiBtn.TabIndex = 22;
            this.MoveTunerReflRPhiBtn.Text = "Set reflection";
            this.MoveTunerReflRPhiBtn.UseVisualStyleBackColor = true;
            this.MoveTunerReflRPhiBtn.Click += new System.EventHandler(this.MoveTunerReflRPhiBtn_Click);
            // 
            // MoveTunerReflRIBtn
            // 
            this.MoveTunerReflRIBtn.Location = new System.Drawing.Point(297, 92);
            this.MoveTunerReflRIBtn.Name = "MoveTunerReflRIBtn";
            this.MoveTunerReflRIBtn.Size = new System.Drawing.Size(87, 23);
            this.MoveTunerReflRIBtn.TabIndex = 21;
            this.MoveTunerReflRIBtn.Text = "Set reflection";
            this.MoveTunerReflRIBtn.UseVisualStyleBackColor = true;
            this.MoveTunerReflRIBtn.Click += new System.EventHandler(this.MoveTunerReflRIBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Select tuner";
            // 
            // TunerSelectCtrlBox
            // 
            this.TunerSelectCtrlBox.FormattingEnabled = true;
            this.TunerSelectCtrlBox.Location = new System.Drawing.Point(76, 29);
            this.TunerSelectCtrlBox.Name = "TunerSelectCtrlBox";
            this.TunerSelectCtrlBox.Size = new System.Drawing.Size(121, 21);
            this.TunerSelectCtrlBox.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Imaginary";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Real";
            // 
            // ZImagBox
            // 
            this.ZImagBox.Location = new System.Drawing.Point(214, 62);
            this.ZImagBox.Name = "ZImagBox";
            this.ZImagBox.Size = new System.Drawing.Size(71, 20);
            this.ZImagBox.TabIndex = 18;
            // 
            // ZRealBox
            // 
            this.ZRealBox.Location = new System.Drawing.Point(76, 62);
            this.ZRealBox.Name = "ZRealBox";
            this.ZRealBox.Size = new System.Drawing.Size(71, 20);
            this.ZRealBox.TabIndex = 17;
            // 
            // MoveTunerZBtn
            // 
            this.MoveTunerZBtn.Location = new System.Drawing.Point(297, 60);
            this.MoveTunerZBtn.Name = "MoveTunerZBtn";
            this.MoveTunerZBtn.Size = new System.Drawing.Size(87, 23);
            this.MoveTunerZBtn.TabIndex = 16;
            this.MoveTunerZBtn.Text = "Set impedance";
            this.MoveTunerZBtn.UseVisualStyleBackColor = true;
            this.MoveTunerZBtn.Click += new System.EventHandler(this.MoveTunerBtn_Click);
            // 
            // FreqBox
            // 
            this.FreqBox.Location = new System.Drawing.Point(285, 29);
            this.FreqBox.Name = "FreqBox";
            this.FreqBox.Size = new System.Drawing.Size(71, 20);
            this.FreqBox.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(221, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Freq [GHz]";
            // 
            // TunerTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 671);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.groupBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TunerTestForm";
            this.Text = "TunerTestForm";
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
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
        private System.Windows.Forms.Button MoveTunerZBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ExeFilePathBox;
        private System.Windows.Forms.Button BrowseExeFileBtn;
        private System.Windows.Forms.Button ReadmeBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox TunerSelectBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox TunerSelectCtrlBox;
        private System.Windows.Forms.Button InitBtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox GammaAngleBox;
        private System.Windows.Forms.TextBox GammaRadiusBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox GammaImagBox;
        private System.Windows.Forms.TextBox GammaRealBox;
        private System.Windows.Forms.Button MoveTunerReflRPhiBtn;
        private System.Windows.Forms.Button MoveTunerReflRIBtn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox FreqBox;
    }
}