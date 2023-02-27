using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Ivi.Visa;
using NationalInstruments.Visa;

namespace InstrumentControl.Instruments
{
    public class VisaUtil
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
            
            string idOutput = "";
            IMessageBasedSession visa = null;
            try
            {
                // Get Intrument ID to verify that the connection works
                visa = GlobalResourceManager.Open(gpibAddress) as IMessageBasedSession;
                idOutput = SendReceiveStringCmd(visa, idMsg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
            return (visa, idOutput);
        }
        public static (IMessageBasedSession, string) InitInstrument(string gpibAddress)
        {
            string idOutput = "";
            IMessageBasedSession visa = null;
            try
            {
               (visa, idOutput) = InitInstrument(gpibAddress, "*IDN?");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
            return (visa, idOutput);
        }

        public static void SendCmd(IMessageBasedSession visa, string msg)
        {
            visa.RawIO.Write(msg);
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
            
            visa.RawIO.Write(msg); // write to instrument
            var strOutput = visa.RawIO.ReadString(); // read from instrument
            Console.WriteLine(strOutput);
            return strOutput;
        }

        /// <summary>
        /// Sends the specified message to the gpib address and gets a floating point number from the instrument
        /// Use only when a return message from the instrument is expected
        /// </summary>
        /// <param name="visa">visa object for the instrument</param>
        /// <param name="msg">Query to be sent</param>
        /// <returns>Float number received from the instrument</returns>
        public static float SendReceiveFloatCmd(IMessageBasedSession visa, string msg)
        {

            visa.RawIO.Write(msg); // write to instrument
            var floatReturn = float.Parse(visa.RawIO.ReadString()); // read from instrument
            Console.WriteLine(floatReturn);
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

            visa.RawIO.Write(msg); // write to instrument
            var idOutput = visa.RawIO.ReadString(); // read from instrument
            Console.WriteLine(idOutput);
            visa.ReadStatusByte();
            
            return idOutput;
        }

        public static List<string> GetConnectedDeviceList()
        {

            var resourceList = new List<string>();
            using (var rm = new ResourceManager())
            {
                try
                {
                    IEnumerable<string> resources = rm.Find("GPIB?*");
                    foreach (string s in resources)
                    {
                        ParseResult parseResult = rm.Parse(s);
                        resourceList.Add(parseResult.OriginalResourceName);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw new Exception(e.Message+ "\n" + e.StackTrace);
                }
            }
            return resourceList;
        }
    }
}
