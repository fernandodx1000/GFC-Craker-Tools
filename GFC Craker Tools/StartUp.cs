using System;
using System.Collections.Generic;
using System.Linq;
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


        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread t = new Thread(LoadMainScreen);
            t.Start();
            GFC_Func func = new GFC_Func();
            func.CheckForUpdate();
        }

        private static void LoadScreen()
        {
            Application.Run(new GFC_LoadScreen());

        }

        private static void LoadMainScreen()
        {
            Application.Run(new GFC_MainScreen());
        }

    }
}
