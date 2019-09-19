CREATE TABLE [dbo].[Point] (
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [ArticleEmployeeId] INT NULL,
    [Point]             INT NULL,
    [Type]              INT NULL,
    CONSTRAINT [PK_Point] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Point_ArticleEmployee] FOREIGN KEY ([ArticleEmployeeId]) REFERENCES [dbo].[ArticleEmployee] ([Id]),
    CONSTRAINT [FK_Point_PointType] FOREIGN KEY ([Type]) REFERENCES [dbo].[PointType] ([Id])
);



