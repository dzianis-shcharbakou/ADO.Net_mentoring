CREATE PROCEDURE [dbo].[UpdateCategory]
	@CategoryID int,
	@CategoryName nvarchar(15),
    @Description ntext,
    @Picture image
AS
    UPDATE Categories set CategoryName=@CategoryName, Description=@Description, Picture=@Picture
	where CategoryID = @CategoryID