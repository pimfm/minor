CREATE TABLE [dbo].[Clients]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Country_id] INT NOT NULL, 
    CONSTRAINT [FK_Clients_ToTable_DeliveryCosts] FOREIGN KEY (Country_id) REFERENCES [DeliveryCosts]([Id])
)
