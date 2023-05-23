using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentDriverTest.InstrumentDrivers.Oscilloscope
{
    internal class MSO7034B : Oscilloscope
    {
        public MSO7034B(string gpibAddress) : base(gpibAddress) { }

        public override List<double> GetFFT(int channel)
        {
            throw new NotImplementedException();
        }

        public override double GetPeakFFTAtFreq(int channel, double frequency, string freqBand)
        {
            try
            {
                var msg = String.Format("FUNCTION:GOFT:SOURCE{0}", channel.ToString());
                VisaUtil.SendCmd(visa, msg);
                msg = String.Format("FUNCTION:OPERATION FFT");
                VisaUtil.SendCmd(visa, msg);

                msg = String.Format("MARKER:X1Y1source MATH");
                VisaUtil.SendCmd(visa, msg);
                msg = String.Format("MARKER:X1POSITION {0} {1}", frequency.ToString(), freqBand);
                VisaUtil.SendCmd(visa, msg);


                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override double GetPeakToPeak(int channel)
        {
            try
            {
                var msg = String.Format("MEASURE:VPP? {0}", channel.ToString());
                double vpp = VisaUtil.SendReceiveFloatCmd(visa, msg);
                return vpp;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override (List<double>, List<double>) GetWaveform(int channel, AcquisitionType acquisitionType, UInt16 count = 0)
        {
            try
            {

                var msg = String.Format("WAVEFORM:SOURCE CHAN{0}", channel.ToString());
                VisaUtil.SendCmd(visa, msg);

                // Set 1000 points for gathering
                msg = String.Format("WAVEFORM:POINTS 1000");
                VisaUtil.SendCmd(visa, msg);

                // Specify ASCII form for data
                msg = String.Format("WAVEFORM:FORMAT ASCII");
                VisaUtil.SendCmd(visa, msg);

                // Set Acquisition type
                msg = String.Format("ACQUIRE:TYPE {0}", GetNameFromAcquisitionType(acquisitionType));
                VisaUtil.SendCmd(visa, msg);

                // Set number of averages if that mode is selected
                if (acquisitionType == AcquisitionType.AVERAGE)
                {
                    msg = String.Format("ACQUIRE:COUNT {0}", count.ToString());
                }

                // Get timebase
                msg = String.Format("TIMEBASE:RANGE?");
                var timebaseString = VisaUtil.SendReceiveStringCmd(visa, msg);
                var timebaseArr = timebaseString.Split(' ');
                double timeSize = 0;
                switch (timebaseArr[1])
                {
                    case "s":
                        timeSize = 1;
                        break;
                    case "ms":
                        timeSize = 1000;
                        break;
                    case "us":
                        timeSize = 1e6;
                        break;
                    case "ns":
                        timeSize = 1e9;
                        break;
                    default: timeSize = 0; 
                        break;
                }
                double timebase = Double.Parse(timebaseArr[0], CultureInfo.InvariantCulture.NumberFormat) / timeSize;

                // Get data
                var data = VisaUtil.SendReceiveFloatArrayCmd(visa, "WAVEFORM:DATA?", 8192);
                var intData = Array.ConvertAll<string, int>(data.Split(','), Convert.ToInt32);
                // TODO: postprocessing

                // Xinc, Xor, Yinc, Yor, Yref, Xref, Yref
                List<double> preambleData = GetPreamble();
                //
                //value = (Waveform - Yref) * Yinc + Yor;
                //
                //time = 1:length(value);
                //time = (time - Xref) * Xinc + Xor;
                List<double> yOutput = new List<double>();
                List<double> xOutput = new List<double>();
                List<double> baseX = Util.Range(0, intData.Length);
                for (int i = 0; i < intData.Length; i++)
                {
                    var y = intData[i];
                    yOutput.Add(preambleData[2] * (((double)y) - preambleData[4]) + preambleData[3]);
                    xOutput.Add(preambleData[0] * (baseX[i] - preambleData[5]) + preambleData[1]);
                }
                return (xOutput, yOutput);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override List<double> GetPreamble()
        {
            try
            {
                var msg = String.Format("WAVEFORM:PREAMBLE");
                var preamble = VisaUtil.SendReceiveStringCmd(visa, msg);
                var preambleNums = preamble.Split(',');
                var Xinc = double.Parse(preambleNums[4], System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat);
                var Xor = double.Parse(preambleNums[5], System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat);
                var Xref = double.Parse(preambleNums[6], System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat);
                var Yinc = double.Parse(preambleNums[7], System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat);
                var Yor = double.Parse(preambleNums[8], System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat);
                var Yref = double.Parse(preambleNums[9], System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat);

                List<double> data = new List<double>
                {
                    Xinc, Xinc, Xor, Yinc, Yor, Yref, Xref, Yref
                };
            }
            catch (Exception e)
            {
                throw e;
            }
            return new List<double>();
        }

        public override void SaveImage(string filename)
        {
            try
            {
                visa.TimeoutMilliseconds = 15000;
                var msg = "DISPlay:DATA? PNG, SCReen, COLor";
                var img = VisaUtil.SendReceiveByteArray(visa, msg);

                File.WriteAllBytes(filename, img);
            }
            catch(Exception e) 
            { 
                throw e; 
            }
        }
    }
}
