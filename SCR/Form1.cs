using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration.Install;
using System.Reflection;
using System.ServiceProcess;

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
            if (sc == null)
            {
                ManagedInstallerClass.InstallHelper(new string[] {Assembly.GetExecutingAssembly().Location});

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
                ManagedInstallerClass.InstallHelper(new string[] {"/u", Assembly.GetExecutingAssembly().Location});
                
            }
            ServiceCheck();
        }
    }
}
