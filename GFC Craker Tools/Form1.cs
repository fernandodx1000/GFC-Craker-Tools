using GFC_Tools;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GFC_Craker_Tools
{
    public partial class Form1 : Form
    {
        string ProgramToCrack;
        static GFC_Func GFC_Func = new GFC_Func();
        static GFC_MainScreen GFC_MainScreen = new GFC_MainScreen();
        static Variables variables = new Variables();
        static Image ImageToShow;

        public Form1(string program, Image image)
        { 
            InitializeComponent();
            ProgramToCrack = program;
            richTextBox1.Text = ProgramToCrack;
           ImageToShow = image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GFC_Func.launchFile(@"C:\setup.exe");
            Console.WriteLine(ProgramToCrack);
            GFC_Func.SwCrack(ProgramToCrack);
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = ImageToShow;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
