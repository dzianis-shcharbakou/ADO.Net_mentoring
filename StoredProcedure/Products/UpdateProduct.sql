CREATE PROCEDURE [dbo].[UpdateProduct]
	@ProductID int,
	@ProductName nvarchar(40),
	@SupplierID int,
	@CategoryID int,
	@QuantityPerUnit nvarchar(20),
	@UnitPrice money,
	@UnitsInStock smallint,
	@UnitsOnOrder smallint,
    @ReorderLevel smallint,
    @Discontinued bit
AS
    UPDATE [dbo].Products set ProductName = @ProductName, SupplierID = @SupplierID, CategoryID = @CategoryID, QuantityPerUnit = @QuantityPerUnit, UnitPrice = @UnitPrice, 
	UnitsInStock = @UnitsInStock, UnitsOnOrder = @UnitsOnOrder, ReorderLevel = @ReorderLevel, Discontinued = @Discontinued
    WHERE ProductID = @ProductID