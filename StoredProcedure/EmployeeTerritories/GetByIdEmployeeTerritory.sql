CREATE PROCEDURE [dbo].[GetByIdEmployeeTerritory]
@Id int
AS
    SELECT * FROM EmployeeTerritories
    WHERE EmployeeID=@Id