CREATE PROCEDURE [dbo].[DeleteEmployeeTerritory]
		@Id int
AS
    DELETE FROM [dbo].EmployeeTerritories 
	WHERE EmployeeID=@Id;