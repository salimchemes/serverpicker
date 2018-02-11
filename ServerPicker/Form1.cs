using ServerPicker.Model;
using System;
using System.Windows.Forms;

namespace ServerPicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Apply_Click_LocalHost(object sender, EventArgs e)
        {
            CreateServerObject(((ButtonBase)sender).Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.resultLabel.Text = string.Empty;
        }

        private void Apply_Click_AL_15(object sender, EventArgs e)
        {
            CreateServerObject(((ButtonBase)sender).Text);
        }

        private void Apply_Click_AL_13(object sender, EventArgs e)
        {
            CreateServerObject(((ButtonBase)sender).Text);
        }

        private void Apply_Click_AL_7(object sender, EventArgs e)
        {
            CreateServerObject(((ButtonBase)sender).Text);
        }

        private void Apply_Click_AL_19(object sender, EventArgs e)
        {
            CreateServerObject(((ButtonBase)sender).Text);
        }

        private void Apply_Click_AL_21(object sender, EventArgs e)
        {
            CreateServerObject(((ButtonBase)sender).Text);
        }

        private void Apply_Click_Stg_1(object sender, EventArgs e)
        {
            CreateServerObject(((ButtonBase)sender).Text);
        }

        private void Apply_Click_Prod(object sender, EventArgs e)
        {
            CreateServerObject(((ButtonBase)sender).Text);
        }

        private void Apply_Click_Stg_2(object sender, EventArgs e)
        {
            CreateServerObject(((ButtonBase)sender).Text);
        }

        private void Apply_Click_Stg_3(object sender, EventArgs e)
        {
            CreateServerObject(((ButtonBase)sender).Text);
        }

        private void CreateServerObject(string serverName)
        {
            var server = new ASServer(serverName); 
            resultLabel.Text = server.CurrentEnvironment; 
        }

    }
}
