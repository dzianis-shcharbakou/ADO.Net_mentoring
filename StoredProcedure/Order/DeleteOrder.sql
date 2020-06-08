CREATE PROCEDURE [dbo].[DeleteOrder]
		@Id int
AS
    DELETE FROM [dbo].Orders 
	WHERE OrderID=@Id;