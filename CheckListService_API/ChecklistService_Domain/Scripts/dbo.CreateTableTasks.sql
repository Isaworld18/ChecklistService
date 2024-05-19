CREATE TABLE [dbo].[Works] (
    [Id]          INT           NOT NULL IDENTITY,
    [Description] NVARCHAR (50) NOT NULL,
    [Done]        BIT           DEFAULT ((0)) NOT NULL,
    [EndDate]     DATE          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

