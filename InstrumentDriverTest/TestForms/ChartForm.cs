using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace InstrumentDriverTest.TestForms
{
    public partial class ChartForm : Form
    {

        DataTable dt;
        Series ser;
        public ChartForm(List<double> xValues, List<Double> yValues)
        {
            InitializeComponent();
            var chart = new Chart();

            chart.ChartAreas.Add(new ChartArea());

            ser = new Series();
            dt = new DataTable();
            dt.Columns.Add("Time", typeof(double));
            dt.Columns.Add("Voltage", typeof(double));
            for (int i = 0; i < xValues.Count; i++)
            {
                dt.Rows.Add(xValues[i], yValues[i]);
                ser.Points.AddXY(xValues[i], yValues[i]);
            }
            chart.Series.Add(ser);

            chart.Location = new System.Drawing.Point(10, 10);
            chart.Size = new System.Drawing.Size(500, 400);

            this.Controls.Add(chart);
        }
    }
}
