using GFC_Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GFC_Craker_Tools
{
    public partial class GFC_SplashScreen : Form
    {
        private static GFC_UpdateScreen _UpdateScreen = new GFC_UpdateScreen();
        private static GFC_ResourceManager _ResourceManager = new GFC_ResourceManager();
        private static GFC_Updater _Updater = new GFC_Updater();
        private static GFC_Func _Func = new GFC_Func();
        private static Variables variables = new Variables();
      
        public GFC_SplashScreen()
        {
            InitializeComponent();
            //backgroundWorker1.RunWorkerAsync();

            
            progressBar1.Increment(15);
           // _Updater();
            progressBar1.Increment(15);
            _ResourceManager.Start();
            label1.Text = "Downloading Resources";
            progressBar1.Increment(15);
            progressBar1.Increment(15);
           
            Application.Run(new GFC_MainScreen());


        }

        private void GFC_SplashScreen_Load(object sender, EventArgs e)
        {

            


        }

        public void SetLabelText(string s1)
        {
            label1.Text = s1;
        }

    
        private void GFC_SplashScreen_Shown(object sender, EventArgs e)
        {

            

            
        }

        private static bool NeedsToUpdate()
        {
            String curentversion = variables.GetCurentVersion();

            Version FCversion = Version.Parse(curentversion);
            Version FUversion = Version.Parse(variables.UpdateVersion);


            if (FCversion < FUversion)
            {
                Console.WriteLine("Version " + variables.UpdateVersion + " is available!");

                string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                var directory = System.IO.Path.GetDirectoryName(path);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("vou me variar ");
            progressBar1.Increment(5);
            label1.Text = "cona é bom";
            progressBar1.Increment(5);
            label1.Text = "Mas so depois do cu";
            progressBar1.Increment(5);


            if (NeedsToUpdate())
            {
                SetLabelText("Reading Update DATA!");

                //_Func.UpdateGFC();

                

                if (_UpdateScreen.ShowDialog(this) == DialogResult.OK)
                {
                    //do processing
                }
                if (_UpdateScreen.ShowDialog(this) == DialogResult.No)
                {
                    Console.WriteLine("NO ! mother fuker !");
                }


            }
            //check for update 
            //set up PATORico Manager
            //set up resources



            this.Close();


        }
    }
}
