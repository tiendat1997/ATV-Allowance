CREATE TABLE [dbo].[User] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Username]       NVARCHAR (50)  NOT NULL,
    [Password]       NVARCHAR (200) NOT NULL,
    [Code]           NVARCHAR (6)   NOT NULL,
    [Name]           NVARCHAR (50)  NOT NULL,
    [RoleId]         INT            NOT NULL,
    [StatusId]       INT            NOT NULL,
    [LastLoginTime]  DATETIME       NULL,
    [CreateDate]     DATETIME       NULL,
    [LastUpdateDate] DATETIME       NULL,
    [LastUpdateBy]   INT            NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id])
);

