using GFC_Tools;
using System;
using System.Windows.Forms;

namespace GFC_Craker_Tools
{
    public partial class Form1 : Form
    {
        string ProgramToCrack;
        static GFC_Func GFC_Func = new GFC_Func();
        static GFC_MainScreen GFC_MainScreen = new GFC_MainScreen();
        static Variables variables = new Variables();

        private int ImgIndex;
     
        public Form1(string program, int imgIndex)
        { 
            InitializeComponent();
            ProgramToCrack = program;

            ImgIndex = imgIndex;

            if (GFC_MainScreen.Tab == 1)
            {

                pictureBox1.Image = GFC_MainScreen.imageList1.Images[ImgIndex];

            }
            if (GFC_MainScreen.Tab == 2)
            {

                pictureBox1.Image = GFC_MainScreen.imageList2.Images[ImgIndex];

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GFC_Func.SwCrack(ProgramToCrack);
        }
        [STAThread]
        private void Form1_Load(object sender, EventArgs e)
        {/*
            if (GFC_MainScreen.Tab == 1)
            {

                pictureBox1.Image = GFC_MainScreen.imageList1.Images[ImgIndex];

            }
            if (GFC_MainScreen.Tab == 2)
            {

                pictureBox1.Image = GFC_MainScreen.imageList2.Images[ImgIndex];

            }
           */

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
