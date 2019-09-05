CREATE TABLE [dbo].[Deduction] (
    [Id]              INT IDENTITY (1, 1) NOT NULL,
    [Month]           INT NULL,
    [Year]            INT NULL,
    [DeductionTypeId] INT NULL,
    [EmployeeId]      INT NULL,
    CONSTRAINT [PK_Deduction] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Deduction_DeductionType] FOREIGN KEY ([DeductionTypeId]) REFERENCES [dbo].[DeductionType] ([Id]),
    CONSTRAINT [FK_Deduction_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id])
);

