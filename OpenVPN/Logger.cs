using Newtonsoft.Json.Linq;
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
        private static Logger instance;
        private Logger() { jconfig = Configuration.Instance.LoadConfig(); }
        public static Logger Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }
       
        public JObject jconfig = new JObject();

        public  bool Infor(string data)
        {
            try
            {
                if (jconfig["logs_level"].ToString().ToLower() != "all")
                {
                    return false;
                }
                Console.WriteLine("\n[INFO][" + DateTime.Now.ToString() + "]" + data + "\n");
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Log(string contents)
        {
            try
            {
                if (jconfig["logs_level"].ToString().ToLower() != "all" && jconfig["logs_level"].ToString().ToLower() != "infor")
                { return false; }
                string data = "[WARNING][" + DateTime.Now.ToString() + "]" + contents + "\n";
                Console.WriteLine(data);
                WriteFile(data);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           

        }
        public  bool Error(string contents)
        {
            try
            {
                if (jconfig["logs_level"].ToString().ToLower() != "all" && jconfig["logs_level"].ToString().ToLower() != "error")
                { return false; }
                string data = "[ERROR][" + DateTime.Now.ToString() + "]" + contents + "\n";
                Console.WriteLine(data);

                WriteFile(data);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public  void WriteFile(string contents)
        {
            try
            {
                string file_path = string.Empty;
                file_path = jconfig["logs_folder"].ToString() + "\\" + jconfig["logs_file"].ToString();
                File.AppendAllText(file_path, contents + Environment.NewLine);
 
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
