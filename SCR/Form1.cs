using System;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Windows.Forms;

namespace Self_Installer_service
{
    public partial class Form1 : Form
    {
        private ServiceController sc;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServiceCheck();
        }

        private void ServiceCheck()
        {
            sc = ServiceController.GetServices()
                .FirstOrDefault(s => s.ServiceName == BaseService.MyServiceName);

            if (sc == null)
            {
                ServiceInstall.Text = "Install Service";
            }
            else
            {
                ServiceInstall.Text = "Unstall Service";
                //sc.Status == ServiceControllerStatus.Running
            }
        }

        private void ServiceInstall_Click(object sender, EventArgs e)
        {
            ServiceInstall.Enabled = false;
            if (sc == null)
            {
                ManagedInstallerClass.InstallHelper(new string[] { "/1", Assembly.GetExecutingAssembly().Location });

                sc = ServiceController.GetServices()
                    .FirstOrDefault(s => s.ServiceName == BaseService.MyServiceName);
                sc.WaitForStatus(ServiceControllerStatus.Running);

                if (sc.Status == ServiceControllerStatus.Running)
                {
                    //sc.Stop();
                }
                else
                {
                    //sc.Start();
                }
            }
            else
            {
                ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
            }
            ServiceCheck();
            ServiceInstall.Enabled = true;
        }

        private void ServiceMode_Click(object sender, EventArgs e)
        {
        }
    }
}