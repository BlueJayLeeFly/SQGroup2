DROP DATABASE IF EXISTS TMS_DB;
CREATE DATABASE TMS_DB;


USE tms_db;

DROP TABLE IF EXISTS `Route_Table`;
DROP TABLE IF EXISTS `Carrier_Data`;
DROP TABLE IF EXISTS `Rate_Table`;
DROP TABLE IF EXISTS `Order`;
DROP TABLE IF EXISTS `Employee`;



CREATE TABLE IF NOT EXISTS `Route_Table` (
  `Route_ID` Integer, 
  `Destination` VARCHAR(100),
  `Kilometer` Integer,
  `West` VARCHAR(100),
  `East` VARCHAR(100),
  `Time` Double,
  PRIMARY KEY(`Route_ID`)
);

CREATE TABLE IF NOT EXISTS `Carrier_Data` (
  `Carrier_ID` Integer,
  `Carrier_Name` VARCHAR(100),
  `Depot_City` VARCHAR(100),
  `FTL_Availability` Integer,
  `LTL_Availability` Integer,
  `FTL_Rate` Double,
  `LTL_Rate` Double,
  `Reefer_Charge` Integer,
  PRIMARY KEY(`Carrier_ID`)
);

CREATE TABLE IF NOT EXISTS `Rate_Table` (
  `Rate_Table_ID` Integer,
  `Surcharge` Double,
  `FTL` Double,
  `LTL` Double,
  PRIMARY KEY(`Rate_Table_ID`)
);

CREATE TABLE IF NOT EXISTS `Employee` (
    `Employee_ID` INTEGER,
    `Employee_Type` VARCHAR(30),
    `UserName` VARCHAR(30),
    `Password` VARCHAR(30),    
    PRIMARY KEY(`Employee_ID`)
);


CREATE TABLE IF NOT EXISTS `Order` (
  `Order_ID` Integer,
  `Employee_ID` Integer,
  `Order_Status` VARCHAR(50),
  `Route_ID` Integer,
  `Order_Quantity` Integer,
  `Trip` varchar(50),
  `Rate_Table_ID` Integer,
  `Carrier_ID` Integer,
  FOREIGN KEY (`Employee_ID`) REFERENCES `Employee` (`Employee_ID`),
  FOREIGN KEY (`Rate_Table_ID`) REFERENCES `Rate_Table`(`Rate_Table_ID`),
  FOREIGN KEY (`Route_ID`) REFERENCES `Route_Table`(`Route_ID`),
  FOREIGN KEY (`Carrier_ID`) REFERENCES `Carrier_Data`(`Carrier_ID`),
  PRIMARY KEY(`Order_ID`)
);



