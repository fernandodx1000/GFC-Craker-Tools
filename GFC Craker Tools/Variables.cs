using GFC_Craker_Tools;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GFC_Tools
{
    public class Variables
    {

        static GFC_Func GFC_Func = new GFC_Func();

        public string CurentVersion;
        public string MrUrl = "http://gfcdownloads.co.nf/download/gfc/?wpdmdl=80";
        public static string ConfigUrl = "http://gfcdownloads.co.nf/gfc_crack_tool/gfc-setings.xml";
        public string UpdateVersion = GFC_Func.ReadSiteXml(ConfigUrl, "//gfc/config", "version");

           public Version version = Assembly.GetEntryAssembly().GetName().Version;

        public void Main()
        {
            CurentVersion = version.ToString();
            Console.WriteLine(CurentVersion);
        }


    }
}
