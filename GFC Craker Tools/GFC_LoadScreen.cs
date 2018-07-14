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
    public partial class GFC_LoadScreen : Form
    {
        static Variables variables = new Variables();
        static GFC_Func gfc_Func = new GFC_Func();
        static GFC_MainScreen GFC_MainScreen = new GFC_MainScreen();




        public GFC_LoadScreen()
        {
            InitializeComponent();
            label3.Text = "Version: "+ variables.UpdateVersion;
            label4.Text = "This Is Version: " + variables.version.ToString();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GFC_Func.UpdateGFC();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GFC_MainScreen.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}