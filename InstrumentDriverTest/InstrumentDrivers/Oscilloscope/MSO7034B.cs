using System;
using System.Collections.Generic;
using System.Globalization;
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
            catch(Exception e) 
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
            catch(Exception e)
            {
                throw e;
            }
        }

        public override (List<double>, List<double>) GetWaveform(int channel)
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

                msg = String.Format("WAV:SOUR WMEM{0}; FORM ASCII", channel);
                VisaUtil.SendCmd(visa, msg);

                // Get data
                var data = VisaUtil.SendReceiveFloatArrayCmd(visa, "WAVEFORM:DATA?", 8192);
                var intData = Array.ConvertAll<string, int>(data.Split(','), Convert.ToInt32);
                // TODO: postprocessing

                msg = String.Format("WAVEFORM:PREAMBLE");
                var preamble = VisaUtil.SendReceiveStringCmd(visa, msg);
                var preambleNums = preamble.Split(',');
                var Xinc = double.Parse(preambleNums[4], System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat);
                var Xor = double.Parse(preambleNums[5], System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat);
                var Xref = double.Parse(preambleNums[6], System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat);
                var Yinc = double.Parse(preambleNums[7], System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat);
                var Yor = double.Parse(preambleNums[8], System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat);
                var Yref = double.Parse(preambleNums[9], System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat);
                //
                //value = (Waveform - Yref) * Yinc + Yor;
                //
                //time = 1:length(value);
                //time = (time - Xref) * Xinc + Xor;
                List<double> yOutput = new List<double>();
                List<double> xOutput = new List<double>();
                List<double> baseX = Util.Range(1, intData.Length);
                for (int i = 0; i < intData.Length; i++)
                {
                    var y = intData[i];
                    yOutput.Add(Yinc * (((double)y) - Yref) + Yor);
                    xOutput.Add(Xinc * (baseX[i] - Xref) + Xor);
                }
                return (xOutput, yOutput);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
