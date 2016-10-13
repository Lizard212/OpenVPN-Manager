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
       public OvpnConnector() { }
   
        public void Connect(string configFolder, string command)
        {
            RunCmd(configFolder, command);
        }
        public bool RunCmd( string directoryName, string command)
        {
            string output = string.Empty;
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName =  Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\System32\cmd.exe";
            processStartInfo.Verb = "runas";
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processStartInfo.WorkingDirectory = Path.GetDirectoryName(directoryName);
            processStartInfo.Arguments = command;
            Logger.Instance.Infor(processStartInfo.Arguments.ToString());
            Logger.Instance.Infor(processStartInfo.WorkingDirectory.ToString());
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardOutput = true;
            
            Process process = Process.Start(processStartInfo);
            
             while(!process.StandardOutput.EndOfStream)
            {

                string line = process.StandardOutput.ReadLine();
                if (line.Contains("error") || line.Contains("failed"))
                {
                    Logger.Instance.Error("Error to connect VPN server");
                    process.Kill();
                    return false;
                }
           
                Logger.Instance.Infor(line);
            }
            return true;
            //Logger.Instance.Log(output);
            //process.WaitForExit();
            //process.Close();
 
        }
   

    }
}
