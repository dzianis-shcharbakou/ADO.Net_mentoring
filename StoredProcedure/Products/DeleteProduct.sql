CREATE PROCEDURE [dbo].[DeleteProduct]
		@Id int
AS
    DELETE FROM [dbo].Products 
	WHERE ProductID=@Id;