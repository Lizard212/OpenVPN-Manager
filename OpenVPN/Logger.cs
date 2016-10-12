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
       
        public JObject jconfig = new JObject();

        public Configuration configuration = new Configuration();
        public Logger() { jconfig = configuration.LoadConfig(); }
        public  bool Infor(string data)
        {
            try
            {
                if (jconfig["logs_level"].ToString().ToLower() != "all")
                {
                    return false;
                }
                Console.WriteLine("[INFO][" + DateTime.Now.ToString() + "]" + data);
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
                Console.WriteLine("[WARNING][" + DateTime.Now.ToString() + "]" + contents);
                WriteFile(contents);
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
                Console.WriteLine("[ERROR][" + DateTime.Now.ToString() + "]" + contents);
                WriteFile(contents);
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
                file_path = jconfig["logs_folder"].ToString() + jconfig["logs_file"].ToString();
                StreamWriter file = new StreamWriter(file_path,true);
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
