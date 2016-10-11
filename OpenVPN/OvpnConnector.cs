using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace OpenVPN
{
    public class OvpnConnector
    {
        public void Switch(string aa)
        {

        }
        public void Connect(string configFolder, string keyName)
        {
            string output = string.Empty;
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName =  Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\System32\cmd.exe";
            processStartInfo.Verb = "runas";
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processStartInfo.WorkingDirectory = Path.GetDirectoryName(configFolder);
            processStartInfo.Arguments = "/c openvpn --config " + keyName;
            Console.WriteLine(processStartInfo.Arguments.ToString());
            processStartInfo.UseShellExecute = false;
            Process process = Process.Start(processStartInfo);

        }
        public void Disconnect()
        {

        }
        public void GetInformation()
        {

        }
    }
}
