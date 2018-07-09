using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace GFC_Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = Task.Run((Action)CheckForUpdates);
       
        }

        static void CheckForUpdates()
        {
            while (true)
            { 
                
            }
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
    }
}
