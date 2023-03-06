using Ivi.Visa;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace LoadPullSystemControl.Instruments
{
    internal class HP5412x
    {
        string gpibAddress { get; }
        private bool initialized = false;
        private IMessageBasedSession visa = null;

        public HP5412x(string gpibAddress)
        {
            this.gpibAddress = gpibAddress;
            string res = "";
            try
            {
                (visa, res) = VisaUtil.InitInstrument(this.gpibAddress);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            initialized = true;
        }

        public void SetMeasurementType(string measurementType)
        {
            throw new NotImplementedException();
            if (!initialized)
            {
                throw new Exception("Instrument not initialized");
            }
        }

        /// <summary>
        /// Measures signal received by the osciloscope without averaging the data
        /// </summary>
        /// <param name="channel">Channel from which the data is taken</param>
        /// <returns>Two lists of time and amplitude data measured</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public (List<double>, List<double>) GetNormalMeasurement(int channel)
        {
            if(!initialized)
            {
                throw new Exception("Instrument not initialized");
            }

            if (channel > 3 ||channel < 1)
            {
                throw new ArgumentOutOfRangeException("Device only has 3 channels");
            }

            try
            {
                // Set normal acquisition type with 1028 points
                VisaUtil.SendCmd(visa, "ACQ:TYPE NORM;POINTS 1024");

                // Digitize the specified channel
                var msg = String.Format("DIG CHAN{0}", channel);
                VisaUtil.SendCmd(visa, msg);

                // Set the memory from which the data will be loaded and specify ASCII form for data
                msg = String.Format("WAV:SOUR WMEM{0}; FORM ASCII", channel);
                VisaUtil.SendCmd(visa, msg);

                // Get data
                var data = VisaUtil.SendReceiveStringCmd(visa, "WAV:DATA?", 8192);
                var intData = Array.ConvertAll<string, int>(data.Split(','), Convert.ToInt32);
                var test = data.Length;

                msg = String.Format("WAV: SOUR WMEM{0};PRE?", channel);
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
                double baseX = 1.0 / intData.Length;
                foreach (var y in intData)
                {
                    yOutput.Add(Yinc * (((double)y) - Yref) + Yor);
                    xOutput.Add(Xinc * (baseX - Xref) + Xor);
                }
                return (xOutput, yOutput);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Measures signal received by the osciloscope with averaging the data to remove the noise
        /// </summary>
        /// <param name="channel">Channel from which the data is taken</param>
        /// <param name="avgCount">Number of averages to be done</param>
        /// <returns>Two lists of time and amplitude data measured</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public (List<double>, List<double>) GetAveragedMeasurement(int channel, int avgCount)
        {
            if (!initialized)
            {
                throw new Exception("Instrument not initialized");
            }

            if (channel > 3 || channel < 1)
            {
                throw new ArgumentOutOfRangeException("Device only has 3 channels");
            }

            try
            {
                // Set averaging acquisition type with 1024 points
                var msg = String.Format("ACQ:TYPE AVER;POINTS 1024;COUNT {0}", avgCount.ToString());
                VisaUtil.SendCmd(visa, msg);

                // Digitize the specified channel
                msg = String.Format("DIG CHAN{0}", channel);
                VisaUtil.SendCmd(visa, msg);

                // Set the memory from which the data will be loaded and specify ASCII form for data
                msg = String.Format("WAV:SOUR WMEM{0}; FORM ASCII", channel);
                VisaUtil.SendCmd(visa, msg);

                // Get data
                var data = VisaUtil.SendReceiveFloatArrayCmd(visa, "WAV:DATA?", 8192);
                var intData = Array.ConvertAll<string, int>(data.Split(','), Convert.ToInt32);
                // TODO: postprocessing

                msg = String.Format("WAV:SOUR WMEM{0};PRE?", channel);
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
                List<double> baseX = Range(1, intData.Length);
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

        public void SetSensitivity(int channel, double sensitivity)
        {
            throw new NotImplementedException();
            if (!initialized)
            {
                throw new Exception("Instrument not initialized");
            }

            if (channel > 3 || channel < 1)
            {
                throw new Exception("Device only has 3 channels");
            }


        }

        /// <summary>
        /// Utility function that returns a list of linear values increasing by 1 [min, max]
        /// </summary>
        /// <param name="min">Starting number in range</param>
        /// <param name="max">Ending number in range</param>
        /// <returns></returns>
        private List<double> Range(double min, double max)
        {
            List<double> res = new List<double> ();
            for(; min <= max; min++)
            {
                res.Add(min);
            }
            return res;
        }
    }

}
