CREATE PROCEDURE [dbo].[DeleteOrderDetail]
		@Id int
AS
    DELETE FROM [dbo].[Order Details]
	WHERE OrderID=@Id;