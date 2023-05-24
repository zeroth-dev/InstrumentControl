using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using static InstrumentDriverTest.InstrumentDrivers.Oscilloscope.Oscilloscope;

namespace InstrumentDriverTest.InstrumentDrivers.Oscilloscope
{
    public class MSO7034B : Oscilloscope
    {
        public MSO7034B(string gpibAddress) : base(gpibAddress) { }

        public override (List<double>, List<double>) GetFFT(int channel, AcquisitionType acquisitionType, UInt16 count = 0)
        {
            try
            {

                var msg = String.Format("FUNCTION:GOFT:SOURCE{0}", channel.ToString());
                VisaUtil.SendCmd(visa, msg);
                msg = String.Format("FUNCTION:OPERATION FFT");
                VisaUtil.SendCmd(visa, msg);

                msg = String.Format("WAVEFORM:SOURCE MATH", channel.ToString());
                VisaUtil.SendCmd(visa, msg);

                // Set 1000 points for gathering
                msg = String.Format("WAVEFORM:POINTS 1000");
                VisaUtil.SendCmd(visa, msg);

                // Specify ASCII form for data
                msg = String.Format("WAVEFORM:FORMAT BYTE");
                VisaUtil.SendCmd(visa, msg);

                // Set Acquisition type
                msg = String.Format("ACQUIRE:TYPE {0}", GetNameFromAcquisitionType(acquisitionType));
                VisaUtil.SendCmd(visa, msg);

                // Set number of averages if that mode is selected
                if (acquisitionType == AcquisitionType.AVERAGE)
                {
                    msg = String.Format("ACQUIRE:COUNT {0}", count.ToString());
                }

                // Get data
                var data = VisaUtil.SendReceiveIEEE488_2ByteArray(visa, "WAVEFORM:DATA?");
                // TODO: postprocessing

                // Xinc, Xor, Xref, Yinc, Yor, Yref
                List<double> preambleData = GetPreamble();
                //
                //value = (Waveform - Yref) * Yinc + Yor;
                //
                //time = 1:length(value);
                //time = (time - Xref) * Xinc + Xor;
                List<double> yOutput = new List<double>();
                List<double> xOutput = new List<double>();
                List<double> baseX = Util.Range(0, data.Length - 1);
                for (int i = 0; i < data.Length; i++)
                {
                    var y = data[i];
                    yOutput.Add(preambleData[3] * (((double)y) - preambleData[5]) + preambleData[4]);
                    xOutput.Add(preambleData[0] * (baseX[i] - preambleData[2]) + preambleData[1]);
                }
                return (xOutput, yOutput);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override double GetPeakFFTAtFreq(int channel, double frequency, string freqBand)
        {
            throw new NotImplementedException();
        }

        public override double GetPeakFFT(int channel)
        {
            try
            {
                var msg = String.Format("FUNCTION:GOFT:SOURCE{0}", channel.ToString());
                VisaUtil.SendCmd(visa, msg);
                msg = String.Format("FUNCTION:OPERATION FFT");
                VisaUtil.SendCmd(visa, msg);
                msg = String.Format("MEASURE:VMAX? MATH");
                double peak = VisaUtil.SendReceiveFloatCmd(visa, msg);

                return peak;
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
                var msg = String.Format("MEASURE:VPP? CHANNEL{0}", channel.ToString());
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
                msg = String.Format("WAVEFORM:FORMAT BYTE");
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
                
                double timebase = Double.Parse(timebaseString, System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat);

                // Get data
                var data = VisaUtil.SendReceiveIEEE488_2ByteArray(visa, "WAVEFORM:DATA?");
                // TODO: postprocessing

                // Xinc, Xor, Xref, Yinc, Yor, Yref
                List<double> preambleData = GetPreamble();
                //
                //value = (Waveform - Yref) * Yinc + Yor;
                //
                //time = 1:length(value);
                //time = (time - Xref) * Xinc + Xor;
                List<double> yOutput = new List<double>();
                List<double> xOutput = new List<double>();
                List<double> baseX = Util.Range(0, data.Length-1);
                for (int i = 0; i < data.Length; i++)
                {
                    var y = data[i];
                    yOutput.Add(preambleData[3] * (((double)y) - preambleData[5]) + preambleData[4]);
                    xOutput.Add(preambleData[0] * (baseX[i] - preambleData[2]) + preambleData[1]);
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
                var msg = String.Format("WAVEFORM:PREAMBLE?");
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
                    Xinc, Xor, Xref, Yinc, Yor, Yref
                };
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override byte[] GetImage()
        {
            try
            {
                visa.TimeoutMilliseconds = 15000;
                var msg = "DISPlay:DATA? PNG, SCReen, COLor";
                var img = VisaUtil.SendReceiveIEEE488_2ByteArray(visa, msg);
                return img;
            }
            catch(Exception e) 
            { 
                throw e; 
            }
        }
    }
}
