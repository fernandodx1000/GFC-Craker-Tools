﻿using GFC_Tools;
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

        public GFC_MainScreen()
        {
            InitializeComponent();
            Populate();
        }

        private void Populate()
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
                    imageList1.Images.Add(file.Name, Image.FromFile(file.FullName));
                    ListViewItem item = new ListViewItem(file.Name);
                    item.Tag = file.Name;
                    item.ImageIndex = j;
                    this.listView1.Items.Add(item);
                    j++;
                }
                catch
                {
                    Console.WriteLine("This is not an image file");
                }
            }

            /*
            DirectoryInfo dir = new DirectoryInfo(@"H:\Documentos\projectos c#\GFC Craker Tools\GFC Craker Tools\Resources\Images\Softwares\Icons");

            foreach (FileInfo file in dir.GetFiles())

            {
                try

                {

                    this.imageList1.Images.Add(Image.FromFile(file.FullName));

                }

                catch
                {

                    Console.WriteLine("This is not an image file");

                }

            }

            this.listView1.View = View.LargeIcon;
            this.listView1.Columns.Add("tet", 150);
            this.imageList1.ImageSize = new Size(128, 128);

            this.listView1.LargeImageList = this.imageList1;

            for (int j = 0; j < this.imageList1.Images.Count; j++)

            {

                ListViewItem item = new ListViewItem();

                item.ImageIndex = j;

                this.listView1.Items.Add(item.Text, j);

            }
            */
        }

        // Click Na Imagem
        String selected;
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
             selected = listView1.SelectedItems[0].Text;
            MessageBox.Show(selected);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            variables.Main();
        }

        private void panel3_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];
            selected = item.Tag.ToString();

            string s1;
           s1 = selected.Remove(selected.Count() - 3, selected.Count());
            gfc_Func.SwCrack(selected);
            MessageBox.Show(s1);
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}