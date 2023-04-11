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
using System.Drawing;
using SmithPlot;

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

        Dictionary<(double, string), List<Complex>> deembeddingDataOut = new Dictionary<(double, string), List<Complex>>();
        Dictionary<(double, string), List<Complex>> deembeddingDataIn = new Dictionary<(double, string), List<Complex>>();
        CancellationTokenSource tokenSource;
        CancellationToken token;

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
                rfSource.SetCWFrequency(freq, FreqBandBox.Text);

                inputPower = double.Parse(PowerBox.Text, provider);
                double gain = 0;
                if (PreampGainBox.Text.Length > 0)
                {
                    gain = double.Parse(PreampGainBox.Text, provider);
                }
                rfSource.SetCWPower(inputPower - gain);
                LogText(String.Format("Set RF frequency {0} {1} and power {2} dBm",
                                        freq.ToString(provider), FreqBandBox.Text, (inputPower - gain).ToString(provider)));
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

            if (OutTunerCharFileBox.Text == "" || InTunerCharFileBox.Text == "")
            {
                LogText("Please set both input and output characterization files");
                return;
            }

            if (CtrlDriverBox.Text == "")
            {
                LogText("Please set location of the controller driver");
                return;
            }

            if(TunerInstrumentList.Text == "")
            {
                LogText("Please select the gpib address for the tuner controller");
                return;
            }

            try
            {
                var split = TunerInstrumentList.Text.Split(new char[] {':'}, StringSplitOptions.RemoveEmptyEntries);
                short gpibAddress = short.Parse(split[1]);
                double freq = double.Parse(FreqBox.Text, provider);
                tuner = new MauryTunerDriver(gpibAddress, CtrlDriverBox.Text, InTunerCharFileBox.Text, OutTunerCharFileBox.Text, freq);
            }
            catch (Exception ex)
            {
                LogText(ex.Message);
                return;
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

                Complex Z0 = new Complex(50, 0);
                Complex gamma = (Z - Z0) / (Z + Z0);
                MoveTunerToReflection(inputTuner, gamma, freq, UseDeembeddingCheck.Checked);

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
                double gammaReal = double.Parse(GammaRealBox.Text, provider);
                double gammaImag = double.Parse(GammaImagBox.Text, provider);
                Complex gamma = new Complex(gammaReal, gammaImag);
                double freq = double.Parse(FreqBox.Text, provider);

                bool inputTuner = TunerSelectCtrlBox.SelectedIndex == 0 ? true : false;
                MoveTunerToReflection(inputTuner, gamma, freq, UseDeembeddingCheck.Checked);

            }
            catch (Exception ex)
            {
                LogText(ex.Message);
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
                MoveTunerToReflection(inputTuner, gamma, freq, UseDeembeddingCheck.Checked);

            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
                LogBox.AppendText(ex.StackTrace.ToString() + Environment.NewLine);
            }

        }

        private void MoveTunerToReflection(bool inputTuner, Complex reflection, double freq, bool useDeembedding = true)
        {
            if(inputTuner)
            {
                if(useDeembedding && deembeddingDataIn.ContainsKey((freq, "GHz")))
                {
                    reflection = ConvertInputPoint(reflection, deembeddingDataIn[(freq, "GHz")]);
                }
                tuner.MoveTunerToSmithPosition(inputTuner, reflection, freq);
            }
            else
            {
                if (useDeembedding && deembeddingDataOut.ContainsKey((freq, "GHz")))
                {
                    reflection = ConvertOutputPoint(reflection, deembeddingDataIn[(freq, "GHz")]);
                }
                tuner.MoveTunerToSmithPosition(inputTuner, reflection, freq);

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


        private void GenerateDistributionBtn_Click(object sender, EventArgs e)
        {
            smithPoints = GeneratePoints();
            ViewDistBtn.Enabled = true;
            if(smithForm != null)
            {
                smithForm.ChangePoints(smithPoints, true);
            }
        }

        private void ViewDistBtn_Click(object sender, EventArgs e)
        {
            if (smithPoints == null) return;

            if (smithForm == null)
            {
                smithForm = new SmithForm(smithPoints, true);
            }
            smithForm.Show();
        }

        private void BrowseInputDeEmbeddingDataBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "De-embedding data";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    double freq = double.Parse(CWFreqBox.Text, provider);
                    var data = Utils.GetSParamsFromFile(openFileDialog.FileName, freq, "GHz");
                    deembeddingDataIn.Add((freq, "GHz"), data);
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
                    double freq = double.Parse(CWFreqBox.Text, provider);
                    var data = Utils.GetSParamsFromFile(openFileDialog.FileName, freq, "GHz");
                    deembeddingDataOut.Add((freq, "GHz"), data);
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
            if (dcPowerSupply == null || spectrumAnalyzer == null || tuner == null || rfSource == null)
            {
                LogText("Please initialise all devices before starting the program");
            }

            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;

            // TODO: Create meaningful filename
            string filename = "Output.txt";
            if (FileNameBox.Text != "")
            {
                filename = FileNameBox.Text;
            }

            if (smithPoints == null || smithPoints.Count == 0)
            {
                smithPoints = GeneratePoints();
                ViewDistBtn.Enabled = true;
            }
            

            if(CWFreqBox.Text == "")
            {
                LogText("Please input the wanted frequency");
            }
            double freq = double.Parse(CWFreqBox.Text, provider);

            double attenuation = 0;
            if (AttBox.Text != "")
            {
                attenuation = double.Parse(AttBox.Text, provider);
            }
            string freqBand = FreqBandBox.Text;

            dcPowerSupply.TurnOnOff(true);
            rfSource.TurnOnOff(true);

            // Start the iteration on a separate thread
            if (LoadPullRadio.Checked || SourcePullRadio.Checked)
            {

                ProgressLabel.Text = "0/" + smithPoints.Count;
                using (StreamWriter sw = File.CreateText(filename))
                {
                    sw.WriteLine("gammaX, gammaY, Pin, Pout1, Pout2, Pout3, Vd, Id");
                }
                Task.Factory.StartNew(() =>
                {
                    IterateThroughSmithSingle(freq, attenuation, filename, freqBand, 
                                                SourcePullRadio.Checked, UseDeembeddingCheck.Checked, token);
                }).ContinueWith(_ => { IterationDone(); });
            }
            else if (SourceLoadPullRadio.Checked)
            {

                ProgressLabel.Text = "0/" + smithPoints.Count*smithPoints.Count;
                using (StreamWriter sw = File.CreateText(filename))
                {
                    sw.WriteLine("gammaInX, gammaInY, gammaOutX, gammaOutY, Pin, Pout1, Pout2, Pout3, Vd, Id");
                }
                Task.Factory.StartNew(() =>
                {
                    IterateThroughSmithDouble(freq, attenuation, filename, freqBand,
                                                UseDeembeddingCheck.Checked, token);
                }).ContinueWith(_ => { IterationDone(); });
            }

        }

        public void IterateThroughSmithSingle(double freq, double attenuation, string filename,
                                        string freqBand, bool inputSweep, bool useDeembedding, CancellationToken ct)
        {
            int progress = 0;
            for (int i = 0; i < smithPoints.Count; i++)
            {
                var point = smithPoints.ElementAt(i);

                MoveTunerToReflection(inputSweep, point, freq, useDeembedding);

                // Read three harmonics of the output signal and the power supply readings
                double basePwr, secondPwr, thirdPwr, Vd, Id;
                (basePwr, secondPwr, thirdPwr, Vd, Id) = ReadData(freq, freqBand, attenuation);

                OutputDataSingle(filename, point.Real, point.Imaginary, inputPower, basePwr, secondPwr, thirdPwr, Vd, Id);
                progress++;
                UpdateProgress(progress, smithPoints.Count);
                if (ct.IsCancellationRequested)
                {
                    rfSource.TurnOnOff(false);
                    dcPowerSupply.TurnOnOff(false);
                    return;
                }
            }
        }


        public void IterateThroughSmithDouble(double freq, double attenuation, string filename,
                                        string freqBand, bool useDeembedding,  CancellationToken ct)
        {
            int progress = 0;

            for (int i = 0; i < smithPoints.Count; i++)
            {
                // Set and de-embed a point for the input tuner
                var inputPoint = smithPoints.ElementAt(i);
                MoveTunerToReflection(true, inputPoint, freq);

                for (int j = 0; i < smithPoints.Count; j++)
                {
                    var outputPoint = smithPoints.ElementAt(j);
                    MoveTunerToReflection(false, outputPoint, freq);

                    // Read three harmonics of the output signal and the power supply readings
                    double basePwr, secondPwr, thirdPwr, Vd, Id;
                    (basePwr, secondPwr, thirdPwr, Vd, Id) = ReadData(freq, freqBand, attenuation);

                    OutputDataDouble(filename, inputPoint.Real, inputPoint.Imaginary, outputPoint.Real, outputPoint.Imaginary,
                                        inputPower, basePwr, secondPwr, thirdPwr, Vd, Id);

                    progress++;
                    UpdateProgress(progress, smithPoints.Count * smithPoints.Count);
                    if (ct.IsCancellationRequested)
                    {
                        rfSource.TurnOnOff(false);
                        dcPowerSupply.TurnOnOff(false);
                        return;
                    }
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
            double minAngle = double.Parse(MinAngBox.Text, CultureInfo.InvariantCulture.NumberFormat) * Math.PI / 180;
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
                double currRadius = minRadius + i * deltaR;
                for (int j = 0; j < noAngles; j++)
                {
                    double currAngle = minAngle + j * deltaAng;
                    points.Add(new Complex(currRadius * Math.Cos(currAngle), currRadius * Math.Sin(currAngle)));
                }
            }

            return points;
        }

        private List<Complex> GammaToImpedance(List<Complex> gamma)
        {
            List<Complex> impedance = new List<Complex>();
            var Z0 = new Complex(50, 0);
            for (int i = 0; i < gamma.Count; i++)
            {
                var Z = (gamma[i] + 1) / (1 - gamma[i]);
                impedance.Add(Z);
            }
            return impedance;
        }

        private void OutputDataSingle(string filename, double gammaX, double gammaY, double powerIn, double baseHarmPwr,
                                double scndHarmPwr, double TrdHarmPwr, double vd, double id)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            using (StreamWriter sw = File.AppendText(filename))
            {
                sw.WriteLine(String.Format("{0:0.####} {1:0.####} {2} {3} {4} {5} {6} {7}",
                                            gammaX, gammaY, powerIn, baseHarmPwr, scndHarmPwr,
                                            TrdHarmPwr, vd, id));
            }
        }


        private void OutputDataDouble(string filename, double gammaInX, double gammaInY, double gammaOutX, double gammaOutY,
                                double powerIn, double baseHarmPwr, double scndHarmPwr, double TrdHarmPwr,
                                double vd, double id)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            using (StreamWriter sw = File.AppendText(filename))
            {
                sw.WriteLine(String.Format("{0:0.####} {1:0.####} {2:0.####} {3:0.####} {4} {5} {6} {7} {8} {9}",
                                            gammaInX, gammaInY, gammaOutX, gammaOutY,
                                            powerIn, baseHarmPwr, scndHarmPwr,
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
                TunerInstrumentList.Items.Clear();
                var deviceList = VisaUtil.GetConnectedDeviceList();
                foreach (var device in deviceList)
                {
                    DCInstrumentList.Items.Add(device);
                    RFInstrumentList.Items.Add(device);
                    SAInstrumentList.Items.Add(device);
                    TunerInstrumentList.Items.Add(device);
                }
                DCInstrumentList.SelectedIndex = 0;
                RFInstrumentList.SelectedIndex = 0;
                SAInstrumentList.SelectedIndex = 0;
                TunerInstrumentList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                LogBox.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private void LogText(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(LogText), msg);
                return;
            }
            LogBox.AppendText(msg + Environment.NewLine);
        }

        private void UpdateProgress(int done, int total)
        {

            if (InvokeRequired)
            {
                Invoke(new Action<int, int>(UpdateProgress), done, total);
            }
            ProgressLabel.Text = String.Format("{0}/{1}", done, total);
        }

        private void IterationDone()
        {
            if (token.IsCancellationRequested)
            {
                LogText("Process was cancelled by the user");
            }
            else
            {
                LogText("Process was completed");
            }
            rfSource.TurnOnOff(false);
            dcPowerSupply.TurnOnOff(false);
            deembeddingDataIn.Clear();
            deembeddingDataOut.Clear();

        }

        private void SetText(Control control, string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Control, string>(SetText), control, text);
            }
            control.Text = text;
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

        private (double, double, double, double, double) ReadData(double freq, string freqBand, double attenuation)
        {
            double basePwr = spectrumAnalyzer.MeasPeak(freq, freqBand) + attenuation;
            double secondPwr = spectrumAnalyzer.MeasPeak(2 * freq, freqBand) + attenuation;
            double thirdPwr = spectrumAnalyzer.MeasPeak(3 * freq, freqBand) + attenuation;

            SetText(BaseHarmBox, basePwr.ToString());
            SetText(ScndHarmBox, secondPwr.ToString());
            SetText(TrdHarmBox, thirdPwr.ToString());

            double Vd = dcPowerSupply.ReadVoltage(2);
            double Id = dcPowerSupply.ReadCurrent(2);

            return (basePwr, secondPwr, thirdPwr, Vd, Id);
        }

        private void SaveConfigBtn_Click(object sender, EventArgs e)
        {
            string configFilePath = "";
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "App config file";
                saveFileDialog.Filter = "(*.cfg)|*.cfg";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = "configuration.cfg";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    configFilePath = saveFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }
            using (StreamWriter sw = File.AppendText(configFilePath))
            {
                sw.WriteLine("DCAddress=" + DCInstrumentList.Text);
                sw.WriteLine("RFSourceAddress=" + RFInstrumentList.Text);
                sw.WriteLine("SpectrumAnalyzerAddress=" + SAInstrumentList.Text);
                sw.WriteLine("DCSource1Voltage=" + Src1VoltageBox.Text);
                sw.WriteLine("DCSource1Current=" + Src1CurrentBox.Text);
                sw.WriteLine("DCSource2Voltage=" + Src2VoltageBox.Text);
                sw.WriteLine("DCSource2Current=" + Src2CurrentBox.Text);
                sw.WriteLine("Frequency=" + CWFreqBox.Text);
                sw.WriteLine("FrequencyBand=" + FreqBandBox.Text);
                sw.WriteLine("InputPower=" + PowerBox.Text);
                sw.WriteLine("InputGain=" + PreampGainBox.Text);
                sw.WriteLine("OutputAttenuation=" + AttBox.Text);
                sw.WriteLine("TunerAddress=" + TunerInstrumentList.Text);
                sw.WriteLine("DriverPath=" + CtrlDriverBox.Text);
                sw.WriteLine("InputTunerCharFile=" + InTunerCharFileBox.Text);
                sw.WriteLine("OutputTunerCharFile=" + OutTunerCharFileBox.Text);
            }
        }

        private void LoadConfigBtn_Click(object sender, EventArgs e)
        {
            string configFilePath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "App config file";
                openFileDialog.Filter = "(*.cfg)|*.cfg";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FileName = "configuration.cfg";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    configFilePath = openFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }
            using (StreamReader sr = File.OpenText(configFilePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] split = line.Split('=');
                    SetLoadedData(split);
                }
            }
        }

        private void ClearLogBtn_Click(object sender, EventArgs e)
        {
            LogBox.Clear();
        }

        private void SetLoadedData(string[] data)
        {
            switch (data[0])
            {
                case "DCAddress":
                    DCInstrumentList.Text = data[1]; break;
                case "RFSourceAddress":
                    RFInstrumentList.Text = data[1]; break;
                case "SpectrumAnalyzerAddress":
                    SAInstrumentList.Text = data[1]; break;
                case "DCSource1Voltage":
                    Src1VoltageBox.Text = data[1]; break;
                case "DCSource1Current":
                    Src1CurrentBox.Text = data[1]; break;
                case "DCSource2Voltage":
                    Src2VoltageBox.Text = data[1]; break;
                case "DCSource2Current":
                    Src2CurrentBox.Text = data[1]; break;
                case "Frequency":
                    FreqBox.Text = data[1]; break;
                case "FrequencyBox":
                    FreqBandBox.Text = data[1]; break;
                case "InputPower":
                    PowerBox.Text = data[1]; break;
                case "InputGain":
                    PreampGainBox.Text = data[1]; break;
                case "OutputAttenuation":
                    AttBox.Text = data[1]; break;
                case "TunerAddress":
                    TunerInstrumentList.Text = data[1]; break;
                case "DriverPath":
                    CtrlDriverBox.Text = data[1]; break;
                case "InputTunerCharFile":
                    InTunerCharFileBox.Text = data[1]; break;
                case "OutputTunerCharFile":
                    OutTunerCharFileBox.Text = data[1]; break;
                default: break;
            }
        }

        /////////////////////////////////////////////////////////
        ///////////////////   UTILITY END   /////////////////////
        /////////////////////////////////////////////////////////
    }
}
