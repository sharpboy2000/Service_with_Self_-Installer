/*
 * Created by SharpDevelop.
 * User: m.ghaemi
 * Date: 26/10/1394
 * Time: 04:27 ب.ظ
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
//using System.Linq;

using System.Linq;
using System.Net.Mime;
using System.Reflection ;
using System.Windows.Forms;

namespace Self_Installer_service

{

	
	static class Program
	{
		/// <summary>
		/// This method starts the service.
		/// </summary>
		static void Main()
		{
            if (Environment.UserInteractive)

            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());

            }
            else
            {
                // To run more than one service you have to add them here
                ServiceBase.Run(new ServiceBase[] { new BaseService() });
            }

        }
    }

    /*
ConsoleKeyInfo cki;
Console.WriteLine("service "+ BaseService.MyServiceName+" DisplayName "+ BaseService.DisplayName );

ServiceController sc = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == BaseService.MyServiceName);
if(sc==null)
    {
        Console.WriteLine(BaseService.MyServiceName+" Is Not installed");
        Console.WriteLine("Do you want install:(y) \n");
        cki = Console.ReadKey();
        if (cki.Key.ToString()=="Y")
        {
        Console.WriteLine(BaseService.MyServiceName+" Is Start install");
         ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
        }
    }
    else 
    {
        Console.WriteLine(BaseService.MyServiceName+" Is Start installed and Status:" +sc.Status);
        Console.WriteLine("For uninstall peree:(1)");
        if (sc.Status== ServiceControllerStatus.Running)
            Console.WriteLine("For Stop      peree:(2)");
            else 					
            Console.WriteLine("For Start     peree:(2)");

        cki = Console.ReadKey();
        if(cki.Key == ConsoleKey.D1 || cki.Key == ConsoleKey.NumPad1 )
        {
         Console.WriteLine(BaseService.MyServiceName+" Is Start UNinstall");
         ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
        }
        else 
        {
            if (sc.Status== ServiceControllerStatus.Running)
                sc.Stop();
            else 					
                sc.Start();

        }

    //	 try
          //{
    //		sc.Start();
    //		sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMilliseconds(100));
          //}
          //catch
          //{
          //	Console.WriteLine( "err" );
          //}	

    */
}


		//Console.ReadKey() ;


