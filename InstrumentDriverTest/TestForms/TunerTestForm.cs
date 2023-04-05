using InstrumentDriverTest.Instruments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrumentDriverTest.TestForms
{
    public partial class TunerTestForm : Form
    {

        List<MauryTunerDriver> tuners;

        public TunerTestForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            EnableBtns(false);
            //string tunerModel = "MT982EU30";
            // Model used is MT986B02 
            //string ctrlModel = "MT986B02";

            CtrlDriverBox.Text = "C:\\Users\\korisnik\\Desktop\\Maury\\MLibV04\\Drivers\\Tun986.dll";
            TunerCharFileBox.Text = "C:\\Users\\korisnik\\Downloads\\Tuner files\\to send\\to send\\karakterizacija_fund_2400MHz_all.tun";

            TunerSelectBox.Items.Add("Input tuner");
            TunerSelectBox.Items.Add("Output tuner");
            TunerSelectBox.SelectedIndex = 1;

            TunerSelectCtrlBox.Items.Add("Input tuner");
            TunerSelectCtrlBox.Items.Add("Output tuner");
            TunerSelectCtrlBox.SelectedIndex = 1;
            tuners = new List<MauryTunerDriver>(2);
        }

        private void BrowseCtrlDriverPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Controller driver";
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    CtrlDriverBox.Text = openFileDialog.FileName;
                }
            }
        }

        private void BrowseTunerCharFileBtn_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Tuner characterization file";
                openFileDialog.Filter = "(*.tun)";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    CtrlDriverBox.Text = openFileDialog.FileName;
                }
            }
        }

        private void BrowseExeFileBtn_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Executable for tuenr control";
                openFileDialog.Filter = "(*.exe)";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    CtrlDriverBox.Text = openFileDialog.FileName;
                }
            }
        }

        private void SendCmdBtn_Click(object sender, EventArgs e)
        {

        }

        void EnableBtns(bool enable)
        {
            MoveTunerReflRPhiBtn.Enabled = enable;
            MoveTunerReflRIBtn.Enabled = enable;
            MoveTunerZBtn.Enabled = enable;
        }

        private void ReadmeBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Note: Values for tuner controller serial number and model " +
                "as well as tuners' model and serial numbers are hard coded. Input tuner " +
                "has serial number 1331 and output tuner has serial number 1333.", "README", MessageBoxButtons.OK);
        }

        private void InitBtn_Click(object sender, EventArgs e)
        {
        }

        private void TunerSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TunerSelectBox.SelectedIndex == 1) 
            {
                TunerCharFileBox.Text = "C:\\Users\\korisnik\\Downloads\\Tuner files\\to send\\to send\\karakterizacija_fund_2400MHz_all.tun";
            }
            else
            {
                TunerCharFileBox.Text = "Other file path";
            }
        }


        private void MoveTunerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double Zreal = double.Parse(ZRealBox.Text, CultureInfo.InvariantCulture.NumberFormat);
                double Zimag = double.Parse(ZImagBox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Complex Z = new Complex(Zreal, Zimag);
                double freq = double.Parse(FreqBox.Text, CultureInfo.InvariantCulture.NumberFormat);
                int tunerNumber = TunerSelectCtrlBox.SelectedIndex;

            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
                LogBox.AppendText(ex.StackTrace.ToString() + Environment.NewLine);
            }

        }

        private void MoveTunerReflRIBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double gammaReal = double.Parse(GammaRealBox.Text, CultureInfo.InvariantCulture.NumberFormat);
                double gammaImag = double.Parse(GammaImagBox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Complex gamma = new Complex(gammaReal, gammaImag);
                double freq = double.Parse(FreqBox.Text, CultureInfo.InvariantCulture.NumberFormat);
                int tunerNumber = TunerSelectCtrlBox.SelectedIndex;

            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
                LogBox.AppendText(ex.StackTrace.ToString() + Environment.NewLine);
            }

        }

        private void MoveTunerReflRPhiBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double radius = double.Parse(GammaRadiusBox.Text, CultureInfo.InvariantCulture.NumberFormat);
                double angle = double.Parse(GammaAngleBox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Complex gamma = new Complex(radius*Math.Cos(angle), radius*Math.Sin(angle));
                double freq = double.Parse(FreqBox.Text, CultureInfo.InvariantCulture.NumberFormat);
                int tunerNumber = TunerSelectCtrlBox.SelectedIndex;

            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
                LogBox.AppendText(ex.StackTrace.ToString() + Environment.NewLine);
            }

        }
    }
}
