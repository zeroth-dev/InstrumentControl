using Ivi.Visa;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstrumentDriverTest.InstrumentDrivers.SpectrumAnalyzer
{
    public class N9000A : SpectrumAnalyzer
    {

        public N9000A(string gpibAddress) : base(gpibAddress)
        {
            VisaUtil.SendCmd(visa, "INST:SEL SA");
            VisaUtil.SendCmd(visa, "FORM:DATA ASCII");
        }

        public override void SetCentralFrequency(double frequency, double span, string freqBand)
        {
            if (frequency < 0 || span < 0)
            {
                throw new ArgumentOutOfRangeException("Frequency and bandwith cannot be negative");
            }

            try
            {
                var msg = string.Format("FREQ:CENT {0} {1}", frequency.ToString(CultureInfo.InvariantCulture.NumberFormat), freqBand);
                VisaUtil.SendCmd(visa, msg);
                msg = string.Format("FREQ:SPAN {0} {1}", span.ToString(CultureInfo.InvariantCulture.NumberFormat), freqBand);
                VisaUtil.SendCmd(visa, msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void SetStartStopFrequency(int startFreq, int stopFreq, string freqBandStart, string freqBandStop)
        {
            if (startFreq < 0 || stopFreq < 0)
            {
                throw new ArgumentOutOfRangeException("Start and stop frequencies cannot be negative");
            }
            try
            {
                var msg = string.Format("FREQ:START {0} {1}", startFreq, freqBandStart);
                VisaUtil.SendCmd(visa, msg);
                msg = string.Format("FREQ:STOP {0} {1}", stopFreq, freqBandStop);
                VisaUtil.SendCmd(visa, msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override double MeasCentralPower()
        {
            try
            {
                double measurement = VisaUtil.SendReceiveFloatCmd(visa, "CALC:MARK1:CENT");
                return measurement;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override double MeasPeak(double frequency, string freqBand)
        {
            if (frequency < 0)
            {
                throw new ArgumentOutOfRangeException("Frequency cannot be negative");
            }

            try
            {
                SetCentralFrequency(frequency, 0.1, freqBand);

                Thread.Sleep(100);
                var msg = string.Format("CALC:MARK1:MAX");
                VisaUtil.SendCmd(visa, msg);
                Thread.Sleep(100);
                msg = string.Format("CALC:MARK1:Y?");
                double measurement = VisaUtil.SendReceiveFloatCmd(visa, msg);

                return measurement;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

