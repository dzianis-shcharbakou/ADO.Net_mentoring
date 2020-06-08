CREATE PROCEDURE [dbo].[InsertOrderDetail]
	@OrderID int,
    @ProductID int,
    @UnitPrice money,
    @Quantity smallint,
    @Discount real
AS
    INSERT INTO [dbo].[Order Details] (OrderID, ProductID, UnitPrice, Quantity, Discount)
    VALUES (@OrderID, @ProductID, @UnitPrice, @Quantity, @Discount)
    SELECT SCOPE_IDENTITY()