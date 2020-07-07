CREATE TABLE [dbo].[Scooter]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Make] NVARCHAR(50) NOT NULL, 
    [Model] NVARCHAR(50) NOT NULL, 
    [Price] IMAGE NOT NULL
)
