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
    public partial class GFC_LoadScreen : Form
    {

        static GFC_MainScreen GFC_MainScreen = new GFC_MainScreen();

       
       public GFC_LoadScreen()
        {
            InitializeComponent();
            //Thread t = new Thread(test);
            //t.Start();
            test();
            
        }
       
        private void GFC_LoadScreen_Load(object sender, EventArgs e)
        {

           

        }


        private void test()
        {
            bool b = true;
            while (b)
            {
                if (progressBar1.Value == 100)
                {
                    GFC_MainScreen.Show();
                    this.Hide();
                    b = false;
                }
                else
                {
                    progressBar1.Value++;
                   // Thread.Sleep(1000);

                }

            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}