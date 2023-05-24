using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentDriverTest.InstrumentDrivers.WaveformGenerator
{
    public class WG33600A : WaveformGenerator
    {
        public override void SetSineWave(int source, double frequency, double amplitude, double offset, double phase)
        {

            try
            {
                string msg = string.Format("SOURCE{0}:APPLY:SIN {1},{2},{3}", source.ToString(), frequency.ToString(), amplitude.ToString(), offset.ToString());

                VisaUtil.SendCmd(visa, msg);

                msg = string.Format("SOURCE{0}:PHASE {1}", source.ToString(), phase.ToString());
                VisaUtil.SendCmd(visa, msg);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override void TurnOnOff(int source, bool turnOn)
        {
            try
            {
                turnedOn = turnOn;
                string msg = string.Format("SOURCE{0}:OUTPUT {1}", source.ToString(), turnOn==true ? "1" : "0");
                VisaUtil.SendCmd(visa, msg);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
