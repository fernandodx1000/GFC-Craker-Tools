using GFC_Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GFC_Craker_Tools
{
    class GFC_ResourceManager
    {
        private static Variables variables = new Variables();
        private static GFC_SplashScreen _SplashScreen = new GFC_SplashScreen();

        public void Start()
        {
            Console.WriteLine("-Resource Manager Started.");

            try
            {
             
                UpdateResources();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void UpdateResources()
        {
            try
            {
                String MainPath = System.AppDomain.CurrentDomain.BaseDirectory;
                String ResourcesDirectoryPath = MainPath + "\\Resources\\Images";
                String ResourcesUrl = GFC_Func.ReadSiteXml(variables.ConfigUrl1, "//gfc/updater", "gfc_resources");//to addd 
                String ResourcesFileName = MainPath + "\\Temp\\gfc_ resources.zip";


                if (Directory.Exists(ResourcesDirectoryPath))
                {
                    Directory.Delete(ResourcesDirectoryPath, true);
                }

                WebClient wc = new WebClient();
                wc.DownloadFile(new Uri(ResourcesUrl), ResourcesFileName);

                ZipFile.ExtractToDirectory(ResourcesFileName, ResourcesDirectoryPath);
                File.Delete(ResourcesFileName);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


    }
}
