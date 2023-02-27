namespace InstrumentDriverTest
{
    partial class MainApp
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
            this.exitBtn = new System.Windows.Forms.Button();
            this.TestOscBtn = new System.Windows.Forms.Button();
            this.TestSpectAnBtn = new System.Windows.Forms.Button();
            this.TestDCBtn = new System.Windows.Forms.Button();
            this.TestVNABtn = new System.Windows.Forms.Button();
            this.GenBtn = new System.Windows.Forms.Button();
            this.TestRFSrcBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(106, 175);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.exitBtn.Size = new System.Drawing.Size(140, 23);
            this.exitBtn.TabIndex = 0;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // TestOscBtn
            // 
            this.TestOscBtn.Location = new System.Drawing.Point(181, 81);
            this.TestOscBtn.Name = "TestOscBtn";
            this.TestOscBtn.Size = new System.Drawing.Size(140, 23);
            this.TestOscBtn.TabIndex = 1;
            this.TestOscBtn.Text = "Test oscilloscope";
            this.TestOscBtn.UseVisualStyleBackColor = true;
            this.TestOscBtn.Click += new System.EventHandler(this.TestOscBtn_Click);
            // 
            // TestSpectAnBtn
            // 
            this.TestSpectAnBtn.Location = new System.Drawing.Point(181, 123);
            this.TestSpectAnBtn.Name = "TestSpectAnBtn";
            this.TestSpectAnBtn.Size = new System.Drawing.Size(140, 23);
            this.TestSpectAnBtn.TabIndex = 2;
            this.TestSpectAnBtn.Text = "Test spectrum analyzer";
            this.TestSpectAnBtn.UseVisualStyleBackColor = true;
            this.TestSpectAnBtn.Click += new System.EventHandler(this.TestSpectAnBtn_Click);
            // 
            // TestDCBtn
            // 
            this.TestDCBtn.Location = new System.Drawing.Point(35, 123);
            this.TestDCBtn.Name = "TestDCBtn";
            this.TestDCBtn.Size = new System.Drawing.Size(140, 23);
            this.TestDCBtn.TabIndex = 3;
            this.TestDCBtn.Text = "Test DC power supply";
            this.TestDCBtn.UseVisualStyleBackColor = true;
            this.TestDCBtn.Click += new System.EventHandler(this.TestDCBtn_Click);
            // 
            // TestVNABtn
            // 
            this.TestVNABtn.Location = new System.Drawing.Point(35, 81);
            this.TestVNABtn.Name = "TestVNABtn";
            this.TestVNABtn.Size = new System.Drawing.Size(140, 23);
            this.TestVNABtn.TabIndex = 4;
            this.TestVNABtn.Text = "Test VNA";
            this.TestVNABtn.UseVisualStyleBackColor = true;
            this.TestVNABtn.Click += new System.EventHandler(this.TestVNABtn_Click);
            // 
            // GenBtn
            // 
            this.GenBtn.Location = new System.Drawing.Point(35, 35);
            this.GenBtn.Name = "GenBtn";
            this.GenBtn.Size = new System.Drawing.Size(140, 23);
            this.GenBtn.TabIndex = 5;
            this.GenBtn.Text = "Generic communication";
            this.GenBtn.UseVisualStyleBackColor = true;
            this.GenBtn.Click += new System.EventHandler(this.GenBtn_Click);
            // 
            // TestRFSrcBtn
            // 
            this.TestRFSrcBtn.Location = new System.Drawing.Point(181, 35);
            this.TestRFSrcBtn.Name = "TestRFSrcBtn";
            this.TestRFSrcBtn.Size = new System.Drawing.Size(140, 23);
            this.TestRFSrcBtn.TabIndex = 6;
            this.TestRFSrcBtn.Text = "Test RF power source";
            this.TestRFSrcBtn.UseVisualStyleBackColor = true;
            this.TestRFSrcBtn.Click += new System.EventHandler(this.TestRFSrcBtn_Click);
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 215);
            this.Controls.Add(this.TestRFSrcBtn);
            this.Controls.Add(this.GenBtn);
            this.Controls.Add(this.TestVNABtn);
            this.Controls.Add(this.TestDCBtn);
            this.Controls.Add(this.TestSpectAnBtn);
            this.Controls.Add(this.TestOscBtn);
            this.Controls.Add(this.exitBtn);
            this.Name = "MainApp";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button TestOscBtn;
        private System.Windows.Forms.Button TestSpectAnBtn;
        private System.Windows.Forms.Button TestDCBtn;
        private System.Windows.Forms.Button TestVNABtn;
        private System.Windows.Forms.Button GenBtn;
        private System.Windows.Forms.Button TestRFSrcBtn;
    }
}

