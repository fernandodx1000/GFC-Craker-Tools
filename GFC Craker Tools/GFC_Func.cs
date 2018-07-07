using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GFC_Craker_Tools
{
    class GFC_Func
    {
        public void SwCrack(string software)
        {

            switch (software)
            {
                case"CCleaner":
                    Console.WriteLine("ccleaner");



                    break;
                default:
                    Console.WriteLine("Unknown Software " + software);
                    break;
            }


        }
        public string ReadSiteXml(string url,string selectnodes, string nodetoread)//string url, string node1
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
