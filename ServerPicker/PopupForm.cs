using System.Diagnostics;
using System.Windows.Forms;

namespace ServerPicker
{
    public partial class PopupForm : Form
    {
        public PopupForm()
        {
            InitializeComponent();
        }

        private void OpenUrl(object sender, LinkLabelLinkClickedEventArgs e)
        {           
            var link = ((LinkLabel)sender).Text;
            var url = "https://m.alaskaair.com";
            switch (link)
            {
                case "Test": url = "https://mow-test.alaskaair.com/"; break;
                case "QA": url = "https://mow-qa.alaskaair.com/"; break;
                case "Staging West": url = "http://mow-stg-westus2.azurewebsites.net/"; break;
                case "Staging East": url = "http://mow-stg-eastus2.azurewebsites.net/"; break;
                default: break;
            }
            ProcessStartInfo sInfo = new ProcessStartInfo(url);
            Process.Start(sInfo);
        }
    }
}
