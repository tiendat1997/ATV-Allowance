CREATE TABLE [dbo].[ArticleType] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (200) NULL,
    CONSTRAINT [PK_ArticleType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

