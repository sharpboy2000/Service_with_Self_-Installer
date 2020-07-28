/*
 * Created by SharpDevelop.
 * User: m.ghaemi
 * Date: 26/10/1394
 * Time: 04:27 ب.ظ
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;
using System.Text;

namespace Self_Installer_service
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller serviceProcessInstaller;
        private ServiceInstaller serviceInstaller;

        public ProjectInstaller()
        {
            serviceProcessInstaller = new ServiceProcessInstaller();

            serviceInstaller = new ServiceInstaller();
            // Here you can set properties on serviceProcessInstaller or register event handlers
            serviceProcessInstaller.Account = ServiceAccount.LocalService;
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.ServiceName = BaseService.MyServiceName;
            serviceInstaller.Description = BaseService.Description;
            serviceInstaller.DisplayName = BaseService.DisplayName;

            serviceInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceInstaller1_AfterInstall);

            this.Installers.AddRange(new Installer[] { serviceProcessInstaller, serviceInstaller });
        }

        public override void Install(IDictionary stateSaver)
        {
            var path = new StringBuilder(Context.Parameters["assemblypath"]);
            if (path[0] != '"')
            {
                path.Insert(0, '"');
                path.Append('"');
            }
            path.Append(" --service");
            Context.Parameters["assemblypath"] = path.ToString();
            base.Install(stateSaver);
        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
            try
            {
                using (ServiceController sc = new ServiceController(serviceInstaller.ServiceName, Environment.MachineName))
                {
                    if (sc.Status != ServiceControllerStatus.Running)
                        sc.Start();
                }
            }
            catch (Exception ee)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "_istallerr.txt"))
                {
                    sw.WriteLine("catch AfterInstall " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:f"));
                    sw.WriteLine("err " + ee.ToString());
                    sw.Close();
                }
            }
        }
    }
}