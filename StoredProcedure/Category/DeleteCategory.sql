CREATE PROCEDURE [dbo].[DeleteCategory]
		@Id int
AS
    DELETE FROM [dbo].Categories 
	WHERE CategoryID=@Id;