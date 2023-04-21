using InstrumentDriverTest.Instruments;
using Ivi.Visa;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentDriverTest.InstrumentDrivers
{
    public class E36300
    {
        string gpibAddress { get; }
        private IMessageBasedSession visa = null;
        public string idMsg { get; }
        public bool[] turnedOn { get; set; }

        public E36300(string gpibAddress)
        {
            this.gpibAddress = gpibAddress;
            try
            {
                (visa, idMsg) = VisaUtil.InitInstrument(this.gpibAddress);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            turnedOn = new bool[2];
            turnedOn[0] = false;
            turnedOn[1] = false;
        }

        /// <summary>
        /// Sets the maximum current for the specified source
        /// </summary>
        /// <param name="source">1 or 2 describing the source being modified</param>
        /// <param name="limit">Maximum current</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetCurrentLimit(int source, double limit)
        {
            try
            {
                string msg = String.Format("CURR {0}, (@{1})", limit.ToString(CultureInfo.InvariantCulture.NumberFormat), source);
                VisaUtil.SendCmd(visa, msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sets the maximum voltage for the specified source
        /// </summary>
        /// <param name="source">1 or 2 describing the source being modified</param>
        /// <param name="limit">Maximum voltage</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetVoltageLimit(int source, double limit)
        {
            try
            {
                string msg = String.Format("VOLT {0}, (@{1})", limit.ToString(CultureInfo.InvariantCulture.NumberFormat), source);
                VisaUtil.SendCmd(visa, msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Measures the current from the specified source
        /// </summary>
        /// <param name="source">1 or 2 describing the source</param>
        /// <returns>Current output from the specified source</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public double ReadCurrent(int source)
        {
            try
            {
                string msg = String.Format("MEAS:CURR? CH{0}", source);
                double current = VisaUtil.SendReceiveFloatCmd(visa, msg);
                return current;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Measures the voltage from the specified source
        /// </summary>
        /// <param name="source">1 or 2 describing the source</param>
        /// <returns>Voltage on the specified output</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public double ReadVoltage(int source)
        {
            try
            {
                string msg = String.Format("MEAS:VOLT? CH{0}", source);
                double current = VisaUtil.SendReceiveFloatCmd(visa, msg);
                return current;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Turns the power supply on or off
        /// </summary>
        /// <param name="turnOn">true if turning the power supply ON and false otherwise</param>
        /// <exception cref="Exception"></exception>
        public void TurnOnOff(int source, bool turnOn)
        {
            try
            {
                var msg = string.Format("OUTP {0}, (@{1})", turnOn == true ? "ON" : "OFF", source);
                VisaUtil.SendCmd(visa, msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
