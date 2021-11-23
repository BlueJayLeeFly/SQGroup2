using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group2
{
    class Customers
    {
        public string CustomerName { get; set; }
        public string OrderRequestStatus { get; set; }
        public string CustomerCity { get; set; }
        public string ImagePath { get; set; }


        public Customers(string CustomerName, string CustomerCity, string OrderRequestStatus, string ImagePath)
        {
            this.CustomerName = CustomerName;            
            this.CustomerCity = CustomerCity;
            this.OrderRequestStatus = OrderRequestStatus;
            this.ImagePath = ImagePath;
        }
 

    }
}
