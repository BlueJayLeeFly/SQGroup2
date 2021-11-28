using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Group2
{
    public static class AdminController
    {

        public static string PresetLogFile = "c:\\Users\\lsj27\\documents\\TMS_LogFile.log";
        public static string LogFileDirectory;
        public static string LogFileName;
        public static string LogWithDateTime;   // variable to store eventlogs
        public static string ConnectionStringForTMS = "Server=localhost;Uid=8709111;Pwd=Student12345;database=lab3";  // connection string for TMS Database

        // Backup
        public static string BackupFile;


        // Logger 4.5.2.1.2  -------- write with append / read 
        public static void addLog(string logMsg)
        {
            DateTime tsmTime = DateTime.Now;
            LogWithDateTime = $"[ {tsmTime} ] - {logMsg}";

            if (!File.Exists(LogFileName))
            {
                LogFileName = PresetLogFile;
               
                using (StreamWriter sw = File.CreateText(LogFileName))
                {
                    DateTime createFileTime = DateTime.Now;
                    sw.WriteLine($"[ {createFileTime} ] - File Created");
                }
            }

            using (StreamWriter sw = File.AppendText(LogFileName))
            {
                sw.WriteLine(LogWithDateTime);
            }

        }

        public static void readLog(string logMsg)
        {
            // it will display on the admin review log page
            // This is implemented as a list box.
        }

        // connectToDB() -> 4.5.2.1.1


        // localBackup() -> 4.5.2.1.4
        public static void localBackup(string ConnectionStringForTMS, string BackupFile)
        {

            // https://www.nuget.org/packages/MySqlBackup.NET/

            using (MySqlConnection conn = new MySqlConnection(ConnectionStringForTMS))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(BackupFile);
                        conn.Close();
                    }
                }
            }
        }

        public static void localRestore(string ConnectionStringForTMS, string BackupFile)
        {
            // https://www.nuget.org/packages/MySqlBackup.NET/

            using (MySqlConnection conn = new MySqlConnection(ConnectionStringForTMS))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ImportFromFile(BackupFile);
                        conn.Close();
                    }
                }
            }
        }




        // changeCarrierData() -> 4.5.2.1.3

        // changeRouteTable() -> 4.5.2.1.3

        // changeRateFeeTable() -> 4.5.2.1.3





        // MySQL --- id : group2 / password : group2password




        //buyer methods
        //getContract() -> 4.5.2.2.1
        //reviewCust() -> 4.5.2.2.2
        //acceptNewCust() -> 4.5.2.2.2
        //startOrder() -> 4.5.2.2.3
        //selectCity() -> 4.5.2.2.4
        //createInvoice()-> 4.5.2.2.5
        //create invoice generates invoice in a file and updates TMS database


        //planner methods
        //getOrder() -> 4.5.2.3.1  get orders from Buyer
        //selectCarrier() 4.5.2.3.2 also must be able to add trip if capacity is reached for a carrier
        //incrementDat() 4.5.2.3.4
        //markForFollowUp() 4.5.2.3.5 confirm an order is completed. 
        //Completed Orders are marked for follow-up from the Buyer

        //summarizeActiceOrders() 4.5.2.3.6 viewed on status screen
        //generateReport() 4.5.2.3.8 all-time or past 2 weeks. 

    }
}
