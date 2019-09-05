CREATE TABLE [dbo].[BusinessLog] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Content] NVARCHAR (MAX) NOT NULL,
    [ActorId] INT            NOT NULL,
    [TypeId]  INT            NOT NULL,
    CONSTRAINT [PK_BusinessLog] PRIMARY KEY CLUSTERED ([Id] ASC)
);

