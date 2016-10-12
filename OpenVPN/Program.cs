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


                JObject check = new JObject();
                while (true)
                {
                    Configuration configuration = new Configuration();
                    check = configuration.LoadConfig();
                    if (check == null)
                    {
                        Console.WriteLine("The configration is missing.");
                        Environment.Exit(0);
                    }
                    else
                    {


                        Common common = new Common();
                        List<string> list_files = new List<string>();
                        OvpnConnector connector = new OvpnConnector();
                        if (int.Parse(check["mode"].ToString()) == 0)
                        {
                            connector.Connect(check["config_folder"].ToString(), check["key_name"].ToString());
                        }
                        else
                        {
                            list_files = common.GetFiles(check["config_folder"].ToString());
                            foreach (var item in list_files)
                            {
                                connector.Connect(check["config_folder"].ToString(), item);
                                System.Threading.Thread.Sleep(int.Parse(check["time_changes"].ToString()));
                            }
                        }



                    }
                }
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
          
            
        }

    }
}
