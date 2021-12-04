using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group2
{
    

    class contractParams
    {
        public string clientName { get; set; }
        public int jobType { get; set; }
        public int quantity { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public int vanType { get; set; }

        public enum testEnum { City1, City2, City3, City4, City5, City6, City7, City8 };
        




        //clientName = rdr["Client_Name"].ToString(),
        //                    jobType = int.Parse(rdr["Job_Type"].ToString()),
        //                    quantity = int.Parse(rdr["Quantity"].ToString()),
        //                    origin = rdr["Origin"].ToString(),
        //                    destination = rdr["Destination"].ToString(),
        //                    vanType = int.Parse(rdr["Van_Type"].ToString())
    }
}
