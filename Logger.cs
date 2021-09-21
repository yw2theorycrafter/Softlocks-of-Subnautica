using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softlocks_of_Subnautica
{  
        internal class Logger
        {
            internal static void Log(string message)
            {
                Console.WriteLine("[Softlocks_of_Subnautica] " + message);
            }
        }
}
