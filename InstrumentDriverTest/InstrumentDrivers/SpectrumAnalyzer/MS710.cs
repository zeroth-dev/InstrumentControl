using InstrumentDriverTest.InstrumentDrivers;
using Ivi.Visa;
using Syncfusion.WinForms.SmithChart;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstrumentDriverTest.InstrumentDrivers.SpectrumAnalyzer
{
    public class MS710 : SpectrumAnalyzer
    {
        
        public MS710(string gpibAddress) : base()
        {
            this.gpibAddress = gpibAddress;
            string res = "";
            try
            {
                (visa, res) = VisaUtil.InitInstrument(this.gpibAddress);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public override void SetCentralFrequency(double frequency, string freqBand)
        {

            if (frequency < 0)
            {
                throw new ArgumentOutOfRangeException("Frequency cannot be negative");
            }
            try
            {
                var msg = string.Format("CF{0}{1}", frequency.ToString(CultureInfo.InvariantCulture.NumberFormat), freqBand);
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
                string msg = "PM";
                VisaUtil.SendCmd(visa, msg);
                string measString = VisaUtil.SendReceiveStringCmd(visa, "OM2");
                measString = measString.Substring(2, 7);
                char[] arr = measString.Where(c => (char.IsLetterOrDigit(c) ||
                                                char.IsWhiteSpace(c) ||
                                                c == '-' || c == '.')).ToArray();

                measString = new string(arr);
                return Double.Parse(measString, NumberStyles.None);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void SetStartStopFrequency(int startFreq, int stopFreq, string freqBandStart, string freqBandStop)
        {
            throw new NotImplementedException();
        }

        public override double MeasPeak(double frequency, string freqBand)
        {
            try
            {
                SetCentralFrequency(frequency, freqBand);
                return MeasCentralPower();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void SetSpan(double span, string freqBand)
        {
            throw new NotImplementedException();
        }

        public override void SetBW(double bw, string freqBand)
        {
            throw new NotImplementedException();
        }

        public override double MeasAtFrequency(double frequency, string freqBand)
        {

            throw new NotImplementedException();
        }
    }
}
