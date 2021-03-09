USE [CarSales]
GO

--Prepopulate vehicle types
INSERT INTO [dbo].[VehicleTypes]
           ([VehicleTypeName],[DateCreated])
     VALUES
           ('Car',  getdate()),
		   ('Boat', getdate() )
GO

--Prepopulate vehicle properties
INSERT INTO [dbo].[VehicleProperties]
           ([VehiclePropertyName],[DateCreated])
     VALUES
           ('Engine', getdate()),
		   ('Doors', getdate()),
		   ('Wheels', getdate()),
		   ('BodyType', getdate())

GO

--Prepopulate vehicle type properties
INSERT INTO [dbo].[VehicleTypeProperties]
           ([VehicleTypeId] ,[VehiclePropertyId] ,[DateCreated])
     VALUES
           (1, 1,getdate()),
		   (1, 2,getdate()),
		   (1, 3,getdate()),
		   (1, 4,getdate())
           
GO

