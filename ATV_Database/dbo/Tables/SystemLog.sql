CREATE TABLE [dbo].[SystemLog] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Content] NVARCHAR (MAX) NOT NULL,
    [Date]    DATETIME       NOT NULL,
    [TypeId]  INT            NOT NULL,
    CONSTRAINT [PK_SystemLog] PRIMARY KEY CLUSTERED ([Id] ASC)
);

