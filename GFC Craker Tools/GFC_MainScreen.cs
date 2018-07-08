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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GFC_Craker_Tools
{
    public partial class GFC_MainScreen : Form
    {
        static Variables variables = new Variables();
        static GFC_Func gfc_Func = new GFC_Func();

        public int Tab = 1;

        public GFC_MainScreen()
        {
            InitializeComponent();
            Populatesw();

        }
       
        private void Populatesw()
        {
            DirectoryInfo dir = new DirectoryInfo(@"H:\Documentos\projectos c#\GFC Craker Tools\GFC Craker Tools\Resources\Images\Softwares\Icons");
            this.listView1.View = View.LargeIcon;
            this.imageList1.ImageSize = new Size(100, 100);
            this.listView1.LargeImageList = this.imageList1;
            int j = 0;
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
        
        private void PopulateGames()
        {

            DirectoryInfo dir = new DirectoryInfo(@"H:\Documentos\projectos c#\GFC Craker Tools\GFC Craker Tools\Resources\Images\Games\Icons");
            this.listView1.View = View.LargeIcon;
            this.imageList2.ImageSize = new Size(100, 100);
            this.listView1.LargeImageList = this.imageList2;
            int j = 0;
            foreach (FileInfo file in dir.GetFiles())
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


        // Click Na Imagem
        String selected;
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            selected = listView1.SelectedItems[0].Text;
            Form1 test = new Form1(selected, listView1.SelectedItems[0].Index);
            Console.WriteLine(listView1.SelectedItems[0].Index);
            //test.ShowDialog();
            //this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            variables.Main();
            Tab = 1;

        }

      /*  private void panel3_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];
            selected = item.Tag.ToString();

            string s1;
            s1 = selected.Remove(selected.Count() - 3, selected.Count());
            gfc_Func.SwCrack(selected);
            MessageBox.Show(s1);
        }
        */
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
                
            }
            if (TabToChange == 1)
            {
                listView1.Clear();
                Populatesw();
                Tab = 1;
            }
            if (TabToChange == 2)
            {
                listView1.Clear();
                PopulateGames();
                Tab = 2;
            }
        }


    }
}
