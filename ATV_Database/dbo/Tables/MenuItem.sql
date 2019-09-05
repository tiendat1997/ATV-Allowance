CREATE TABLE [dbo].[MenuItem] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (30) NOT NULL,
    [Level]      INT           NOT NULL,
    [ParentName] NVARCHAR (30) NULL,
    [Order]      INT           NOT NULL,
    CONSTRAINT [PK_MenuItem] PRIMARY KEY CLUSTERED ([Id] ASC)
);

