namespace SmithPlot
{
    partial class SmithForm
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
            this.DrawPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // DrawPanel
            // 
            this.DrawPanel.BackColor = System.Drawing.Color.White;
            this.DrawPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.DrawPanel.Location = new System.Drawing.Point(12, 12);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(600, 600);
            this.DrawPanel.Paint += DrawPanel_Paint;
            this.DrawPanel.TabIndex = 0;
            // 
            // SmithForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 625);
            this.Controls.Add(this.DrawPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SmithForm";
            this.Text = "Smith plot";
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel DrawPanel;
    }
}

