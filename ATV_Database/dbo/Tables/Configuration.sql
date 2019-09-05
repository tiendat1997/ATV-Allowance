CREATE TABLE [dbo].[Configuration] (
    [Id]    INT IDENTITY (1, 1) NOT NULL,
    [Month] INT NULL,
    [Year]  INT NULL,
    CONSTRAINT [PK_Configuration] PRIMARY KEY CLUSTERED ([Id] ASC)
);

