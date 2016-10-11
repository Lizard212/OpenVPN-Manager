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

        public static JObject LoadConfig()
        {
            JObject config = JObject.Parse(File.ReadAllText("config.json"));
            if(CheckConfig() == false)
            {
                return null;
            }

            return config;
        }
        public static bool CheckConfig()
        {
            try
            {
                JObject config = JObject.Parse(File.ReadAllText("config.json"));
                if(config["mode"] == null)
                {

                    return false;
                }
                if(config["key_name"] == null)
                {
                    return false;
                }
                if(config["time_change"] == null)
                {
                    return false;
                }
                return true;
            }
           catch
            {
                return false;
            }
        }
    }
}
