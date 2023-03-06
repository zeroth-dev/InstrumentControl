using Ivi.Visa;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoadPullSystemControl.Instruments
{
    internal class N9000A
    {
        string gpibAddress { get; }
        private bool initialized = false;
        private IMessageBasedSession visa = null;
        public string idMsg { get; }

        public N9000A(string gpibAddress)
        {
            this.gpibAddress = gpibAddress;
            try
            {
                (visa, idMsg) = VisaUtil.InitInstrument(gpibAddress);
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

        /// <summary>
        /// Sets the central frequency and span for the spectral analyzer
        /// </summary>
        /// <param name="frequency">Central frequency for the SA</param>
        /// <param name="span">Span of the display (same frequency band as central frequency) </param>
        /// <param name="freqBand">Frequency band for the specified frequency</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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

            try
            {
                var msg = string.Format("FREQ:CENT {0} {1}", frequency.ToString(CultureInfo.InvariantCulture.NumberFormat), freqBand);
                VisaUtil.SendCmd(visa, msg);
                msg = string.Format("FREQ:SPAN {0} {1}", span.ToString(CultureInfo.InvariantCulture.NumberFormat), freqBand);
                VisaUtil.SendCmd(visa, msg);
            }
            catch(Exception ex)
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

        /// <summary>
        /// Measures the power at the central frequency from the SA
        /// </summary>
        /// <returns>Measured power in dBm</returns>
        /// <exception cref="Exception"></exception>
        public double MeasCentralPower()
        {
            if (!initialized)
            {
                throw new Exception("Instrument is not initialized");
            }

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

        /// <summary>
        /// Measures the peak power around 10% band from the specified central frequency
        /// </summary>
        /// <param name="frequency">Specified central frequency</param>
        /// <param name="freqBand">Frequency band for the specified frequency</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
