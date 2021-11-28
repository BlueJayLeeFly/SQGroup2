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
INSERT INTO Employee (Employee_ID, Employee_Type, UserName, Password) VALUES ('1', 'admin','sohaib', 'sheikh');
INSERT INTO Employee (Employee_ID, Employee_Type, UserName, Password) VALUES ('2', 'buyer','colby', 'taylor');
INSERT INTO Employee (Employee_ID, Employee_Type, UserName, Password) VALUES ('3', 'planner','parichehr', 'salahshour');
INSERT INTO Employee (Employee_ID, Employee_Type, UserName, Password) VALUES ('4', 'admin','seungjae', 'lee');


INSERT INTO Route_Table (Route_ID, Destination, Kilometer, West, East, Time) VALUES ('1', 'Windsor','191', 'END','London','2.5');
INSERT INTO Route_Table (Route_ID, Destination, Kilometer, West, East, Time) VALUES ('2', 'London','128', 'Windsor','Hamilton','1.75');
INSERT INTO Route_Table (Route_ID, Destination, Kilometer, West, East, Time) VALUES ('3', 'Hamilton','68', 'London','Toronto','1.25');
INSERT INTO Route_Table (Route_ID, Destination, Kilometer, West, East, Time) VALUES ('4', 'Toronto','60', 'Hamilton','Oshawa','1.3');
INSERT INTO Route_Table (Route_ID, Destination, Kilometer, West, East, Time) VALUES ('5', 'Oshawa','134', 'Toronto','Belleville','1.65');
INSERT INTO Route_Table (Route_ID, Destination, Kilometer, West, East, Time) VALUES ('6', 'Belleville','82', 'Oshawa','Kingstone','1.2');
INSERT INTO Route_Table (Route_ID, Destination, Kilometer, West, East, Time) VALUES ('7', 'Kingstone','96', 'Belleville','Ottawa','2.5');
INSERT INTO Route_Table (Route_ID, Destination, Kilometer, West, East, Time) VALUES ('8', 'Ottawa','0', 'Kingston','END','0');



INSERT INTO Carrier_Data (Carrier_ID, Carrier_Name, Depot_City, FTL_Availability, LTL_Availability, FTL_Rate, LTL_Rate, Reefer_Charge)
 VALUES ('1', 'Planet Expess','Windsor', '50','640','5.21', '0.3621', '0.08');
INSERT INTO Carrier_Data (Carrier_ID, Carrier_Name, Depot_City, FTL_Availability, LTL_Availability, FTL_Rate, LTL_Rate, Reefer_Charge)
 VALUES ('2', 'Planet Expess','Hamilton', '50','640','5.21', '0.3621', '0.08');
INSERT INTO Carrier_Data (Carrier_ID, Carrier_Name, Depot_City, FTL_Availability, LTL_Availability, FTL_Rate, LTL_Rate, Reefer_Charge)
 VALUES ('3', 'Planet Expess','Oshawa', '50','640','5.21', '0.3621', '0.08');
INSERT INTO Carrier_Data (Carrier_ID, Carrier_Name, Depot_City, FTL_Availability, LTL_Availability, FTL_Rate, LTL_Rate, Reefer_Charge)
 VALUES ('4', 'Planet Expess','Belleville', '50','640','5.21', '0.3621', '0.08');
INSERT INTO Carrier_Data (Carrier_ID, Carrier_Name, Depot_City, FTL_Availability, LTL_Availability, FTL_Rate, LTL_Rate, Reefer_Charge)
 VALUES ('5', 'Planet Expess','Ottawa', '50','640','5.21', '0.3621', '0.08');
 INSERT INTO Carrier_Data (Carrier_ID, Carrier_Name, Depot_City, FTL_Availability, LTL_Availability, FTL_Rate, LTL_Rate, Reefer_Charge)
 VALUES ('6', 'Schooners','London', '18','98','5.05', '0.3434', '0.07');
 INSERT INTO Carrier_Data (Carrier_ID, Carrier_Name, Depot_City, FTL_Availability, LTL_Availability, FTL_Rate, LTL_Rate, Reefer_Charge)
 VALUES ('7', 'Schooners','Toronto', '18','98','5.05', '0.3434', '0.07');
 INSERT INTO Carrier_Data (Carrier_ID, Carrier_Name, Depot_City, FTL_Availability, LTL_Availability, FTL_Rate, LTL_Rate, Reefer_Charge)
 VALUES ('8', 'Schooners','Kingston', '18','98','5.05', '0.3434', '0.07');
 INSERT INTO Carrier_Data (Carrier_ID, Carrier_Name, Depot_City, FTL_Availability, LTL_Availability, FTL_Rate, LTL_Rate, Reefer_Charge)
 VALUES ('9', 'Tillman Transport','Windsor', '24','35','5.11', '0.3012', '0.09');
INSERT INTO Carrier_Data (Carrier_ID, Carrier_Name, Depot_City, FTL_Availability, LTL_Availability, FTL_Rate, LTL_Rate, Reefer_Charge)
 VALUES ('10', 'Tillman Transport','London', '24','35','5.11', '0.3012', '0.09'); 
 INSERT INTO Carrier_Data (Carrier_ID, Carrier_Name, Depot_City, FTL_Availability, LTL_Availability, FTL_Rate, LTL_Rate, Reefer_Charge)
 VALUES ('11', 'Tillman Transport','Hamilton', '24','35','5.11', '0.3012', '0.09');
INSERT INTO Carrier_Data (Carrier_ID, Carrier_Name, Depot_City, FTL_Availability, LTL_Availability, FTL_Rate, LTL_Rate, Reefer_Charge)
 VALUES ('12', 'We Haul','Ottawa', '11','0','5.2', '0', '0.065'); 
INSERT INTO Carrier_Data (Carrier_ID, Carrier_Name, Depot_City, FTL_Availability, LTL_Availability, FTL_Rate, LTL_Rate, Reefer_Charge)
 VALUES ('13', 'We Haul','Toronto', '11','0','5.2', '0', '0.065');  


