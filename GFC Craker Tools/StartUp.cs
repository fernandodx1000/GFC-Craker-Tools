using GFC_Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GFC_Craker_Tools
{
    static class StartUp
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static Variables variables = new Variables();
        private static GFC_Func func = new GFC_Func();

        [STAThread]
        static void Main()
        {
            GFC_Func func = new GFC_Func();
           // func.AdminRelauncher();

            variables.Main();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            CheckForUpdate();
        }

        private static void LoadScreen()
        {
            Application.Run(new GFC_LoadScreen());

        }

        private static void LoadMainScreen()
        {
            Application.Run(new GFC_MainScreen());
        }

        public static void CheckForUpdate()
        {
            String curentversion = variables.CurentVersion;
            

            if (curentversion != variables.UpdateVersion)
            {
                Console.WriteLine("Version " + variables.UpdateVersion + " is available!");

                string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                var directory = System.IO.Path.GetDirectoryName(path);

                
                Console.WriteLine(directory);
                LoadScreen(); 
            }
            else
            {
                Thread t = new Thread(LoadMainScreen);
                t.Start();
            }

        }


        
    }
}
