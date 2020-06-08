CREATE PROCEDURE [dbo].[InsertCategory]
	@CategoryName nvarchar(15),
    @Description ntext,
    @Picture image
AS
    INSERT INTO [dbo].Categories (CategoryName, Description, Picture)
    VALUES (@CategoryName, @Description, @Picture)
    SELECT SCOPE_IDENTITY()




