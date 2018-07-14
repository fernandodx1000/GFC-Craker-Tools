using GFC_Tools;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using GFC_Craker_Tools.GFC_Crack;


namespace GFC_Craker_Tools
{
    class GFC_Func
    {

        static GFC_IOBit GFC_CCleaner = new GFC_IOBit();


        

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
            string filename = System.AppDomain.CurrentDomain.BaseDirectory + "Temp/setup.exe";

            try
            {
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                else
                {
                    WebClient wc = new WebClient();
                    wc.DownloadDataAsync(new Uri(uri), filename);
                   // wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                 //   wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message.ToString());
            }


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
        
    }
}

