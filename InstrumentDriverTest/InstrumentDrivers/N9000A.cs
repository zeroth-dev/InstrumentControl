using Ivi.Visa;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstrumentDriverTest.Instruments
{
    internal class N9000A
    {
        string gpibAddress { get; }
        private bool initialized = false;
        private IMessageBasedSession visa = null;

        public N9000A(string gpibAddress)
        {
            this.gpibAddress=gpibAddress;
            string res = "";
            try
            {
                (visa, res) = VisaUtil.InitInstrument(gpibAddress);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            initialized = true;
            VisaUtil.SendCmd(visa, "INST:SEL SA");
            VisaUtil.SendCmd(visa, "FORM:DATA ASCII");
        }

        public void SetCentralFrequency(double frequency, double span, string freqBand)
        {
            if (!initialized)
            {
                throw new Exception("Instrument is not initialized");
            }

            if (frequency < 0 || span < 0) 
            {
                throw new ArgumentOutOfRangeException("Frequency and bandwith cannot be negative");
            }

            var msg = string.Format("FREQ:CENT {0} {1}", frequency.ToString(CultureInfo.InvariantCulture.NumberFormat), freqBand);
            VisaUtil.SendCmd(visa, msg);
            msg = string.Format("FREQ:SPAN {0} {1}", span.ToString(CultureInfo.InvariantCulture.NumberFormat), freqBand);
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
        public double MeasPeak(double frequency, string freqBand)
        {
            if (!initialized)
            {
                throw new Exception("Instrument is not initialized");
            }
            if (frequency < 0)
            {
                throw new ArgumentOutOfRangeException("Frequency cannot be negative");
            }

            SetCentralFrequency(frequency, 0.1, freqBand);

            Thread.Sleep(100);

            var msg = string.Format("CALC:MARK1:MAX");
            VisaUtil.SendCmd(visa, msg);
            Thread.Sleep(100);
            msg = string.Format("CALC:MARK1:Y?");
            double measurement = VisaUtil.SendReceiveFloatCmd(visa, msg);

            return measurement;
        }
    }
}
