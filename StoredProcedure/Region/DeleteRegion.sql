CREATE PROCEDURE [dbo].[DeleteRegion]
		@Id int
AS
    DELETE FROM [dbo].Region
	WHERE RegionID=@Id;