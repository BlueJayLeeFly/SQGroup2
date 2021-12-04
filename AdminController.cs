using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;



namespace Group2
{
    /// <summary>
    /// Static class for Admin
    /// </summary>
    /// 
    /// \class  AdminController
    /// 
    /// \brief  The purpose of this class is to allow the admin specific controls
    ///         to be able to review log record log and connect to the Database
    /// 
    /// Attributes:
    ///     -Record                       : Attribute for storing the event log
    ///     -LogFileDirectory             : Attribute to store the local location
    ///                                   : of the log file
    ///     -ConnectionStringForTMS       : Stores the connection string for the 
    ///                                   : TMS database
    /// 
    /// Methods:
    ///     -addLog(string msg)
    ///     -readLog(string msg)
    ///     -connectToDb()
    ///     -changeCarrierData()
    ///     -changeRouteTable()
    ///     -changeRateFeeTable()
    ///     
    /// \author <i>Colby Taylor & Sohaib Sheikh & Seungjae Lee & Parichehr Moghanloo</i>
    ///         
    /// </summary>
    /// 

    public static class AdminController
    {

        public static string PresetLogFile = AppDomain.CurrentDomain.BaseDirectory + "\\log.txt";
        public static string LogFileDirectory;
        public static string LogFileName;
        public static string LogWithDateTime;   // variable to store eventlogs
        public static string ConnectionStringForTMS = "Server=localhost;Uid=testuser;Pwd=12345;database=test";  // connection string for TMS Database

        // Backup
        public static string BackupFile;


        /**
        *  \brief   addLog -- add logs to a log file
        *  \details this method add log to a log file by appending
        *  \param   logMsg string
        *  \returns NONE
        */

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



        /**
        *  \brief   readLog -- read log file
        *  \details this method read log file
        *  \param   logMsg string 
        *  \returns NONE
        */

        public static void readLog(string logMsg)
        {
            // it will display on the admin review log page
            // This is implemented as a list box.
        }



        /**
        *  \brief   InitialConnectToDB -- connect to TMS DB initially 
        *  \details this method connects TMS DB initially
        *  \param   NONE
        *  \returns NONE
        */

        public static string InitialConnectToDB()
        {
            string mySqlVersion = "";
            try
            {                
                // Connection String
                var connstr = ConnectionStringForTMS;                

                using (var conn = new MySqlConnection(connstr))
                {
                    // Open connection
                    conn.Open();
                    mySqlVersion =$"Connected to MySql {conn.ServerVersion}";

                    conn.Close(); // Close connection
                }         
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);               
            }
           
            return mySqlVersion;
        }



        /**
        *  \brief    ConnectToDB -- connect to TMS DB with sql command
        *  \details  this method connects TMS DB and execute sql command
        *  \param    mySqlCommand string
        *  \returns  NONE
        */

        public static void ConnectToDB(string mySqlCommand)
        {
            try
            {
                // Connection String
                var connstr = ConnectionStringForTMS;

                using (var conn = new MySqlConnection(connstr))
                {
                    // Open connection
                    conn.Open();                    

                    // Create a command
                    using (var cmd = conn.CreateCommand())
                    {
                        // This a command text
                        cmd.CommandText = mySqlCommand;

                        // execute
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close(); // Close connection
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        /**
        *  \brief    localBackup -- create a DB backup locally
        *  \details  this method create a DB backup file locally
        *  \param    ConnectionStringForTMS string
        *  \param    BackupFile string
        *  \returns  NONE
        */

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


        /**
        *  \brief    localRestore -- restore a DB backup locally
        *  \details  this method restore a DB backup file locally
        *  \param    ConnectionStringForTMS string
        *  \param    BackupFile string
        *  \returns  NONE
        */

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



        /**
        *  \brief    changeCarrierData -- change carrier data
        *  \details  this method changes carrier data and modify DB
        *  \param    NONE
        *  \returns  NONE
        */

        public static void changeCarrierData()
        {

        }


        /**
        *  \brief    changeRouteTable -- change route table
        *  \details  this method changes route table and modify DB
        *  \param    NONE
        *  \returns  NONE
        */

        public static void changeRouteTable()
        {

        }


        /**
        *  \brief    changeRateFeeTable -- change rate fee table
        *  \details  this method changes route table and modify DB
        *  \param    NONE
        *  \returns  NONE
        */

        public static void changeRateFeeTable()
        {

        }






        


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
