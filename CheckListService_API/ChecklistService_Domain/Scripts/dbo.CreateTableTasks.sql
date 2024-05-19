CREATE TABLE [dbo].[Tasks]
(
	[Id] int NOT NULL PRIMARY KEY,
	[Description] nvarchar(50) NOT NULL,
	[Done] bit DEFAULT(0) NOT NULL,
	[EndDate] Date NULL
)
