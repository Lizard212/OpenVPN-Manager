using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenVPN
{
   public class Common
    {
        public List<string> GetFiles(string directory_path)
        {
            List<string> list_files = new List<string>();
            DirectoryInfo d = new DirectoryInfo(directory_path);
            FileInfo[] Files = d.GetFiles("*.ovpn"); 
            string str = "";
            foreach (FileInfo file in Files)
            {
                list_files.Add(file.Name);
            }
            return list_files;
        }
    }
}
