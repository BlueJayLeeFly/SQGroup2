using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group2
{
    public static class AdminController
    {
        public static string Record;


        public static void addLog(string logMsg)
        {
            DateTime tsmTime = DateTime.Now;
            Record += "[ " + tsmTime + " ]" + " - " + logMsg + "\n";
        }
    }
}
