using Ivi.Visa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentControl.Instruments
{
    internal class HP5412x
    {
        string GpibAddress { get; }
        private bool initialized = false;
        private IMessageBasedSession visa = null;

        public HP5412x(int address)
        {
            GpibAddress = String.Format("GPIB0::{0}::INSTR", address);
            string res = "";
            try
            {
                (visa, res) = VisaUtil.InitInstrument(GpibAddress);
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

        public void GetNormalMeasurement(int channel)
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
            VisaUtil.SendCmd(visa, "ACQ:TYPE NORM;POINTS 1028");

            // Digitize the specified channel
            var msg = String.Format("DIG CHAN{0}", channel);
            VisaUtil.SendCmd(visa, msg);

            // Set the memory from which the data will be loaded and specify ASCII form for data
            msg = String.Format("WAV: SOUR WMEM {0}; FORM ASCII", channel);
            VisaUtil.SendCmd(visa, msg);

            // Get data
            var data = VisaUtil.SendReceiveFloatArrayCmd(visa, "WAV:DATA?", 1024);
            // TODO: postprocessing
            return; 
        }

        public void GetAveragedMeasurement(int channel, int avgCount)
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
            // TODO: postprocessing
            return;
        }
    }
}
