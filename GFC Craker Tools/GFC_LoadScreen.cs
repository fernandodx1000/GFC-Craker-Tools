using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            bool b = true;
            while (b)
            {
                if (progressBar1.Value < 100)
                {
                    progressBar1.Value++;
                }
                else
                {

                    
                    b = false;
                }


            }

            Application.Exit();
        }
       
        private void GFC_LoadScreen_Load(object sender, EventArgs e)
        {
            
            
        }

    }
}