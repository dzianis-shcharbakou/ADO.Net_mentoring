CREATE PROCEDURE [dbo].[GetByIdRegion]
@Id int
AS
    SELECT * FROM Region
    WHERE RegionID=@Id