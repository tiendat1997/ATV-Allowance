﻿CREATE TABLE [dbo].[PointType] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    [Code] VARCHAR (50)   NULL,
    CONSTRAINT [PK_PointType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

