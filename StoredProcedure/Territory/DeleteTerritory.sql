CREATE PROCEDURE [dbo].[DeleteTerritory]
		@Id int
AS
    DELETE FROM [dbo].Territories 
	WHERE TerritoryID=@Id;