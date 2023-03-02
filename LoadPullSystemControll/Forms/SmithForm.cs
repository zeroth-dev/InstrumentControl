using Syncfusion.WinForms.SmithChart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadPullSystemControl.Forms
{
    public partial class SmithForm : Form
    {

        LineSeries series;
        public SmithForm()
        {
            InitializeComponent();
            series = new LineSeries();
            series.MarkerVisible = true;
            sfSmithChart1.Series.Add(series);
            series.ResistanceMember = "Resistance";

            series.ReactanceMember = "Reactance";
            sfSmithChart1.Series.Add(series);
        }

        internal void UpdatePoints(List<Complex> smithPoints)
        {
            sfSmithChart1.Series[0].Points.Clear();
            var lineSeries = sfSmithChart1.Series[0] as LineSeries;
            Random random = new Random();
            for (int i = 0; i < smithPoints.Count; i++)
            {
                lineSeries.Points.Add(smithPoints.ElementAt(i).Real, smithPoints.ElementAt(i).Imaginary);
            }
            
        }

    }
}
