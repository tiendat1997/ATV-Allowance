CREATE TABLE [dbo].[ArticleEmployee] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [ArticleId]  INT NULL,
    [EmployeeId] INT NULL,
    CONSTRAINT [PK_ArticleEmployee] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ArticleEmployee_Article] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Article] ([Id]),
    CONSTRAINT [FK_ArticleEmployee_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id])
);

