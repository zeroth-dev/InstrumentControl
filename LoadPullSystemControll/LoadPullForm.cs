using LoadPullSystemControl.Forms;
using LoadPullSystemControl.Instruments;
using LoadPullSystemControll.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadPullSystemControl
{
    public partial class LoadPullForm : Form
    {

        private E364xA dcPowerSupply;
        private E44xxB rfSource;
        HP5412x oscilloscope;
        List<MauryTunerDriver> tuners;
        List<Complex> smithPoints;

        SmithForm smithForm;
        NumberFormatInfo provider = new NumberFormatInfo();

        public LoadPullForm()
        {
            InitializeComponent();
            provider.NumberDecimalSeparator = ".";
            InitFreqBandList();
            InitTunerData();
        }

        /////////////////////////////////////////////////////////
        /////////////  DC Power Supply Controls  ////////////////
        /////////////////////////////////////////////////////////
        private void RefreshDCBtn_Click(object sender, EventArgs e)
        {
            FillGpibComboBox(DCInstrumentList);
        }

        private void ConnectDCBtn_Click(object sender, EventArgs e)
        {
            string gpibAddress = DCInstrumentList.Text;
            try
            {
                dcPowerSupply = new E364xA(gpibAddress);
                LogBox.AppendText(dcPowerSupply.idMsg + Environment.NewLine);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
                return;
            }

            EnableDcBtns(true);
        }

        private void ApplyDCSrc1btn_Click(object sender, EventArgs e)
        {
            if (dcPowerSupply == null)
            {
                LogBox.AppendText("Instrument not initialized!\n");
                return;
            }

            try
            {
                double voltage = double.Parse(Src1VoltageBox.Text, provider);
                dcPowerSupply.SetVoltageLimit(1, voltage);
                double current = double.Parse(Src1CurrentBox.Text, provider);
                dcPowerSupply.SetCurrentLimit(1, current);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
                return;
            }
        }

        private void ApplyDCSrc2Btn_Click(object sender, EventArgs e)
        {
            if (dcPowerSupply == null)
            {
                LogBox.AppendText("Instrument not initialized!\n");
                return;
            }

            try
            {
                double voltage = double.Parse(Src2VoltageBox.Text, provider);
                dcPowerSupply.SetVoltageLimit(2, voltage);
                double current = double.Parse(Src2CurrentBox.Text, provider);
                dcPowerSupply.SetCurrentLimit(2, current);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
                return;
            }
        }

        private void TurnOnDCSrcBtn_Click(object sender, EventArgs e)
        {

            if (dcPowerSupply == null)
            {
                LogBox.AppendText("Instrument not initialized!\n");
                return;
            }
            try
            {
                dcPowerSupply.TurnOnOff(true);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private void TurnOffDCSrcBtn_Click(object sender, EventArgs e)
        {
            if (dcPowerSupply == null)
            {
                LogBox.AppendText("Instrument not initialized!\n");
                return;
            }
            try
            {
                dcPowerSupply.TurnOnOff(false);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private void EnableDcBtns(bool enable)
        {
            ApplyDCSrc1btn.Enabled = enable;
            ApplyDCSrc2Btn.Enabled = enable;
            TurnOffDCSrcBtn.Enabled = enable;
            TurnOnDCSrcBtn.Enabled = enable;
        }

        /////////////////////////////////////////////////////////
        /////////////  DC Power Supply Controls END /////////////
        /////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////
        /////////////    RF Power Source Controls   /////////////
        /////////////////////////////////////////////////////////

        private void RefreshRFBtn_Click(object sender, EventArgs e)
        {
            FillGpibComboBox(RFInstrumentList);
        }

        private void ConnectRFBtn_Click(object sender, EventArgs e)
        {
            string gpibAddress = RFInstrumentList.Text;
            try
            {
                rfSource = new E44xxB(gpibAddress);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
                return;
            }

            EnableRFBtns(true);
        }


        private void ApplyRFBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double freq = double.Parse(CWFreqBox.Text, provider);
                rfSource.setCWFrequency(freq, FreqBandBox.Text);

                double power = double.Parse(PowerBox.Text, provider);
                double gain = 0;
                if(PreampGainBox.Text.Length > 0)
                {
                    gain = double.Parse(PreampGainBox.Text, provider);
                }
                rfSource.setCWPower(power-gain);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private void TurnOnRFBtn_Click(object sender, EventArgs e)
        {
            try
            {
                rfSource.turnOn();
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private void TurnOffRFBtn_Click(object sender, EventArgs e)
        {
            try
            {
                rfSource.turnOff();
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private void InitFreqBandList()
        {
            string[] list = { "Hz", "kHz", "MHz", "GHz" };
            FreqBandBox.Items.AddRange(list);
        }

        private void EnableRFBtns(bool enable)
        {
            TurnOffRFBtn.Enabled = enable;
            TurnOnRFBtn.Enabled = enable;
            ApplyRFBtn.Enabled = enable;
        }

        /////////////////////////////////////////////////////////
        /////////////  RF Power Source Controls END /////////////
        /////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////
        ///////////////  Osciloscope Controls   /////////////////
        /////////////////////////////////////////////////////////


        private void RefreshOscBtn_Click(object sender, EventArgs e)
        {
            FillGpibComboBox(OscInstrumentList);
        }

        private void ConnectOscBtn_Click(object sender, EventArgs e)
        {
            string gpibAddress = OscInstrumentList.Text;
            try
            {
                oscilloscope = new HP5412x(gpibAddress);
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
                return;
            }

            EnableOscBtns(true);
        }

        private void AvgDataCheckBtn_CheckedChanged(object sender, EventArgs e)
        {
            AvgNoBox.Enabled = AvgDataCheckBtn.Checked;
        }

        private void OutOscDataCheckBtn_CheckedChanged(object sender, EventArgs e)
        {
            OscSaveOptsBtn.Enabled = OutOscDataCheckBtn.Checked;
            BrowseOscSavePathBtn.Enabled = OutOscDataCheckBtn.Checked;
            OscSavePathBox.Enabled = OutOscDataCheckBtn.Checked;
        }

        private void OscSaveOptsBtn_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void BrowseOscSavePathBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    OscSavePathBox.Text = saveFileDialog.FileName;
                }
            }
        }

        private void EnableOscBtns(bool enable)
        {
            OutOscDataCheckBtn.Enabled = enable;
            ChannelBox.Enabled = enable;
            AvgDataCheckBtn.Enabled = enable;
        }


        /////////////////////////////////////////////////////////
        /////////////  Osciloscope Controls END  ////////////////
        /////////////////////////////////////////////////////////



        /////////////////////////////////////////////////////////
        ///////////////////     TUNER       /////////////////////
        /////////////////////////////////////////////////////////


        private void BrowseCtrlDriverPathBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Controller driver";
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

        private void ReadmeBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Note: Values for tuner controller serial number and model " +
               "as well as tuners' model and serial numbers are hard coded. Input tuner " +
               "has serial number 1331 and output tuner has serial number 1333.", "README", MessageBoxButtons.OK);
        }

        private void TunerSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TunerSelectBox.SelectedIndex == 1)
            {
                TunerCharFileBox.Text = "C:\\Users\\korisnik\\Downloads\\Tuner files\\to send\\to send\\karakterizacija_fund_2400MHz_all.tun";
            }
            else
            {
                TunerCharFileBox.Text = "Other file path";
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

        private void InitBtn_Click(object sender, EventArgs e)
        {
            bool inputTuner = TunerSelectBox.Text == "Input tuner";
            int serial = inputTuner ? 1331 : 1333;
            int port = inputTuner ? 1 : 2;

            MauryTunerDriver tuner;
            if (ExeFilePathBox.Text.Length == 0)
            {
                tuner = new MauryTunerDriver((short)(port - 1), 0, (short)serial, 2048, 3, 3);
            }
            else
            {
                tuner = new MauryTunerDriver((short)(port - 1), 0, (short)serial, 2048, 3, 3, ExeFilePathBox.Text);
            }

            tuners.Insert(port - 1, tuner);
            tuner.InitTuner(CtrlDriverBox.Text, TunerCharFileBox.Text, tuners.Count, inputTuner);
            StartBtn.Enabled = true;
        }

        private void MoveTunerZBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double Zreal = double.Parse(ZRealBox.Text, CultureInfo.InvariantCulture.NumberFormat);
                double Zimag = double.Parse(ZImagBox.Text, CultureInfo.InvariantCulture.NumberFormat);
                Complex Z = new Complex(Zreal, Zimag);
                double freq = double.Parse(FreqBox.Text, CultureInfo.InvariantCulture.NumberFormat);
                int tunerNumber = TunerSelectCtrlBox.SelectedIndex;
                tuners.ElementAt(tunerNumber).MoveTunerToImpedance(tunerNumber, Z, freq);

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
                tuners.ElementAt(tunerNumber).MoveTunerToSmithPosition(tunerNumber, gamma, freq);

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
                Complex gamma = new Complex(radius * Math.Cos(angle), radius * Math.Sin(angle));
                double freq = double.Parse(FreqBox.Text, CultureInfo.InvariantCulture.NumberFormat);
                int tunerNumber = TunerSelectCtrlBox.SelectedIndex;
                tuners.ElementAt(tunerNumber).MoveTunerToImpedance(tunerNumber, gamma, freq);

            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
                LogBox.AppendText(ex.StackTrace.ToString() + Environment.NewLine);
            }

        }

        private void InitTunerData()
        {
            //string tunerModel = "MT982EU30";
            // Model used is MT986B02 
            //string ctrlModel = "MT986B02";

            CtrlDriverBox.Text = "C:\\Users\\korisnik\\Desktop\\Maury\\MLibV04\\Drivers\\Tun986.dll";
            TunerCharFileBox.Text = "C:\\Users\\korisnik\\Downloads\\Tuner files\\to send\\to send\\karakterizacija_fund_2400MHz_all.tun";

            TunerSelectBox.Items.Add("Input tuner");
            TunerSelectBox.Items.Add("Output tuner");
            TunerSelectBox.SelectedIndex = 1;

            tuners = new List<MauryTunerDriver>(2);
        }

        /////////////////////////////////////////////////////////
        ////////////////////   TUNER END   //////////////////////
        /////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////
        /////////////////////   SMITH   /////////////////////////
        /////////////////////////////////////////////////////////


        private void ViewDistBtn_Click(object sender, EventArgs e)
        {

            double minRadius = double.Parse(MinRadBox.Text, CultureInfo.InvariantCulture.NumberFormat);
            double maxRadius = double.Parse(MaxRadBox.Text, CultureInfo.InvariantCulture.NumberFormat); 
            int noRadius = int.Parse(NoOfCircBox.Text, CultureInfo.InvariantCulture.NumberFormat);
            double minAngle = double.Parse(MinAngBox.Text, CultureInfo.InvariantCulture.NumberFormat);
            double maxAngle = double.Parse(MaxAngBox.Text, CultureInfo.InvariantCulture.NumberFormat);
            int noAngles = int.Parse(NoOfAngBox.Text, CultureInfo.InvariantCulture.NumberFormat);

            smithPoints = GeneratePoints(minRadius, maxRadius, noRadius, 
                                        minAngle*Math.PI/180, maxAngle*Math.PI / 180, noAngles);
            /*
            if(smithForm == null)
            {
                smithForm = new SmithForm();
            }
            smithForm.UpdatePoints(smithPoints);
            smithForm.Show();
            */
        }

        private void FinalOutSaveOptsBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            foreach(Complex point in smithPoints)
            {
                tuners.ElementAt(1).MoveTunerToSmithPosition(1, point, 2.4);
                // ... TODO
                var (time, amp) = oscilloscope.GetAveragedMeasurement(2, 10);
                using (var file = File.CreateText("Oscilloscope_" + point.Real + "_" + point.Imaginary))
                {
                    file.WriteLine("Time(s), V(V)");
                    for(int i = 0; i < time.Count; i++)
                    {
                        file.WriteLine(string.Format("{0}, {1}", time.ElementAt(i), amp.ElementAt(i)));
                    }
                }
            }
        }


        /////////////////////////////////////////////////////////
        ////////////////////   SMITH END   //////////////////////
        /////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////
        ///////////////////     UTILITY     /////////////////////
        /////////////////////////////////////////////////////////

        private void FillGpibComboBox(ComboBox comboBox)
        {
            try
            {
                comboBox.Items.Clear();
                var deviceList = Instruments.VisaUtil.GetConnectedDeviceList();
                foreach (var device in deviceList)
                {
                    DCInstrumentList.Items.Add(device);
                }
                DCInstrumentList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private List<Complex> GeneratePoints(double minRadius, double maxRadius, int noRadius,
                                                double startAngle, double endAngle, int noAngle)
        {
           
            var points = new List<Complex>();
            return points;
        }

        /////////////////////////////////////////////////////////
        ///////////////////   UTILITY END   /////////////////////
        /////////////////////////////////////////////////////////
    }
}
