using LoadPullSystemControl.Forms;
using LoadPullSystemControl.Instruments;
using LoadPullSystemControl.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LoadPullSystemControl
{
    public partial class LoadPullForm : Form
    {

        private E364xA dcPowerSupply;
        private E44xxB rfSource;
        N9000A spectrumAnalyzer;
        MauryTunerDriver tuner;
        List<Complex> smithPoints;

        SmithForm smithForm;
        NumberFormatInfo provider = new NumberFormatInfo();

        double inputPower = 0;

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

        private void ConnectDCBtn_Click(object sender, EventArgs e)
        {
            string gpibAddress = DCInstrumentList.Text;
            try
            {
                dcPowerSupply = new E364xA(gpibAddress);
                LogText("Registered device:");
                LogText(dcPowerSupply.idMsg);
            }
            catch (Exception ex)
            {
                LogText(ex.Message);
                return;
            }

            EnableDcBtns(true);
        }

        private void ApplyDCSrc1btn_Click(object sender, EventArgs e)
        {
            if (dcPowerSupply == null)
            {
                LogText("DC power supply  not initialized!");
                return;
            }

            try
            {
                double voltage = double.Parse(Src1VoltageBox.Text, provider);
                dcPowerSupply.SetVoltageLimit(1, voltage);
                double current = double.Parse(Src1CurrentBox.Text, provider);
                dcPowerSupply.SetCurrentLimit(1, current);
                LogText("Set voltage and current limit for source 1");
            }
            catch (Exception ex)
            {
                LogText(ex.Message);
                return;
            }
        }

        private void ApplyDCSrc2Btn_Click(object sender, EventArgs e)
        {
            if (dcPowerSupply == null)
            {
                LogText("DC power supply not initialized!");
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
                LogBox.AppendText("DC power supply not initialized!\n");
                return;
            }
            try
            {
                bool turnOn = !dcPowerSupply.turnedOn;
                dcPowerSupply.TurnOnOff(turnOn);

                // If we just turned it on, the button say "turn off" and vice-versa
                TurnOnDCSrcBtn.Text = String.Format("Turn {0}", turnOn ? "off" : "on"); 
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
            TurnOnDCSrcBtn.Enabled = enable;
        }

        /////////////////////////////////////////////////////////
        /////////////  DC Power Supply Controls END /////////////
        /////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////
        /////////////    RF Power Source Controls   /////////////
        /////////////////////////////////////////////////////////

        private void ConnectRFBtn_Click(object sender, EventArgs e)
        {
            string gpibAddress = RFInstrumentList.Text;
            try
            {
                rfSource = new E44xxB(gpibAddress);
                LogText("Registered device: ");
                LogText(rfSource.idMsg);
            }
            catch (Exception ex)
            {
                LogText(ex.Message);
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

                inputPower = double.Parse(PowerBox.Text, provider);
                double gain = 0;
                if(PreampGainBox.Text.Length > 0)
                {
                    gain = double.Parse(PreampGainBox.Text, provider);
                }
                rfSource.setCWPower(inputPower - gain);
                LogText(String.Format("Set RF frequency {0} {1} and power {2} dBm", 
                                        freq.ToString(provider), FreqBandBox.Text, (inputPower-gain).ToString(provider)));
            }
            catch (Exception ex)
            {
                LogText(ex.Message + Environment.NewLine);
            }
        }

        private void TurnOnRFBtn_Click(object sender, EventArgs e)
        {
            try
            {
                bool turnOn = !rfSource.turnedOn;
                rfSource.turnOnOff(turnOn);

                // If we just turned it on, the button say "turn off" and vice-versa
                TurnOnDCSrcBtn.Text = String.Format("Turn {0}", turnOn ? "off" : "on");
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
            FreqBandBox.Items.AddRange(list);
        }

        private void EnableRFBtns(bool enable)
        {
            TurnOnRFBtn.Enabled = enable;
            ApplyRFBtn.Enabled = enable;
        }

        /////////////////////////////////////////////////////////
        /////////////  RF Power Source Controls END /////////////
        /////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////
        /////////    Spectrum Analyzer Controls   ///////////////
        /////////////////////////////////////////////////////////

        private void ConnectSABtn_Click(object sender, EventArgs e)
        {
            string gpibAddress = SAInstrumentList.Text;
            try
            {
                spectrumAnalyzer = new N9000A(gpibAddress);
                LogText("Registered device:");
                LogText(spectrumAnalyzer.idMsg);
            }
            catch (Exception ex)
            {
                LogText(ex.Message);
                return;
            }
        }

        /////////////////////////////////////////////////////////
        ///////////////  Spectrum Analyzer END  ////////////////
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
                openFileDialog.Title = "Executable for tuner control";
                openFileDialog.Filter = "(*.exe)";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExeFilePathBox.Text = openFileDialog.FileName;
                }
            }
        }

        private void ReadmeBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Note: Values for tuner controller serial number and model " +
               "as well as tuners' model and serial numbers are hard coded. Input tuner " +
               "has serial number 1331 and output tuner has serial number 1333.", "README", MessageBoxButtons.OK);
        }


        private void BrowseInTunerCharFileBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Tuner characterization file";
                openFileDialog.Filter = "(*.tun)";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    InTunerCharFileBox.Text = openFileDialog.FileName;
                }
            }
        }

        private void BrowseOutTunerCharFileBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Tuner characterization file";
                openFileDialog.Filter = "(*.tun)";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    OutTunerCharFileBox.Text = openFileDialog.FileName;
                }
            }
        }

        private void InitBtn_Click(object sender, EventArgs e)
        {
            // TODO 2
            bool inputTuner = true;
            int serial = inputTuner ? 1331 : 1333;
            int port = inputTuner ? 1 : 2;

            if (ExeFilePathBox.Text.Length == 0)
            {
                tuner = new MauryTunerDriver((short)(port - 1), 0, (short)serial, 2048, 3, 3);
            }
            else
            {
                tuner = new MauryTunerDriver((short)(port - 1), 0, (short)serial, 2048, 3, 3, ExeFilePathBox.Text);
            }

            tuner.InitTuner(CtrlDriverBox.Text, OutTunerCharFileBox.Text, InTunerCharFileBox.Text);
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

                bool inputTuner = TunerSelectCtrlBox.SelectedIndex == 0 ? true : false;
                tuner.MoveTunerToImpedance(inputTuner, Z, freq);

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

                bool inputTuner = TunerSelectCtrlBox.SelectedIndex == 0 ? true : false;
                tuner.MoveTunerToSmithPosition(inputTuner, gamma, freq);

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

                bool inputTuner = TunerSelectCtrlBox.SelectedIndex == 0 ? true : false;
                tuner.MoveTunerToImpedance(inputTuner, gamma, freq);

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
            OutTunerCharFileBox.Text = "C:\\Users\\korisnik\\Downloads\\Tuner files\\to send\\to send\\karakterizacija_fund_2400MHz_all.tun";
            InTunerCharFileBox.Text = "Idk...";

            TunerSelectCtrlBox.Items.Add("Input tuner");
            TunerSelectCtrlBox.Items.Add("Output tuner");
            TunerSelectCtrlBox.SelectedIndex = 1;

        }

        /////////////////////////////////////////////////////////
        ////////////////////   TUNER END   //////////////////////
        /////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////
        /////////////////////   SMITH   /////////////////////////
        /////////////////////////////////////////////////////////


        private void ViewDistBtn_Click(object sender, EventArgs e)
        {
            smithPoints = GeneratePoints();
            
            var impedancePoints = GammaToImpedance(smithPoints);
            if(smithForm == null)
            {
                smithForm = new SmithForm();
            }
            smithForm.UpdatePoints(impedancePoints);
            smithForm.Show();
            
        }

        private void FinalOutSaveOptsBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            string filename = "Output.txt";
            if(FileNameBox.Text != "")
            {
                filename = FileNameBox.Text;
            }

            using (StreamWriter sw = File.CreateText(filename))
            {
                sw.WriteLine("gammaX, gammaY, Pin, Pout1, Pout2, Pout3, Vd, Id");
            }
            int progress = 0;
            if(smithPoints == null || smithPoints.Count == 0)
            {
                smithPoints = GeneratePoints();
            }
            ProgressLabel.Text = "0/" + smithPoints.Count;
            double freq = double.Parse(CWFreqBox.Text, provider);
            double attenuation = double.Parse(AttBox.Text, provider);
            foreach (Complex point in smithPoints)
            {
                tuner.MoveTunerToSmithPosition(false, point, freq);

                double basePwr = spectrumAnalyzer.MeasPeak(freq, FreqBandBox.Text) + attenuation;
                double secondPwr = spectrumAnalyzer.MeasPeak(2 * freq, FreqBandBox.Text) + attenuation;
                double thirdPwr = spectrumAnalyzer.MeasPeak(3 * freq, FreqBandBox.Text) + attenuation;

                BaseHarmBox.Text = basePwr.ToString();
                ScndHarmBox.Text = secondPwr.ToString();
                TrdHarmBox.Text = thirdPwr.ToString();

                double Vd = dcPowerSupply.ReadVoltage(2);
                double Id = dcPowerSupply.ReadCurrent(2);

                OutputData(filename, point.Real, point.Imaginary, inputPower, basePwr, secondPwr, thirdPwr, Vd, Id);

                progress++;
                ProgressLabel.Text = progress + "/" + smithPoints.Count;
            }
            dcPowerSupply.TurnOnOff(false);
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
                    comboBox.Items.Add(device);
                }
                comboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private List<Complex> GeneratePoints()
        {

            double minRadius = double.Parse(MinRadBox.Text, CultureInfo.InvariantCulture.NumberFormat);
            double maxRadius = double.Parse(MaxRadBox.Text, CultureInfo.InvariantCulture.NumberFormat);
            int noRadius = int.Parse(NoOfCircBox.Text, CultureInfo.InvariantCulture.NumberFormat);
            double minAngle = double.Parse(MinAngBox.Text, CultureInfo.InvariantCulture.NumberFormat)*Math.PI/180;
            double maxAngle = double.Parse(MaxAngBox.Text, CultureInfo.InvariantCulture.NumberFormat) * Math.PI / 180;
            int noAngles = int.Parse(NoOfAngBox.Text, CultureInfo.InvariantCulture.NumberFormat);

            var points = new List<Complex>();
            double deltaR = 0;
            if (noRadius > 1)
            {
                deltaR = (maxRadius - minRadius) / (noRadius - 1);
            }
            double deltaAng = 0;
            if (noAngles > 1)
            {
                deltaAng = (maxAngle - minAngle) / (noAngles - 1);
            }
            
            for (int i = 0; i < noRadius; i++)
            {
                double currRadius = minRadius+ i * deltaR;
                for(int j = 0; j < noAngles; j++)
                {
                    double currAngle = minAngle + j * deltaAng;
                    points.Add(new Complex(currRadius*Math.Cos(currAngle), currRadius*Math.Sin(currAngle)));
                }
            }

            return points;
        }

        private List<Complex> GammaToImpedance(List<Complex> gamma)
        {
            List<Complex> impedance = new List<Complex>();
            var Z0 = new Complex(50, 0);
            for(int i = 0; i < gamma.Count;i++)
            {
                var Z = (gamma[i] + 1) / (1 - gamma[i]);
                impedance.Add(Z);
            }
            return impedance;
        }

        private void OutputData(string filename, double gammaX, double gammaY, double powerIn, double baseHarmPwr, 
                                double scndHarmPwr, double TrdHarmPwr, double vd, double id)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            using (StreamWriter sw = File.AppendText(filename))
            {
                sw.WriteLine(String.Format("{0} {1} {2} {3} {4} {5} {6} {7}", gammaX, gammaY, powerIn, baseHarmPwr, scndHarmPwr,
                                                                                TrdHarmPwr, vd, id));
            }
        }


        private void RefreshListBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DCInstrumentList.Items.Clear();
                RFInstrumentList.Items.Clear();
                SAInstrumentList.Items.Clear();
                var deviceList = Instruments.VisaUtil.GetConnectedDeviceList();
                foreach (var device in deviceList)
                {
                    DCInstrumentList.Items.Add(device);
                    RFInstrumentList.Items.Add(device);
                    SAInstrumentList.Items.Add(device);
                }
                DCInstrumentList.SelectedIndex = 0;
                RFInstrumentList.SelectedIndex = 0;
                SAInstrumentList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private void LogText(string msg)
        {
            LogBox.AppendText(msg + Environment.NewLine);
        }


        /////////////////////////////////////////////////////////
        ///////////////////   UTILITY END   /////////////////////
        /////////////////////////////////////////////////////////
    }
}
