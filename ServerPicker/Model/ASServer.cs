using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ServerPicker.Model
{
    public class ASServer
    {
        const string ASCOM = "www.alaskaair.com";

        const string Prod_Name = "Prod";

        public string IP { get; set; }

        public string Name { get; set; }

        public string CurrentEnvironment { get; set; }

        public void SetServerProperties(string server)
        {
            try
            {
                var xmlServer = GetServer(server);
                var OSInfo = Environment.OSVersion;
                string pathpart = "hosts";
                if (OSInfo.Platform == PlatformID.Win32NT)
                {
                    //is windows NT
                    pathpart = "system32\\drivers\\etc\\hosts";
                }
                string hostfile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), pathpart);

                var tales = string.Format("{0} {1} #{2}", xmlServer.IP, ASCOM, xmlServer.Name);
                string[] lines = File.ReadAllLines(hostfile);

                if (lines.ToArray().Any(s => s.Contains(ASCOM)))
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Contains(ASCOM))
                        {
                            lines = SetEnvValue(tales, lines, i, xmlServer.Name);
                        }

                    }
                    File.WriteAllLines(hostfile, lines);
                }
                else if (!lines.Contains(tales) && !xmlServer.Name.Equals(Prod_Name))
                {
                    File.AppendAllLines(hostfile, new String[] { tales });
                }

                CurrentEnvironment = xmlServer.Name.Equals(Prod_Name) ? "Current Environment: Prod" : string.Format("Current Environment: {0} (IP#: {1})", xmlServer.Name, xmlServer.IP);
            }
            catch (Exception ex)
            {
                CurrentEnvironment = ex.Message.Contains("is denied") ? "No permissions to update hosts file. Run as administrator" : ex.Message;
            }


        }

        internal static string GetCurrentEnv()
        {
            try
            {
                var OSInfo = Environment.OSVersion;
                string pathpart = "hosts";
                if (OSInfo.Platform == PlatformID.Win32NT)
                {
                    //is windows NT
                    pathpart = "system32\\drivers\\etc\\hosts";
                }
                string hostfile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), pathpart);

                string[] lines = File.ReadAllLines(hostfile);

                var currentEnv = string.Empty;
                if (lines.Any(s => s.Contains(ASCOM)))
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Contains(ASCOM))
                            currentEnv = lines[i];
                    }
                    File.WriteAllLines(hostfile, lines);
                }


                var hostFileAttributes = currentEnv.Split(' ');

                return hostFileAttributes.Length == 3 ? string.Format("Current Environment: {0} (IP#: {1})", hostFileAttributes[2].ToString().Replace("#", string.Empty), hostFileAttributes[0]) : "Current Environment: Prod";

            }
            catch (Exception ex)
            {
                return ex.Message.Contains("is denied") ? "No permissions to update hosts file. Run as administrator" : ex.Message;
            }

        }

        internal static List<ASServer> GetAllServers()
        {
            var list = new List<ASServer>();
            StringBuilder result = new StringBuilder();
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var xml = string.Format(@"{0}\\Servers.xml", path);

            foreach (XElement server in XElement.Load(xml).Elements("Server"))
            {
                var xmlServer = new ASServer() { Name = server.Attribute("name").Value };
                foreach (XElement ipServer in server.Elements("ip"))
                    xmlServer.IP = ipServer.Attribute("value").Value;

                list.Add(xmlServer);
            }
            return list;

        }

        #region Private Methods

        private ASServer GetServer(string server)
        {
            return GetAllServers().Where(x => x.Name.Equals(server)).FirstOrDefault();
        }

        private string[] SetEnvValue(string tales, string[] lines, int i, string name)
        {
            if (name.Equals(Prod_Name))
            {
                var list = new List<string>(lines);
                list.Remove(lines[i]);
                lines = list.ToArray();
            }
            else
                lines[i] = tales;
            return lines;
        }

        #endregion
    }
}
