using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenVPN
{
   
   public class Configuration
    {
        private  string config_filename = "config.json";
        protected   JObject config = new JObject();
       
        
        public   bool CheckConfig()
        {
            try
            {
            //    JObject config = JObject.Parse(File.ReadAllText("config.json"));
            //    if (config["mode"] == null)
            //    {

            //        return false;
            //    }
            //    if (config["key_name"] == null)
            //    {
            //        return false;
            //    }
            //    if (config["time_change"] == null)
            //    {
            //        return false;
            //    }
            //    if (config["logs_file"] == null)
            //    {
            //        return false;
            //    }
            //    if (config["logs_level"] == null)
            //    {
            //        return false;
            //    }
            //    if (config["logs_folder"] == null)
            //    {
            //        return false;
            //    }
                return true;
            }
            catch
            {
                return false;
            }

        }

        private  void Create()
        {
          if(config.Count == 0 )
            {
                config = new JObject
                {
                    {"logs_folder","logs" },
                    {"logs_level","all" },
                    {"logs_file","application.log" }
                };
               File.WriteAllText(config_filename, config.ToString());
            }
            try
            {
                Directory.CreateDirectory(config["logs_folder"].ToString());
                
            }
            catch (Exception )
            {

                throw;
            }
        }

        public  JObject LoadConfig()
        {
            try
            {
                config = JObject.Parse(File.ReadAllText(config_filename));
                if (CheckConfig() == false)
                {
                    Create();
                }
                return config;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return config;
            }      

        }

        
    }

  
     
   

    
}
