CREATE PROCEDURE [dbo].[GetByIdCategory]
@Id int
AS
    SELECT * FROM Categories
    WHERE CategoryID=@Id