using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Ivi.Visa;

namespace LoadPullSystemControl.Instruments
{
    internal class E364xA
    {
        public string gpibAddress { get; }
        public bool initialized = false;
        public IMessageBasedSession visa = null;

        // Defaults are the lower of the two options for the device
        double[] maxCurrent = { 1.4, 1.4 };
        double[] minCurrent = { 0, 0 };
        double[] maxVoltage = { 35, 35 };
        double[] minVoltage = { 0 ,0 };

        public bool turnedOn { get; set; }
        public string idMsg { get; }
        public E364xA(string gpibAddress) 
        {
            this.gpibAddress = gpibAddress;
            try
            {
                (visa, idMsg) = VisaUtil.InitInstrument(gpibAddress);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            initialized= true;

            // Check the maximum and minimum currents for each terminal
            VisaUtil.SendCmd(visa, "INST OUTP1");

            maxCurrent[0] = VisaUtil.SendReceiveFloatCmd(visa, "CURR? MAX");
            minCurrent[0] = VisaUtil.SendReceiveFloatCmd(visa, "CURR? MIN");
            maxVoltage[0] = VisaUtil.SendReceiveFloatCmd(visa, "VOLT? MAX");
            minVoltage[0] = VisaUtil.SendReceiveFloatCmd(visa, "CURR? MIN");

            VisaUtil.SendCmd(visa, "INST OUTP2");

            maxCurrent[1] = VisaUtil.SendReceiveFloatCmd(visa, "CURR? MAX");
            minCurrent[1] = VisaUtil.SendReceiveFloatCmd(visa, "CURR? MIN");
            maxVoltage[1] = VisaUtil.SendReceiveFloatCmd(visa, "VOLT? MAX");
            minVoltage[1] = VisaUtil.SendReceiveFloatCmd(visa, "CURR? MIN");

            turnedOn = false;
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
            if (!initialized)
            {
                throw new Exception("Driver not initialized");
            }
            if (source != 1 && source != 2)
            {
                throw new ArgumentOutOfRangeException("Source can only be 1 or 2");
            }
            if (limit > maxCurrent[source-1] || limit < minCurrent[source-1]) 
            {
                throw new ArgumentOutOfRangeException(String.Format("Specified current outside of range: {0}-{1}", 
                                                                        minCurrent[source - 1], maxCurrent[source - 1]));
            }

            try
            {
                // Set the chosen source and set the current
                string msg = String.Format("INST OUTP{0}", source);
                VisaUtil.SendCmd(visa, msg);
                msg = String.Format("CURR {0}", limit.ToString(CultureInfo.InvariantCulture.NumberFormat));
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
            if (!initialized)
            {
                throw new Exception("Driver not initialized");
            }
            if (source != 1 && source != 2)
            {
                throw new ArgumentOutOfRangeException("Source can only be 1 or 2");
            }
            if (limit > maxVoltage[source - 1] || limit < minVoltage[source - 1])
            {
                throw new ArgumentOutOfRangeException(String.Format("Specified current outside of range: {0}-{1}",
                                                                        minVoltage[source - 1], maxVoltage[source - 1]));
            }
            try
            {
                // Sets the chosen source and sets the voltage
                string msg = String.Format("INST OUTP{0}", source);
                VisaUtil.SendCmd(visa, msg);
                msg = String.Format("VOLT {0}", limit.ToString(CultureInfo.InvariantCulture.NumberFormat));
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
            if (!initialized)
            {
                throw new Exception("Driver not initialized");
            }
            if (source != 1 && source != 2)
            {
                throw new ArgumentOutOfRangeException("Source can only be 1 or 2");
            }

            try
            {
                // Select the specified source and measure its current
                string msg = String.Format("INST OUTP{0}", source);
                VisaUtil.SendCmd(visa, msg);
                msg = String.Format("MEAS:CURR?");
                double current = VisaUtil.SendReceiveFloatCmd(visa, msg);
                return current;
            }
            catch(Exception ex) 
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
            if (!initialized)
            {
                throw new Exception("Driver not initialized");
            }
            if (source != 1 && source != 2)
            {
                throw new ArgumentOutOfRangeException("Source can only be 1 or 2");
            }

            try
            {
                // Select the specified voltage and measure its current
                string msg = String.Format("INST OUTP{0}", source);
                VisaUtil.SendCmd(visa, msg);
                msg = String.Format("MEAS:VOLT?");
                double voltage = VisaUtil.SendReceiveFloatCmd(visa, msg);
                return voltage;
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
        public void TurnOnOff(bool turnOn)
        {
            if (!initialized)
            {
                throw new Exception("Driver not initialized");
            }

            try
            {
                var msg = string.Format("OUTP {0}", turnOn == true ? "ON" : "OFF");
                VisaUtil.SendCmd(visa, msg);
                this.turnedOn = turnOn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
