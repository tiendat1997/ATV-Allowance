CREATE TABLE [dbo].[RoleHasMenuItem] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [RoleId]     INT NOT NULL,
    [MenuItemId] INT NOT NULL,
    CONSTRAINT [PK_RoleHasMenuItem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RoleHasMenuItem_MenuItem] FOREIGN KEY ([MenuItemId]) REFERENCES [dbo].[MenuItem] ([Id]),
    CONSTRAINT [FK_RoleHasMenuItem_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id])
);

