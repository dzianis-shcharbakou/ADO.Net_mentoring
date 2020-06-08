CREATE PROCEDURE [dbo].[UpdateEmployeeTerritory]
	@EmployeeID int,
    @TerritoryID nvarchar(20)
AS
    UPDATE [dbo].EmployeeTerritories set TerritoryID = @TerritoryID
    where EmployeeID = @EmployeeID