using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp2
{
    class Program
    {

        [DllImport("user32.dll")]
        private static extern int ShowWindow(int Handle, int showState);
        [DllImport("kernel32.dll")]
        public static extern int GetConsoleWindow();

        static void Main(string[] args)
        {
            int win = GetConsoleWindow();
            ShowWindow(win, 1);

            Console.WriteLine("Starting GFC_Updater !");

            while (true)
            {
                Console.WriteLine("hehe");
                CheckForUpdate();

                System.Threading.Thread.Sleep(300);

            }

        }   

        private static void CheckForUpdate()
        {
            



        }

        private string ReadSiteXml(string url, string selectnodes, string nodetoread)//string url, string node1
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
    }
}
