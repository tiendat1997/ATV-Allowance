CREATE TABLE [dbo].[Criteria] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [DisplayName]   NVARCHAR (MAX) NOT NULL,
    [ArticleTypeId] INT            NOT NULL,
    [Unit]          INT            NULL,
    CONSTRAINT [PK_Criteria] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Criteria_ArticleType] FOREIGN KEY ([ArticleTypeId]) REFERENCES [dbo].[ArticleType] ([Id])
);



