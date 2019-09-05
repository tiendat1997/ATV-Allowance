CREATE TABLE [dbo].[Criteria] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [DisplayName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Criteria] PRIMARY KEY CLUSTERED ([Id] ASC)
);

