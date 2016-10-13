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
                connector.Connect(config["config_folder"].ToString(), "/c openvpn --config " + config["key_name"].ToString());
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
          
            
        }

    }
}
