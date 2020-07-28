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

namespace Self_Installer_service
{
    public class BaseService : ServiceBase
    {
        private static System.Timers.Timer tt;
        private static int x;
        private static System.IO.StreamWriter sw = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + MyServiceName + "_Log.txt", true);
        public const string MyServiceName = "SelfInstallerService";

        //public const string MyServiceName = AppDomain.CurrentDomain.FriendlyName ;
        public const string Description = "create by mojtaba ghaemi for Self Installer Service مجتبی قائمی sharpboy@gmail.com";

        public const string DisplayName = "Self Installer Service";
        private static System.Diagnostics.EventLog MYeventLog;

        public BaseService()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.Diagnostics.Debugger.Launch();

            this.ServiceName = BaseService.MyServiceName;

            MYeventLog = this.EventLog;

            if (!System.Diagnostics.EventLog.Exists("momila"))
            {
                System.Diagnostics.EventLog.CreateEventSource("momila", "momila");
            }

            //MYeventLog.Log = ServiceName;
            //MYeventLog.Source = ServiceName;

            tt = new System.Timers.Timer(500);
            tt.Elapsed += new System.Timers.ElapsedEventHandler(ttevent);
            sw.AutoFlush = true;
            sw.WriteLine("new Initialize " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:f"));
        }

        protected override void Dispose(bool disposing)
        {
            tt.Dispose();
            sw.Close();
            sw.Dispose();
            base.Dispose(disposing);
        }

        protected override void OnStart(string[] args)
        {
            sw.WriteLine("new start " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:f"));
            this.EventLog.WriteEntry("aaaaaaaa");
            while (DateTime.Now.Millisecond != 0)
            {
                //Console.WriteLine("timer{0} ",DateTime.Now.Millisecond );
            }

            tt.Enabled = true;
        }

        /// <summary>
        /// Stop this service.
        /// </summary>
        protected override void OnStop()
        {
            sw.WriteLine("new stop " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:f"));
        }

        private static void ttevent(object sender, System.Timers.ElapsedEventArgs e)
        {
            x++;
            sw.WriteLine(DateTime.Now.ToString("HH:mm:ss:f"));
            Console.WriteLine("timer{0} , {1}", x, DateTime.Now.ToString("HH:mm:ss:f"));
            MYeventLog.WriteEntry(("timer" + DateTime.Now.ToString("HH:mm:ss:f")));
        }
    }
}