using Ivi.Visa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentControl.Instruments
{
    internal class E44xxB
    {
        string GpibAddress { get; }
        private bool initialized = false;
        private IMessageBasedSession visa = null;

        public E44xxB(int address)
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
