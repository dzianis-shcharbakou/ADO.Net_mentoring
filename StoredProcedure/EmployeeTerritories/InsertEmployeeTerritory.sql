CREATE PROCEDURE [dbo].[InsertEmployeeTerritory]
	@EmployeeID int,
    @TerritoryID nvarchar(20)
AS
    INSERT INTO [dbo].EmployeeTerritories(EmployeeID, TerritoryID)
    VALUES (@EmployeeID, @TerritoryID)
    SELECT SCOPE_IDENTITY()