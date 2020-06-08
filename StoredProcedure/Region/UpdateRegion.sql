CREATE PROCEDURE [dbo].[UpdateRegion]
	@RegionID int,
    @RegionDescription nchar(50)
AS
    UPDATE [dbo].Region set RegionDescription = @RegionDescription
    WHERE RegionID=@RegionID