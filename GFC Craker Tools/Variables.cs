using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GFC_Tools
{
    public class Variables
    {

        public string CurentVersion;
        Version version = Assembly.GetEntryAssembly().GetName().Version;

        public string MrUrl = "http://gfcdownloads.co.nf/download/gfc/?wpdmdl=80";

        public void Main()
        {
            CurentVersion = version.ToString();
            Console.WriteLine(CurentVersion);
        }


    }
}
