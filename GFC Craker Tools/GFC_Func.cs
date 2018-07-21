using GFC_Tools;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;
using System.Security.Principal;
using System.Security.Permissions;

namespace GFC_Craker_Tools
{
    class GFC_Func
    {

        static GFC_Crack.GFC_CCleaner GFC_CCleaner = new GFC_Crack.GFC_CCleaner();

        public void SwCrack(string software)
        {

            switch (software)
            {
                case "CCleaner":
                    GFC_CCleaner.Main();
                    break;
                default:
                    Console.WriteLine("Unknown Software " + software);
                    break;
            }


        }
        public static string ReadSiteXml(string url, string selectnodes, string nodetoread)//string url, string node1
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(url);
            XmlElement root = doc1.DocumentElement;
            XmlNodeList nodes = root.SelectNodes(selectnodes);

            string nodestring;
            foreach (XmlNode node in nodes)
            {
                nodestring = node[nodetoread].InnerText;

                return nodestring;
            }
            return null;
        }

        public void UpdateGFC()
        {
            string uri = ReadSiteXml(Variables.ConfigUrl,"//gfc/updater", "GFC_ToolURL");
            String path = System.AppDomain.CurrentDomain.BaseDirectory + "\\Temp";
            string filename = System.AppDomain.CurrentDomain.BaseDirectory + @"\\Temp\\setup1.msi";

            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                    UpdateGFC();
                }
                else
                {

                    WebClient wc = new WebClient();
                    wc.DownloadFile(new Uri(uri), filename);
                    //wc.DownloadDataAsync(new Uri(uri), filename);
                    wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);   
                    wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message.ToString());
                MessageBox.Show(ex.ToString());
            }
            try
            {
               // System.Diagnostics.Process.Start(filename);
//para tirar               // Application.Exit();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message.ToString());
                MessageBox.Show(ex.ToString());
            }
           
        }

        private static void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Dowload is 100 % Complete");

        }

        private static void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("Dowload is "+ e.ProgressPercentage + " Complete");
        }

    
        public  void AdminRelauncher()
        {
            if (!IsRunAsAdmin())
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.UseShellExecute = true;
                proc.WorkingDirectory = Environment.CurrentDirectory;
                proc.FileName = Assembly.GetEntryAssembly().CodeBase;

                proc.Verb = "runas";

                try
                {
                    Process.Start(proc);
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("This program must be run as an administrator! \n\n" + ex.ToString());
                }
            }
        }

        private bool IsRunAsAdmin()
        {
            try
            {
                WindowsIdentity id = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(id);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}

