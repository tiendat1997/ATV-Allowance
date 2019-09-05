CREATE TABLE [dbo].[ArticlePointType] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [ArticleTypeId] INT NOT NULL,
    [PointTypeId]   INT NOT NULL,
    CONSTRAINT [PK_ArticlePointType] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ArticlePointType_ArticleType] FOREIGN KEY ([ArticleTypeId]) REFERENCES [dbo].[ArticleType] ([Id]),
    CONSTRAINT [FK_ArticlePointType_PointType] FOREIGN KEY ([PointTypeId]) REFERENCES [dbo].[PointType] ([Id])
);

