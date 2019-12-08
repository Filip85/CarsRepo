﻿CREATE TABLE [dbo].[VehicleModelT]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MakeId] INT NULL FOREIGN KEY REFERENCES VehicleMakeT(Id), 
    [Name] NCHAR(20) NOT NULL, 
    [Abrv] NCHAR(10) NOT NULL 
)
