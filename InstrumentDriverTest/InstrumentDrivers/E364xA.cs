using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Ivi.Visa;

namespace InstrumentDriverTest.Instruments
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


        public E364xA(string gpibAddress) 
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


        }

        public void setCurrentLimit(int source, float limit)
        {
            if (!initialized)
            {
                // Write error message
                return;
            }
            if (source != 0 | source != 1)
            {
                // Write error message
                return;
            }
            if (limit > maxCurrent[source-1] || limit < minCurrent[source-1]) 
            {
                // Write error mesage
                return;
            }

            string msg = String.Format("INST OUTP{0}", source);
            VisaUtil.SendCmd(visa, msg);
            msg = String.Format("CURR {0}", limit);
            VisaUtil.SendCmd(visa, msg);
        }

        public void setVoltageLimit(int source, float limit)
        {
            if (!initialized)
            {
                // Write error message
                return;
            }
            if (source != 0 | source != 1)
            {
                // Write error message
                return;
            }
            if (limit > maxCurrent[source - 1] || limit < minCurrent[source - 1])
            {
                // Write error mesage
                return;
            }

            string msg = String.Format("INST OUTP{0}", source);
            VisaUtil.SendCmd(visa, msg);
            msg = String.Format("VOLT {0}", limit);
            VisaUtil.SendCmd(visa, msg);
        }

        public double readCurrent(int source)
        {
            if (!initialized)
            {
                return -10;
            }
            if (source != 0 | source != 1)
            {
                // Write error message
                return -10;
            }

            string msg = String.Format("INST OUTP{0}", source);
            VisaUtil.SendCmd(visa, msg);
            msg = String.Format("CURR?");
            double current = VisaUtil.SendReceiveFloatCmd(visa, msg);
            return current;

        }

        public double readVoltage(int source)
        {
            if (!initialized)
            {
                return -10;
            }
            if (source != 0 | source != 1)
            {
                // Write error message
                return -10;
            }

            string msg = String.Format("INST OUTP{0}", source);
            VisaUtil.SendCmd(visa, msg);
            msg = String.Format("VOLT?");
            double voltage = VisaUtil.SendReceiveFloatCmd(visa, msg);
            return voltage;

        }

        public void turnOnOff(int source, bool turnOn)
        {
            if (!initialized)
            {
                return;
            }

            if (source != 0 || source != 1)
            {
                return;
            }

            string msg = String.Format("INST OUTP{0}", source);
            VisaUtil.SendCmd(visa, msg);
            msg = string.Format("OUTP {0}", turnOn == true ? "ON" : "OFF");
            VisaUtil.SendCmd(visa, msg);
        }

        public void turnAllOnOff(bool turnOn)
        {
            if (!initialized) { return; }

            turnOnOff(0, turnOn);
            turnOnOff(1, turnOn);
        }
    }
}
