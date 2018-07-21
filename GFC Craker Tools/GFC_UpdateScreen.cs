using GFC_Tools;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GFC_Craker_Tools
{
    public partial class GFC_UpdateScreen : Form
    {
        

        static Variables variables = new Variables();
        private static GFC_Func _Func = new GFC_Func();
        static GFC_MainScreen GFC_MainScreen = new GFC_MainScreen();

        Point mouseDownPoint = Point.Empty;

        public GFC_UpdateScreen()
        {
            InitializeComponent();
            ShowUpdateInfo();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            try
            {
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.BaseDirectory + @"\\Temp\\setup1.msi");
                Application.Exit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
           
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.DialogResult = DialogResult.No;
            this.Close();
        }


        private void ShowUpdateInfo()
        {
            label3.Text = "Version: " + variables.UpdateVersion;
            button1.Show();
            button2.Show();
        }

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GFC_UpdateScreen_Load(object sender, EventArgs e)
        {

        }
    }
}