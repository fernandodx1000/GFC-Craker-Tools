using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFC_Craker_Tools
{
    class GFC_Func
    {
        public void SwCrack(string software)
        {

            switch (software)
            {
                case"ccleaner":
                    Console.WriteLine("ccleaner");
                    break;
                default:
                    Console.WriteLine("Unknown Software " + software);
                    break;
            }


        }
        public void Func_002()
        {

        }
    }
}
