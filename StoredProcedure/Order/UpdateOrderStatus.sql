CREATE PROCEDURE [dbo].[UpdateOrderStatus]
	@OrderID int,
	@OrderDate datetime = null,
	@ShippedDate datetime = null
AS
    UPDATE [dbo].Orders set OrderDate = @OrderDate,ShippedDate = @ShippedDate
    where OrderID = @OrderID