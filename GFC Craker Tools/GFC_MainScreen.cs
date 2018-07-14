using GFC_Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GFC_Craker_Tools
{
    public partial class GFC_MainScreen : Form
    {
        static Variables variables = new Variables();
        static GFC_Func gfc_Func = new GFC_Func();

        public int Tab = 1;//0 News - 1- cracks- 2games- 

        public Image ImageInstall;

        public GFC_MainScreen()
        {
            this.Hide();
            InitializeComponent();
             
   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            variables.Main();
            Tab = 0;

        }

        private void setInstallImage()
        {
            if (Tab == 1)
            {
                ImageInstall = imageList1.Images[listView1.SelectedItems[0].ImageIndex];
                changeTab(1);
            }
            if (Tab == 2)
            {
                ImageInstall = imageList2.Images[listView1.SelectedItems[0].ImageIndex];

                changeTab(2);

            }
        }
        
        // Click Na Imagem
        String selected;

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            selected = listView1.SelectedItems[0].Text;
            var item = listView1.SelectedItems[0];

            setInstallImage();

            Form1 test = new Form1(selected, ImageInstall);
            test.ShowDialog();
        }

       
      
        //exit Buton
        private void panel5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        // label version
        private void label5_Paint(object sender, PaintEventArgs e)
        {
            label5.Text = "Version: " + variables.CurentVersion;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changeTab(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            changeTab(2);
        }

        private void changeTab(int TabToChange)
        {
            if (TabToChange == 0)
            {
             //desatctivar listviwe.   
            }
            if (TabToChange == 1)
            {
                Tab = 1;
                listView1.Clear();
                this.listView1.LargeImageList = this.imageList1;
                Populatesw();
                
            }
            if (TabToChange == 2)
            {
                Tab = 2;
                listView1.Clear();
                this.listView1.LargeImageList = this.imageList2;
                PopulateGames();
            }

           
        }

        bool p1 = true;
        bool p2 = true;
        private void Populatesw()
        {

            DirectoryInfo dir = new DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory + "Resources/Images/Softwares/Icons");
            this.listView1.View = View.LargeIcon;
            this.imageList1.ImageSize = new Size(100, 100);
            this.listView1.LargeImageList = this.imageList1;
            int j = 0;

            if (p1)
            {

                foreach (FileInfo file in dir.GetFiles())
                {
                    try
                    {
                        //this.imageList1.Images.Add(Image.FromFile(file.FullName));

                        string input = file.Name;
                        int index = input.IndexOf(".");
                        if (index > 0) { input = input.Substring(0, index); }


                        imageList1.Images.Add(input, Image.FromFile(file.FullName));
                        ListViewItem item = new ListViewItem(input);
                        //item.Tag = file.Name;

                        item.Tag = input;
                        item.ImageIndex = j;
                        this.listView1.Items.Add(item);
                        j++;
                    }
                    catch
                    {
                        Console.WriteLine("This is not an image file");
                    }
                }

            }


        }

        private void PopulateGames()
        {

            DirectoryInfo dir2 = new DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory + "Resources/Images/Games/Icons");
            this.listView1.View = View.LargeIcon;
            this.imageList2.ImageSize = new Size(100, 100);
            this.listView1.LargeImageList = this.imageList2;
            int j = 0;

            if (p2)
            {
                foreach (FileInfo file in dir2.GetFiles())
                {
                    try
                    {
                        //this.imageList1.Images.Add(Image.FromFile(file.FullName));

                        string input = file.Name;
                        int index = input.IndexOf(".");
                        if (index > 0) { input = input.Substring(0, index); }


                        imageList2.Images.Add(input, Image.FromFile(file.FullName));
                        ListViewItem item = new ListViewItem(input);
                        //item.Tag = file.Name;

                        item.Tag = input;
                        item.ImageIndex = j;
                        this.listView1.Items.Add(item);
                        j++;
                    }
                    catch
                    {
                        Console.WriteLine("This is not an image file");
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
