/*
 * Created by SharpDevelop.
 * User: m.ghaemi
 * Date: 26/10/1394
 * Time: 04:27 ب.ظ
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ServiceProcess;
using System.Diagnostics;

namespace Self_Installer_service
{
    public class BaseService : ServiceBase
    {
        private static System.Timers.Timer tt;
        public const string MyServiceName = "SelfInstallerService";
        public const string Description = "create by mojtaba ghaemi for Self Installer Service مجتبی قائمی sharpboy@gmail.com";
        public const string DisplayName = "Self Installer Service";
        private static System.Diagnostics.EventLog MYeventLog;

        public BaseService()
        {
            InitializeComponent();

        }

        private void InitializeComponent()
        {

            this.ServiceName = BaseService.MyServiceName;



            //System.Diagnostics.Debugger.Launch();
            try
            {
                var logname = "LOG" + ServiceName;

                //if (!EventLog.SourceExists(ServiceName))
                //{
                //    EventLog.CreateEventSource(ServiceName, logname);
                //}
                //else
                //{
                //    if (ServiceName != EventLog.LogNameFromSourceName(ServiceName, "."))
                //    {
                //        //EventLog.Delete(ServiceName, System.Environment.MachineName);
                //        //EventLog.CreateEventSource(ServiceName, logname);
                //    }
                //}

                MYeventLog = new System.Diagnostics.EventLog();
                MYeventLog.Source = ServiceName;
                MYeventLog.Log = logname;
                MYeventLog.MachineName = System.Environment.MachineName;
                MYeventLog.WriteEntry("log install", EventLogEntryType.FailureAudit);


                tt = new System.Timers.Timer(5000);
                tt.Elapsed += new System.Timers.ElapsedEventHandler(ttevent);

            }
            catch (Exception ex)
            {

                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "_startservice.txt"))
                {
                    sw.WriteLine("err " + ex.ToString());
                    sw.Close();
                }

            }
        }

        protected override void Dispose(bool disposing)
        {
            tt.Dispose();
            base.Dispose(disposing);
        }

        protected override void OnStart(string[] args)
        {
            ////MYeventLog.WriteEntry("aaaaaaaa");
            //while (DateTime.Now.Millisecond != 0)
            //{
            //    //Console.WriteLine("timer{0} ",DateTime.Now.Millisecond );
            //}

            tt.Enabled = true;
        }

        /// <summary>
        /// Stop this service.
        /// </summary>
        protected override void OnStop()
        {
        }

        private static void ttevent(object sender, System.Timers.ElapsedEventArgs e)
        {
            MYeventLog.WriteEntry(("timer" + DateTime.Now.ToString("HH:mm:ss:f")),EventLogEntryType.Information);
        }
    }
}