CREATE TABLE [dbo].[DeliveryCosts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Country] VARCHAR(100) NOT NULL, 
    [Delivery_cost] DECIMAL(18, 2) NOT NULL
)
