﻿using GFC_Tools;
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

        public static void UpdateGFC()
        {
            string uri = ReadSiteXml(Variables.ConfigUrl,"//gfc/updater", "GFC_ToolURL");
            String path = System.AppDomain.CurrentDomain.BaseDirectory + @"\\Temp";
            string filename = path + "\\setup1.msi";

            try
            {
                if (!Directory.Exists(filename))
                {
                    Directory.CreateDirectory(filename);
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

            System.Diagnostics.Process.Start(filename);
            Application.Exit();
        }

        private static void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Dowload is 100 % Complete");

        }

        private static void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("Dowload is "+ e.ProgressPercentage + " Complete");
        }

        public static void launchFile(string fn)
        {
            //majority was taken from
            //https://stackoverflow.com/questions/24954/windows-list-and-launch-applications-associated-with-an-extension
            const string extPathTemplate = @"HKEY_CLASSES_ROOT\{0}";
            const string cmdPathTemplate = @"HKEY_CLASSES_ROOT\{0}\shell\open\command";

            string ext = Path.GetExtension(fn);

            var extPath = string.Format(extPathTemplate, ext);

            var docName = Registry.GetValue(extPath, string.Empty, string.Empty) as string;
            if (!string.IsNullOrEmpty(docName))
            {
                // 2. Find out which command is associated with our extension
                var associatedCmdPath = string.Format(cmdPathTemplate, docName);
                var associatedCmd = Registry.GetValue(associatedCmdPath, string.Empty, string.Empty) as string;

                if (!string.IsNullOrEmpty(associatedCmd))
                {
                    //Console.WriteLine("\"{0}\" command is associated with {1} extension", associatedCmd, ext);
                    var p = new Process();
                    p.StartInfo.FileName = associatedCmd.Split(' ')[0];
                    string s2 = associatedCmd.Substring(p.StartInfo.FileName.Length + 1);
                    s2 = s2.Replace("%1", string.Format("\"{0}\"", fn));
                    p.StartInfo.Arguments = s2;//string.Format("\"{0}\"", fn);
                    p.Start();
                }
            }
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

