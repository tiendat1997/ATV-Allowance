CREATE TABLE [dbo].[Employee] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Code]           VARCHAR (50)   NULL,
    [Name]           NVARCHAR (MAX) NULL,
    [RoleId]         INT            NULL,
    [OrganizationId] INT            NULL,
    [IsActive] BIT NOT NULL, 
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Employee_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization] ([Id]),
    CONSTRAINT [FK_Employee_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Position] ([Id])
);

