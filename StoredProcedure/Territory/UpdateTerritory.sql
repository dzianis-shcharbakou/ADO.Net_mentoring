CREATE PROCEDURE [dbo].[UpdateTerritory]
	@TerritoryID nvarchar(20),
    @TerritoryDescription nchar(50),
    @RegionID int
AS
    UPDATE [dbo].Territories set TerritoryDescription = @TerritoryDescription, RegionID = @RegionID
    WHERE TerritoryID = @TerritoryID