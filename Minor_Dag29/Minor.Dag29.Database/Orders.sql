CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Client_id] INT NOT NULL, 
    [Product_id] INT NOT NULL, 
    [Amount_of_units] INT NOT NULL, 
    [Delivery_cost] DECIMAL(18, 2) NOT NULL, 
    [Price_per_unit] DECIMAL(18, 2) NOT NULL, 
    CONSTRAINT [FK_Orders_ToTable_Clients] FOREIGN KEY (Client_id) REFERENCES [Clients]([Id]),
    CONSTRAINT [FK_Orders_ToTable_Products] FOREIGN KEY ([Product_id]) REFERENCES [Products]([Id])

)
