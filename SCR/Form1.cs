using System;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Windows.Forms;
using System.Diagnostics;

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



                var tempsource = "apptest";
                var logname = "LOG" + BaseService.MyServiceName;

                //if (EventLog.Exists(tempsource, System.Environment.MachineName))
                //    EventLog.Delete(tempsource, System.Environment.MachineName);

                //if (EventLog.SourceExists(tempsource, System.Environment.MachineName))
                //    EventLog.DeleteEventSource(tempsource, System.Environment.MachineName);


                //EventLog.CreateEventSource(tempsource, logname, System.Environment.MachineName);

                if (EventLog.SourceExists(BaseService.MyServiceName, System.Environment.MachineName))
                { 
                    EventLog.DeleteEventSource(BaseService.MyServiceName, System.Environment.MachineName);
                    }
                else
                {
                    EventLog.CreateEventSource(BaseService.MyServiceName, logname, System.Environment.MachineName);
                    //EventLog.DeleteEventSource(BaseService.MyServiceName, System.Environment.MachineName);
                }


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
                if (EventLog.Exists(BaseService.MyServiceName,System.Environment.MachineName))
                EventLog.Delete(BaseService.MyServiceName,System.Environment.MachineName);


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