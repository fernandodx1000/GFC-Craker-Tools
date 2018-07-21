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
            MessageBox.Show("Not Inplemented yet!");
            //Console.WriteLine(ProgramToCrack);
            //GFC_Func.SwCrack(ProgramToCrack);
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = ImageToShow;

            if(ProgramToCrack == "CCleaner")
            {
                richTextBox1.AppendText(Environment.NewLine);
                richTextBox1.AppendText("You Need to turn off Internet Before Using Serial");
                richTextBox1.AppendText(Environment.NewLine);

            }

            string si = button1.Text;
            button1.Text = si + " "+ProgramToCrack; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Point mouseDownPoint = Point.Empty;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownPoint = Point.Empty;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownPoint.IsEmpty)
                return;
            Form f = sender as Form;
            f.Location = new Point(f.Location.X + (e.X - mouseDownPoint.X), f.Location.Y + (e.Y - mouseDownPoint.Y));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random ri = new Random();
            int i = ri.Next(1,7);

            if (i == 1) { MessageBox.Show("serial: C2YW - 2BAM - ADC2 - 89RV - YZPC"); }
            if (i == 2) { MessageBox.Show("serial: C2YW - XFCX - ABIG - GZD4 - 8ZPC "); }
            if (i == 3) { MessageBox.Show("serial: C2YW - XK32 - GBVV - N3BH - 2ZPC"); }
            if (i == 4) { MessageBox.Show("serial: C2YW - IAHG - ZU62 - INZQ - WZPC "); }
            if (i == 5) { MessageBox.Show("serial: C2YW - JKW5 - KK79 - XHR2 - 4ZPC"); }
            if (i == 6) { MessageBox.Show("serial: C2YW - QTRT - ZVCG - PQDK - CZPC"); }
            if (i == 7) { MessageBox.Show("serial: C2YW - GP33 - TPIU - BGM8 - AZPC"); }
            
        }
    }
}
