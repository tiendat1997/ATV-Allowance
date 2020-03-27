ALTER TABLE Employee ADD Organization NVARCHAR(MAX) NULL
GO

MERGE INTO Employee E
   USING Organization O 
      ON E.OrganizationId = O.Id
WHEN MATCHED THEN
   UPDATE 
      SET Organization = O.Name;
GO
