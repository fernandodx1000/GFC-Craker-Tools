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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

            this.imageList1.ImageSize = new Size(128, 128);

            this.listView1.LargeImageList = this.imageList1;

            //or

            //this.listView1.View = View.SmallIcon;

            //this.listView1.SmallImageList = this.imageList1;



            for (int j = 0; j < this.imageList1.Images.Count; j++)

            {

                ListViewItem item = new ListViewItem();

                item.ImageIndex = j;

                this.listView1.Items.Add(item);

            }

        }

       
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
