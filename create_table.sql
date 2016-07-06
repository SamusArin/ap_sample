CREATE TABLE dbo.Vehicles  
   (ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,  
    VIN varchar(255) NOT NULL,
	Make varchar(25) NOT NULL,  
    Model varchar(25) NOT NULL,  
    Cylinders int NULL,
	Transmission int NULL)  
GO  