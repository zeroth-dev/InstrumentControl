using Ivi.Visa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentControl.Instruments
{
    internal class N9000A
    {
        string GpibAddress { get; }
        private bool initialized = false;
        private IMessageBasedSession visa = null;

        public N9000A(int address)
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
            VisaUtil.SendCmd(visa, "INST:SEL SA");
        }

        public void SetCentralFrequency(int frequency, int bandwith, string freqBand)
        {
            if (!initialized)
            {
                throw new Exception("Instrument is not initialized");
            }

            if (frequency < 0 || bandwith < 0) 
            {
                throw new ArgumentOutOfRangeException("Frequency and bandwith cannot be negative");
            }

            var msg = string.Format("FREQ:CENT {0} {1}", frequency, freqBand);
            VisaUtil.SendCmd(visa, msg);
            msg = string.Format("FREQ:SPAN {0} {1}", bandwith, freqBand);
            VisaUtil.SendCmd(visa, msg);
        }

        public void SetStartStopFrequency(int startFreq, int stopFreq, string freqBandStart, string freqBandStop)
        {
            if (!initialized)
            {
                throw new Exception("Instrument is not initialized");
            }

            if (startFreq < 0 || stopFreq < 0)
            {
                throw new ArgumentOutOfRangeException("Start and stop frequencies cannot be negative");
            }

            var msg = string.Format("FREQ:START {0} {1}", startFreq, freqBandStart);
            VisaUtil.SendCmd(visa, msg);
            msg = string.Format("FREQ:STOP {0} {1}", stopFreq, freqBandStop);
            VisaUtil.SendCmd(visa, msg);
        }
        public double MeasCentralPower()
        {
            if (!initialized)
            {
                throw new Exception("Instrument is not initialized");
            }

            double measurement = VisaUtil.SendReceiveFloatCmd(visa, "CALC:MARK1:CENT");
            return measurement;

        }

        // TODO CALC:DATA:PEAKS
    }
}
