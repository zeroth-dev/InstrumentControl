using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ivi.Visa;
using NationalInstruments.Visa;
namespace InstrumentDriverTest.Instruments
{
    internal class VisaUtil
    {
        /// <summary>
        /// Creates a new visa object
        /// Use only if for some reason the id message is not "*IDN?"
        /// </summary>
        /// <param name="gpibAddress">Full gpib address of the instrument</param>
        /// <param name="idMsg">IDN equivalent query for the instrument</param>
        /// <returns>An instance of the IMessageBasedSession and the instrument output to the IDN query</returns>
        public static (IMessageBasedSession, string) InitInstrument(string gpibAddress, string idMsg)
        {
            try
            {
                string idOutput = "";
                IMessageBasedSession visa = null;

                // Get Intrument ID to verify that the connection works
                visa = GlobalResourceManager.Open(gpibAddress) as IMessageBasedSession;
                idOutput = SendReceiveStringCmd(visa, idMsg);

                return (visa, idOutput);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }
        public static (IMessageBasedSession, string) InitInstrument(string gpibAddress)
        {
            try
            {
                string idOutput = "";
                IMessageBasedSession visa = null;
                (visa, idOutput) = InitInstrument(gpibAddress, "*IDN?");
                return (visa, idOutput);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }

        public static void SendCmd(IMessageBasedSession visa, string msg)
        {
            visa.RawIO.Write(msg + "\n");
        }

        /// <summary>
        /// Sends the specified message to the gpib address and gets the text answer from the instrument
        /// Use only when a return message from the instrument is expected
        /// </summary>
        /// <param name="visa">visa object for the instrument</param>
        /// <param name="msg">Query to be sent</param>
        /// <returns>String response from the instrument</returns>
        public static string SendReceiveStringCmd(IMessageBasedSession visa, string msg)
        {
            
            visa.RawIO.Write(msg + "\n"); // write to instrument
            var strOutput = visa.RawIO.ReadString(); // read from instrument
            Console.WriteLine(strOutput + "\n");
            return strOutput;
        }

        public static string SendReceiveStringCmd(IMessageBasedSession visa, string msg, int count)
        {

            visa.RawIO.Write(msg + "\n"); // write to instrument
            var charOutput = visa.RawIO.Read(count); // read from instrument
            var strOutput = System.Text.Encoding.ASCII.GetString(charOutput);
            Console.WriteLine(strOutput + "\n");
            return strOutput;
        }

        /// <summary>
        /// Sends the specified message to the gpib address and gets a floating point number from the instrument
        /// Use only when a return message from the instrument is expected
        /// </summary>
        /// <param name="visa">visa object for the instrument</param>
        /// <param name="msg">Query to be sent</param>
        /// <returns>Float number received from the instrument</returns>
        public static double SendReceiveFloatCmd(IMessageBasedSession visa, string msg)
        {

            visa.RawIO.Write(msg + "\n"); // write to instrument
            string outp = visa.RawIO.ReadString();
            var floatReturn = double.Parse(outp, System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat); // read from instrument
            Console.WriteLine(floatReturn + "\n");
            return floatReturn;
        }

        /// <summary>
        /// TODO
        /// Sends the specified message to the gpib address and gets the floar array from the instrument
        /// Use only when a return message from the instrument is expected
        /// </summary>
        /// <param name="visa">visa object for the instrument</param>
        /// <param name="msg">Query to be sent</param>
        /// <param name="arrSize">Size of the array to be received</param>
        /// <returns>Array received from the instrument</returns>
        public static string SendReceiveFloatArrayCmd(IMessageBasedSession visa, string msg, int arrSize)
        {

            visa.RawIO.Write(msg + "\n"); // write to instrument
            var idOutput = visa.RawIO.ReadString(); // read from instrument
            Console.WriteLine(idOutput + "\n");
            visa.ReadStatusByte();
            
            return idOutput;
        }

        /// <summary>
        /// Gets all the GPIB devices connected to the computer
        /// </summary>
        /// <returns>List of GPIB addresses of the connected devices</returns>
        /// <exception cref="Exception">Throws exception if no resource can be found</exception>
        public static List<string> GetConnectedDeviceList()
        {

            using (var rm = new ResourceManager())
            {
                try
                {
                    var resourceList = new List<string>();
                    IEnumerable<string> resources = rm.Find("GPIB?*");
                    foreach (string s in resources)
                    {
                        ParseResult parseResult = rm.Parse(s);
                        resourceList.Add(parseResult.OriginalResourceName);
                    }
                    return resourceList;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw new Exception(e.Message);
                }
            }
        }

        /// <summary>
        /// Sends the specified message to the specified gpib address and gets the text answer from the instrument
        /// Use only when a return message from the instrument is expected
        /// </summary>
        /// <param name="gpibAddress"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string SendReceiveStringCmd(string gpibAddress, string msg)
        {
            try
            { 
                var visa = GlobalResourceManager.Open(gpibAddress) as IMessageBasedSession;
                visa.RawIO.Write(msg+"\n"); // write to instrument
                var strOutput = visa.RawIO.ReadString(); // read from instrument
                Console.WriteLine(strOutput + "\n");
                return strOutput;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
