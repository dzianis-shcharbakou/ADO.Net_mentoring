CREATE PROCEDURE [dbo].[UpdateOrderDetail]
	@OrderID int,
    @ProductID int,
    @UnitPrice money,
    @Quantity smallint,
    @Discount real
AS
    UPDATE [dbo].[Order Details] set ProductID = @ProductID, UnitPrice = @UnitPrice, Quantity = @Quantity, Discount = @Discount
    where OrderID = @OrderID