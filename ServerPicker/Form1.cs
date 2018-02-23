using ServerPicker.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ServerPicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<ASServer> allEnvs = ASServer.GetAllServers();
            AddLocalhostButton(allEnvs);
            AddAlphaButtons(allEnvs);
            AddStagingButtons(allEnvs);
            AddProdButton(allEnvs);
            resultLabel.Text = ASServer.GetCurrentEnv();
        }

        private void AddAlphaButtons(List<ASServer> allEnvs)
        {
            var al_boxes = allEnvs.Where(x => x.Name.Contains("AL_"));
            var yAxis = 53;
            var xAxis = 104;
            foreach (var al in al_boxes)
            {
                CreateButton(xAxis, yAxis, al);
                yAxis = yAxis + 45;
            }
        }

        private void CreateButton(int xAxis, int yAxis, ASServer serverBox)
        {
            var button = new Button()
            {
                Text = serverBox.Name,
                Location = new Point(xAxis, yAxis),
                ForeColor = SystemColors.ActiveCaptionText,
                Size = new Size(58, 29),
            };
            button.Click += new EventHandler(Apply_Click);
            Controls.Add(button);
        }

        private void AddStagingButtons(List<ASServer> allEnvs)
        {
            var staging_boxes = allEnvs.Where(x => x.Name.Contains("STG_"));
            var yAxis = 53;
            var xAxis = 205;
            foreach (var stg in staging_boxes)
            {
                CreateButton(xAxis, yAxis, stg);
                yAxis = yAxis + 45;
            }
        }

        private void AddLocalhostButton(List<ASServer> allEnvs)
        {
            var localhost = allEnvs.Find(x => x.Name.Equals("localhost"));
            CreateButton(11, 53, localhost);
        }

        private void AddProdButton(List<ASServer> allEnvs)
        {
            var prod = allEnvs.Find(x => x.Name.Equals("Prod"));
            CreateButton(300, 53, prod);
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            CreateServerObject(((ButtonBase)sender).Text);
        }

        private void CreateServerObject(string serverName)
        {
            var server = new ASServer();
            server.SetServerProperties(serverName);
            resultLabel.Text = server.CurrentEnvironment;
        }

        private void OpenUrl(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://www.alaskaair.com/");
            Process.Start(sInfo);
        }

        private void OpenMOW_Modal(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Application.OpenForms["PopupForm"] as PopupForm != null)
                Application.OpenForms["PopupForm"].Focus();
            else
            {
                var form = new PopupForm();
                form.Show();
            }
        }
    }
}
