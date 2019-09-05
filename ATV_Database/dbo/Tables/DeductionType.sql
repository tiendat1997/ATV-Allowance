CREATE TABLE [dbo].[DeductionType] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Code]   NVARCHAR (20) NULL,
    [Amount] FLOAT (53)    NULL,
    CONSTRAINT [PK_DeductionType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

