using InstrumentDriverTest.InstrumentDrivers;
using Ivi.Visa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentDriverTest.InstrumentDrivers
{
    public abstract class GeneralDevice
    {
        public string gpibAddress { get; protected set; }
        public IMessageBasedSession visa { get; protected set; }
        public string idMsg { get; protected set; }

        public GeneralDevice(string gpibAddress)
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
        }
        public GeneralDevice() { }
    }
}
