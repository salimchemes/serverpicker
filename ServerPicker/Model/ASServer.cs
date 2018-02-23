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
        const string EASYBIZ = "easybiz.alaskaair.com";

        const string Prod_Name = "Prod";

        public string AsComIp { get; set; }

        public string EasyBizIp { get; set; }

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

                var talesAsCom = string.Format("{0} {1} #{2}", xmlServer.AsComIp, ASCOM, xmlServer.Name);
                var talesEasyBiz = string.Format("{0} {1} #{2}", xmlServer.EasyBizIp, EASYBIZ, xmlServer.Name);
                string[] lines = File.ReadAllLines(hostfile);

                lines = UpdateHostsFileValues(xmlServer, hostfile, talesAsCom, lines, ASCOM);
                lines = UpdateHostsFileValues(xmlServer, hostfile, talesEasyBiz, lines, EASYBIZ);

                CurrentEnvironment = xmlServer.Name.Equals(Prod_Name) ? "Prod: Ascom and EazyBiz" : string.Format("{0}: Ascom: ({1}) Easybiz: ({2})", xmlServer.Name, xmlServer.AsComIp, xmlServer.EasyBizIp);
            }
            catch (Exception ex)
            {
                CurrentEnvironment = ex.Message.Contains("is denied") ? "No permissions to update hosts file. Run as administrator" : ex.Message;
            }


        }

        private string[] UpdateHostsFileValues(ASServer xmlServer, string hostfile, string entry, string[] lines, string site)
        {
            if (lines.ToArray().Any(s => s.Contains(site)))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(site))
                    {
                        lines = SetEnvValue(entry, lines, i, xmlServer.Name);
                    }

                }
                File.WriteAllLines(hostfile, lines);
            }
            else if (!lines.Contains(entry) && !xmlServer.Name.Equals(Prod_Name))
            {
                File.AppendAllLines(hostfile, new String[] { entry });
            }

            return lines;
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
                var xmlServer = new ASServer();
                if (hostFileAttributes.Length == 3)
                    xmlServer = GetServer(hostFileAttributes[2].ToString().Replace("#", string.Empty)); 

                return xmlServer.Name != null ? string.Format("{0}: Ascom: ({1}) Easybiz: ({2})", xmlServer.Name, xmlServer.AsComIp, xmlServer.EasyBizIp) : "Prod: Ascom and EazyBiz";

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
                foreach (XElement ipServer in server.Elements("ascomip"))
                    xmlServer.AsComIp = ipServer.Attribute("value").Value;

                foreach (XElement ipServer in server.Elements("easybizip"))
                    xmlServer.EasyBizIp = ipServer.Attribute("value").Value;


                list.Add(xmlServer);
            }
            return list;

        }

        #region Private Methods

        internal static ASServer GetServer(string server)
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
