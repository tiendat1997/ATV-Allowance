CREATE TABLE [dbo].[Article] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Code]     VARCHAR (200)  NULL,
    [Title]    NVARCHAR (MAX) NULL,
    [Date]     DATE           NOT NULL,
    [TypeId]   INT            NOT NULL,
    [IsActive] BIT            NULL,
    CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Article_ArticleType] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[ArticleType] ([Id])
);



