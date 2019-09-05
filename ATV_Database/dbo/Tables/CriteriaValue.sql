CREATE TABLE [dbo].[CriteriaValue] (
    [Id]              INT        IDENTITY (1, 1) NOT NULL,
    [CriteriaId]      INT        NULL,
    [Value]           FLOAT (53) NULL,
    [Unit]            INT        NULL,
    [ConfigurationId] INT        NULL,
    CONSTRAINT [PK_CriteriaValue] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CriteriaValue_Configuration] FOREIGN KEY ([ConfigurationId]) REFERENCES [dbo].[Configuration] ([Id]),
    CONSTRAINT [FK_CriteriaValue_Criteria] FOREIGN KEY ([CriteriaId]) REFERENCES [dbo].[Criteria] ([Id])
);

