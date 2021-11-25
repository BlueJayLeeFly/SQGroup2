﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// 
/// \class  Customers
/// 
/// \brief  The purpose of this class is to store the customer information
///         when the customer is retrieved from the contract marketplace.
///         This class has a single constructor with getters and setters 
///         for each attribute. 
/// 
/// Attributes:
///     -CustomerName       : Name of Customer
///     -OrderRequestStatus :The status of the customer order
///     -CustomerCity       : which city the customer in from
///     -ImagePath          : image path to a picture of the customer
///     
/// \author <i>Colby Taylor & Sohaib Sheikh & Seungjae Lee & Parichehr Moghanloo</i>
///         
/// </summary>

namespace Group2
{
    class Customers
    {
        public string CustomerName { get; set; }            ///< Customer Properties to set and get attribute
        public string OrderRequestStatus { get; set; }      ///< OrderRequestStatus Properties to set and get attribute
        public string CustomerCity { get; set; }            ///< CustomerCity Properties to set and get attribute
        public string ImagePath { get; set; }               ///< ImagePath Properties to set and get attribute


        public Customers(string CustomerName, string CustomerCity, string OrderRequestStatus, string ImagePath)
        {
            this.CustomerName = CustomerName;            
            this.CustomerCity = CustomerCity;
            this.OrderRequestStatus = OrderRequestStatus;
            this.ImagePath = ImagePath;
        } 

    }
}
