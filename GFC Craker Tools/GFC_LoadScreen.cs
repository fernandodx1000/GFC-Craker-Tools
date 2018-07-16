using GFC_Tools;
using System;
using System.Drawing;
using System.Threading;
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
            pictureBox1.Hide();
            label3.Text = "Version: "+ variables.UpdateVersion;
            label4.Text = "This Is Version: " + variables.version.ToString();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GFC_MainScreen.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void update()
        {
            label2.Hide();
            label3.Hide();
            label4.Hide();
            button1.Hide();
            button2.Hide();
            pictureBox1.Show();

            // GFC_Func.UpdateGFC()
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                GFC_Func.UpdateGFC();
            }).Start();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
    }
}