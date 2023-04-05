using LoadPullSystemControl.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Windows.Forms;
using InstrumentDriverTest.Instruments;
using LoadPullSystemControl.Util;
using System.Threading.Tasks;

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

        Dictionary<(double,string), List<Complex>> deembeddingDataOut = new Dictionary<(double, string), List<Complex>>();
        Dictionary<(double,string), List<Complex>> deembeddingDataIn = new Dictionary<(double, string), List<Complex>>();
        CancellationTokenSource tokenSource;
        CancellationToken token;

        public LoadPullForm()
        {
            InitializeComponent();
            provider.NumberDecimalSeparator = ".";
            InitFreqBandList();
            InitTunerData();
            tokenSource= new CancellationTokenSource();
            token = tokenSource.Token;
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
                rfSource.SetCWFrequency(freq, FreqBandBox.Text);

                inputPower = double.Parse(PowerBox.Text, provider);
                double gain = 0;
                if(PreampGainBox.Text.Length > 0)
                {
                    gain = double.Parse(PreampGainBox.Text, provider);
                }
                rfSource.SetCWPower(inputPower - gain);
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
                rfSource.TurnOnOff(turnOn);

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
                openFileDialog.Filter = "(*.exe)|*.exe";
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
                openFileDialog.Filter = "(*.tun)|*.tun";
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
                openFileDialog.Filter = "(*.tun)|*.tun";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    OutTunerCharFileBox.Text = openFileDialog.FileName;
                }
            }
        }

        private void InitBtn_Click(object sender, EventArgs e)
        {
            // These values are meaningless at this point
            // If you figure out how to use MLibTuner.dll 
            // directly you can use them

            //bool inputTuner = true;
            //int serial = inputTuner ? 1331 : 1333;
            //int port = inputTuner ? 1 : 2;

            if(OutTunerCharFileBox.Text == "" || InTunerCharFileBox.Text == "")
            {
                LogText("Please set both input and output characterization files");
                return;
            }

            if(CtrlDriverBox.Text == "")
            {
                LogText("Please set location of the controller driver");
                return;
            }

            try
            {
                tuner = new MauryTunerDriver(3, CtrlDriverBox.Text, InTunerCharFileBox.Text, OutTunerCharFileBox.Text);
            }
            catch(Exception ex)
            {
                LogText(ex.Message);
            }
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
                double gammaReal = double.Parse(GammaRealBox.Text,provider);
                double gammaImag = double.Parse(GammaImagBox.Text, provider);
                Complex gamma = new Complex(gammaReal, gammaImag);
                double freq = double.Parse(FreqBox.Text,provider);

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
            InTunerCharFileBox.Text = "C:\\Users\\korisnik\\Downloads\\Tuner files\\to send\\to send\\load_pull_source_2_4_GHz_DEE.tun";

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

        private void BrowseInputDeEmbeddingDataBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "De-embedding data";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    InputDeEmbeddingDataFileBox.Text = openFileDialog.FileName;
                }
            }
        }

        private void BrowseOutDeEmbeddingDataBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "De-embedding data";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    OutputDeEmbeddingDataFileBox.Text = openFileDialog.FileName;
                }
            }

        }
        
        private void SourceLoadPullRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (SourceLoadPullRadio.Checked)
            {
                SweepChoicePanel.Visible = true;
            }
            else
            {
                SweepChoicePanel.Visible = false;
            }
        }


        private void StartBtn_Click(object sender, EventArgs e)
        {
            // Setup
            if(dcPowerSupply == null || spectrumAnalyzer == null || tuner == null || rfSource == null)
            {
                LogText("Please initialise all devices before starting the program");
            }

            // TODO: Create meaningful filename
            string filename = "Output.txt";
            if(FileNameBox.Text != "")
            {
                filename = FileNameBox.Text;
            }

            using (StreamWriter sw = File.CreateText(filename))
            {
                sw.WriteLine("gammaX, gammaY, Pin, Pout1, Pout2, Pout3, Vd, Id");
            }
            if(smithPoints == null || smithPoints.Count == 0)
            {
                smithPoints = GeneratePoints();
            }
            ProgressLabel.Text = "0/" + smithPoints.Count;
            double freq = double.Parse(CWFreqBox.Text, provider);
            double attenuation = double.Parse(AttBox.Text, provider);
            string freqBand = FreqBandBox.Text;

            if(UseDeembeddingCheck.Checked)
            {
                if(OutputDeEmbeddingDataFileBox.Text != "")
                {
                    deembeddingDataOut.Add((freq,freqBand), Utils.GetSParamsFromFile(OutputDeEmbeddingDataFileBox.Text, freq, freqBand));
                }

            }

            dcPowerSupply.TurnOnOff(true);
            rfSource.TurnOnOff(true);

            // Start the iteration on a separate thread
            Task.Factory.StartNew(() =>
            {
                IterateThroughSmith(freq, attenuation, filename, freqBand, token);
            }).ContinueWith(_ => { IterationDone(); });

        }

        public void IterateThroughSmith(double freq, double attenuation, string filename, string freqBand, CancellationToken ct)
        {
            int progress = 0;
            for (int i = 0; i < smithPoints.Count; i++)
            {
                var point = smithPoints.ElementAt(i);
                if(deembeddingDataOut.ContainsKey((freq, freqBand)))
                {
                    point = ConvertOutputPoint(point, deembeddingDataOut[(freq, freqBand)]);
                }
                tuner.MoveTunerToSmithPosition(false, point, freq);

                double basePwr = spectrumAnalyzer.MeasPeak(freq, freqBand) + attenuation;
                double secondPwr = spectrumAnalyzer.MeasPeak(2 * freq, freqBand) + attenuation;
                double thirdPwr = spectrumAnalyzer.MeasPeak(3 * freq, freqBand) + attenuation;

                SetText(BaseHarmBox, basePwr.ToString());
                SetText(ScndHarmBox, secondPwr.ToString());
                SetText(TrdHarmBox, thirdPwr.ToString());

                double Vd = dcPowerSupply.ReadVoltage(2);
                double Id = dcPowerSupply.ReadCurrent(2);

                OutputData(filename, point.Real, point.Imaginary, inputPower, basePwr, secondPwr, thirdPwr, Vd, Id);

                progress++;
                if(ct.IsCancellationRequested)
                {
                    rfSource.TurnOnOff(false);
                    dcPowerSupply.TurnOnOff(false);
                    return;
                }
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
        }


        /////////////////////////////////////////////////////////
        ////////////////////   SMITH END   //////////////////////
        /////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////
        ///////////////////     UTILITY     /////////////////////
        /////////////////////////////////////////////////////////

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
                var deviceList = VisaUtil.GetConnectedDeviceList();
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
            if(InvokeRequired)
            {
                Invoke(new Action<string>(LogText), msg);
            }
            LogBox.AppendText(msg + Environment.NewLine);
            LogBox.AppendText("\n");
        }

        private void UpdateProgress(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            ProgressLabel.Text = String.Format("{0}/{1}", e.ProgressPercentage, smithPoints.Count);
        }

        private void IterationDone()
        {
            LogText("Process was completed");

            rfSource.TurnOnOff(false);
            dcPowerSupply.TurnOnOff(false);
            
        }

        private void SetText(Control control, string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Control, string>(SetText), control, text);
            }
           control.Text= text;
        }

        private Complex ConvertOutputPoint(Complex point, List<Complex> sParams)
        {
            /* 
             * Assumption for the s-param measurement
             * 
             *                   s21
             *           --->   ------>   ------->
             *                |        / \
             *                |         |
             *  ---->     s11 |         |         ----->   
             *  |             |         |s22      |   Gamma tuner
             *  | Gamma       |         |         |
             *    DUT        \ /        |
             *          <----   <------   <------- 
             *                    s12
             * 
             * 
             */

            Complex numerator = point - sParams[0];
            Complex denominator = sParams[1] * sParams[2] + sParams[3] * (point - sParams[0]);
            return numerator / denominator;
        }

        private Complex ConvertInputPoint(Complex point, List<Complex> sParams)
        {
            /* 
             * Assumption for the s-param measurement
             * 
             *                   s21
             *           --->   ------>   ------->
             *                |        / \
             *                |         |
             *  <----     s11 |         |         <----   
             *      |         |         |s22          | Gamma DUT
             *      |Gamma    |         |             |
             *      |tuner   \ /        |
             *          <----   <------   <------- 
             *                    s12
             * 
             * 
             */

            Complex numerator = point - sParams[3];
            Complex denominator = sParams[1] * sParams[2] + sParams[0] * (point - sParams[3]);
            return numerator / denominator;
        }
        /////////////////////////////////////////////////////////
        ///////////////////   UTILITY END   /////////////////////
        /////////////////////////////////////////////////////////
    }
}
