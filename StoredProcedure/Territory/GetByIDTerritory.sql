CREATE PROCEDURE [dbo].[GetByIdTerritory]
@Id int
AS
    SELECT * FROM Territories
    WHERE TerritoryID=@Id