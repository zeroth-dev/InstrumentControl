using Ivi.Visa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentDriverTest.Instruments
{
    internal class E44xxB
    {
        public string gpibAddress { get; }
        private bool initialized = false;
        public IMessageBasedSession visa = null;

        public E44xxB(string gpibAddress)
        {
            this.gpibAddress = gpibAddress;
            string res = "";
            try
            {
                (visa, res) = VisaUtil.InitInstrument(gpibAddress);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            initialized = true;
        }

        // Set CW frequency

        public void setCWFrequency(double frequency, string freqBand)
        {
            if (!initialized)
            {
                throw new Exception("Instrument not initialized");
            }
            var msg = String.Format("FREQ {0} {1}", frequency, freqBand);
            VisaUtil.SendCmd(visa, msg);
        }

        // Set CW power
        public void setCWPower(double power)
        {
            if (!initialized)
            {
                throw new Exception("Instrument not initialized");
            }

            var msg = String.Format("POW:AMPL {0}", power);
            VisaUtil.SendCmd(visa, msg);
        }

        // TODO Add an instrument defined sweep

        // Turn on
        public void turnOn()
        {
            if (!initialized)
            {
                throw new Exception("Instrument not initialized");
            }
            VisaUtil.SendCmd(visa, "OUTP:STAT ON");
        }

        // Turn off
        public void turnOff()
        {
            if (!initialized)
            {
                throw new Exception("Instrument not initialized");
            }
            VisaUtil.SendCmd(visa, "OUTP:STAT OFF");
        }
    }

}
