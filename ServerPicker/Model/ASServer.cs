using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerPicker.Model
{
    public class ASServer
    {
        public const string ASCOM = "www.alaskaair.com";

        public const string AL_15_IP = "190.10.10.15";
        public const string AL_15_Name = "AL_15";
        public const string AL_13_IP = "190.10.10.13";
        public const string AL_13_Name = "AL_13";
        public const string AL_7_IP = "190.10.10.7";
        public const string AL_7_Name = "AL_7";
        public const string AL_19_IP = "190.10.10.19";
        public const string AL_19_Name = "AL_19";
        public const string AL_21_IP = "190.10.10.21";
        public const string AL_21_Name = "AL_21";
        public const string localhost_IP = "127.0.0.1";
        public const string localhost_Name = "localhost";
        public const string STG_1_IP = "190.10.10.97";
        public const string STG_1_Name = "STG_1";
        public const string STG_2_IP = "190.10.10.98";
        public const string STG_2_Name = "STG_2";
        public const string STG_3_IP = "190.10.10.99";
        public const string STG_3_Name = "STG_3";
        public const string Prod_IP = "190.10.10.00";
        public const string Prod_Name = "Prod";
        private string serverName;

        public ASServer(string server)
        {
            this.serverName = server;
            switch (serverName)
            {
                case AL_13_Name: IP = AL_13_IP; Name = AL_13_Name; break;
                case AL_15_Name: IP = AL_15_IP; Name = AL_15_Name; break;
                case AL_7_Name: IP = AL_7_IP; Name = AL_7_Name; break;
                case AL_19_Name: IP = AL_19_IP; Name = AL_19_Name; break;
                case AL_21_Name: IP = AL_21_IP; Name = AL_21_Name; break;
                case STG_1_Name: IP = STG_1_IP; Name = STG_1_Name; break;
                case STG_2_Name: IP = STG_2_IP; Name = STG_2_Name; break;
                case STG_3_Name: IP = STG_3_IP; Name = STG_3_Name; break;
                case Prod_Name: IP = Prod_IP; Name = Prod_Name; break;
                case localhost_Name: IP = localhost_IP; Name = localhost_Name; break;
                default: break;
            }

            SetServerProperties();
        }

        public string IP { get; set; }
        public string Name { get; set; }

        public string CurrentEnvironment { get; set; }

        private void SetServerProperties()
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

                var tales = string.Format("{0} {1} #{2}", IP, ASCOM, Name);
                string[] lines = File.ReadAllLines(hostfile);

                if (lines.Any(s => s.Contains(ASCOM)))
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Contains(ASCOM))
                            lines[i] = tales;
                    }
                    File.WriteAllLines(hostfile, lines);
                }
                else if (!lines.Contains(tales))
                {
                    File.AppendAllLines(hostfile, new String[] { tales });
                }
                CurrentEnvironment = string.Format("Current Environment: {0} (IP#: {1})", Name, IP);
            }
            catch (Exception ex)
            {
                Name = ex.Message;
            }

        }
    }
}
