using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group2
{
    public static class AdminController
    {
        public static string Record;   // variable to store eventlogs
        public static string LogFileDirectory;
        public static string ConnectionStringForTMS;  // connection string for TMS Database


        // Logger 4.5.2.1.2  -------- write with append / read 
        public static void addLog(string logMsg)
        {
            DateTime tsmTime = DateTime.Now;
            Record += $"[ {tsmTime} ] - {logMsg} \n";

            // append to a file
        }

        public static void readLog(string logMsg)
        {
            // it will display on the admin review log page
        }

        // connectToDB() -> 4.5.2.1.1



        // changeCarrierData() -> 4.5.2.1.3

        // changeRouteTable() -> 4.5.2.1.3

        // changeRateFeeTable() -> 4.5.2.1.3



        // localBackup() -> 4.5.2.1.4

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
