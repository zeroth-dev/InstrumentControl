namespace LoadPullSystemControl.Forms
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
            this.sfSmithChart1 = new Syncfusion.WinForms.SmithChart.SfSmithChart();
            this.SuspendLayout();
            // 
            // sfSmithChart1
            // 
            this.sfSmithChart1.AccessibleName = "SfSmithChart";
            this.sfSmithChart1.ColorModel.CustomColors = null;
            this.sfSmithChart1.ColorModel.Palette = Syncfusion.WinForms.SmithChart.ChartColorPalette.Metro;
            this.sfSmithChart1.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.sfSmithChart1.HorizontalAxis.Style.LabelFont = new System.Drawing.Font("Segoe UI", 10F);
            this.sfSmithChart1.Legend.ItemSpacing = 3;
            this.sfSmithChart1.Legend.Spacing = 8;
            this.sfSmithChart1.Legend.Style.LabelFont = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.sfSmithChart1.Location = new System.Drawing.Point(0, 0);
            this.sfSmithChart1.Name = "sfSmithChart1";
            this.sfSmithChart1.RadialAxis.Style.LabelFont = new System.Drawing.Font("Segoe UI", 10F);
            this.sfSmithChart1.Size = new System.Drawing.Size(511, 447);
            this.sfSmithChart1.Style.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.sfSmithChart1.TabIndex = 0;
            this.sfSmithChart1.Text = "Load Pull Points";
            this.sfSmithChart1.TooltipOptions.Font = new System.Drawing.Font("Segoe UI", 10F);
            // 
            // SmithForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 450);
            this.Controls.Add(this.sfSmithChart1);
            this.Name = "SmithForm";
            this.Text = "SmithForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.WinForms.SmithChart.SfSmithChart sfSmithChart1;
    }
}