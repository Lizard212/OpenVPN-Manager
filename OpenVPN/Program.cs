using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace OpenVPN
{

    public class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;


        public static void Main()
        {
            try
            {
                var handle = GetConsoleWindow();
                // Hide
                //ShowWindow(handle, SW_HIDE);
                // Show
                ShowWindow(handle, SW_SHOW);
                JObject config  = new JObject();
                config = Configuration.Instance.LoadConfig();
                OvpnConnector connector = new OvpnConnector();
                //connector.Connect(config["config_folder"].ToString(), "/c openvpn --config " + config["key_name"].ToString());
                //Environment.Exit(1);

                while (true)
                {
                    if(config == null)
                    {
                        Logger.Instance.Error("Error configuration");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Common common = new Common();
                        List<string> list_files = new List<string>();
                        if (int.Parse(config["mode"].ToString()) == 0)
                        {
                            connector.Connect(config["config_folder"].ToString(), "/c openvpn --config " + config["key_name"].ToString());
                        }
                        else
                        {
                            list_files = common.GetFiles(config["config_folder"].ToString());
                            foreach (var item in list_files)
                            {
                                connector.Connect(config["config_folder"].ToString(),"/c openvpn --config " +   item);
                                System.Threading.Thread.Sleep(int.Parse(config["time_change"].ToString()));
                            }
                        }
                    }



                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Environment.Exit(0);
            }
          
            
        }

    }
}
