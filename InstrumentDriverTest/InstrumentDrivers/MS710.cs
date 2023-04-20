using InstrumentDriverTest.Instruments;
using Ivi.Visa;
using Syncfusion.WinForms.SmithChart;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentDriverTest.InstrumentDrivers
{
    public class MS710
    {
        string gpibAddress { get; }
        private IMessageBasedSession visa = null;

        public MS710(string gpibAddress)
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

        /// <summary>
        /// Set the starting and final frequency for the measurement
        /// </summary>
        /// <param name="startFreq">Starting frequency</param>
        /// <param name="stopFreq">Final frequency</param>
        /// <param name="freqBandStart">Frequency band of the starting frequency</param>
        /// <param name="freqBandStop">Frequency band of the final frequency</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetCentralFrequency(double frequency, string freqBand)
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

        /// <summary>
        /// Measures the power at the central frequency from the SA
        /// </summary>
        /// <returns>Measured power in dBm</returns>
        /// <exception cref="Exception"></exception>
        public double MeasCentralPower()
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

        public double MeasAtFrequency(double frequency, string freqBand)
        {
            try
            {
                SetCentralFrequency(frequency, freqBand);
                return MeasCentralPower();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
