using Ivi.Visa;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace InstrumentDriverTest.Instruments
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
            if (!initialized)
            {
                throw new Exception("Instrument not initialized");
            }
        }

        public (List<double>, List<double>) GetNormalMeasurement(int channel)
        {
            if(!initialized)
            {
                throw new Exception("Instrument not initialized");
            }

            if (channel > 3 ||channel < 1)
            {
                throw new Exception("Device only has 3 channels");
            }

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
            // TODO: postprocessing

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
            foreach(var y in intData)
            {
                yOutput.Add(Yinc * (((double)y) - Yref  ) + Yor );
                xOutput.Add(Xinc * (baseX - Xref) + Xor );
            }

            return (xOutput, yOutput); 
        }

        public (List<double>, List<double>) GetAveragedMeasurement(int channel, int avgCount)
        {
            if (!initialized)
            {
                throw new Exception("Instrument not initialized");
            }

            if (channel > 3 || channel < 1)
            {
                throw new Exception("Device only has 3 channels");
            }

            // Set normal acquisition type with 1024 points
            VisaUtil.SendCmd(visa, "ACQ:TYPE AVER;POINTS 1024;COUNT 1024");

            // Digitize the specified channel
            var msg = String.Format("DIG CHAN{0}", channel);
            VisaUtil.SendCmd(visa, msg);

            // Set the memory from which the data will be loaded and specify ASCII form for data
            msg = String.Format("WAV: SOUR WMEM {0}; FORM ASCII", channel);
            VisaUtil.SendCmd(visa, msg);

            // Get data
            var data = VisaUtil.SendReceiveFloatArrayCmd(visa, "WAV:DATA?", 1024);
            var intData = Array.ConvertAll<string, int>(data.Split(','), Convert.ToInt32);
            // TODO: postprocessing

            msg = String.Format("WAV: SOUR WMEM{0};PRE?");
            var preamble = VisaUtil.SendReceiveStringCmd(visa, msg);
            var Xinc = preamble[4];
            var Xor = preamble[5];
            var Xref = preamble[6];
            var Yinc = preamble[7];
            var Yor = preamble[8];
            var Yref = preamble[9];
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
    }
}
