using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenVPN
{
    public class Logger
    {
        
        public static void InforLog(string contents)
        {
            Console.WriteLine("[INFO][" + DateTime.Now.ToString() + "]" + contents);
        }

        public static void WarningLog(string contents)
        {

            Console.WriteLine("[WARNING][" + DateTime.Now.ToString() + "]" + contents);
            Logger.WriteFile(contents);
        }
        public static void ErrorLog(string contents)
        {
            Console.WriteLine("[ERROR][" + DateTime.Now.ToString() + "]" + contents);
            Logger.WriteFile(contents);
        }
        public static void WriteFile(string contents)
        {
            try
            {
                StreamWriter file = new StreamWriter("log.txt",true);
                file.WriteLine(contents);
                file.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
