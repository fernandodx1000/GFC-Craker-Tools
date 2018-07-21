using System;
using System.Net;
using System.Windows.Forms;

namespace GFC_Craker_Tools
{
     class StartUp 
    {
        [STAThread]
        static void Main()
        {

            //Init Point
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //check for internet
            if (!CheckForInternetConnection())
            {
                MessageBox.Show("You Need Internet To Run The Program. Program Will Quit !");
                Application.Exit();
            }
            Application.Run(new GFC_MainScreen());

            MessageBox.Show("-This Is In DEV ! \n" +
                "-Bugs Are Expected !");

        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        } 
    }
}
