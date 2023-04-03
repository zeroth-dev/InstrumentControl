namespace Measurement_Application
{
    partial class MainForm
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
            this.AppListBox = new System.Windows.Forms.ComboBox();
            this.MainStartBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AppListBox
            // 
            this.AppListBox.FormattingEnabled = true;
            this.AppListBox.Location = new System.Drawing.Point(99, 87);
            this.AppListBox.Name = "AppListBox";
            this.AppListBox.Size = new System.Drawing.Size(121, 21);
            this.AppListBox.TabIndex = 0;
            // 
            // MainStartBtn
            // 
            this.MainStartBtn.Location = new System.Drawing.Point(124, 145);
            this.MainStartBtn.Name = "MainStartBtn";
            this.MainStartBtn.Size = new System.Drawing.Size(75, 23);
            this.MainStartBtn.TabIndex = 1;
            this.MainStartBtn.Text = "Start";
            this.MainStartBtn.UseVisualStyleBackColor = true;
            this.MainStartBtn.Click += new System.EventHandler(this.MainStartBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 249);
            this.Controls.Add(this.MainStartBtn);
            this.Controls.Add(this.AppListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Measurement Application";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox AppListBox;
        private System.Windows.Forms.Button MainStartBtn;
    }
}

