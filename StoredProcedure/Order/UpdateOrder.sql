CREATE PROCEDURE [dbo].[UpdateOrder]
	@OrderID int,
	@CustomerID nchar(15),
	@EmployeeID int,
	@OrderDate datetime = null,
	@RequiredDate datetime = null,
	@ShippedDate datetime = null,
	@ShipVia int,
	@Freight money,
	@ShipName nvarchar(40),
	@ShipAddress nvarchar(60),
	@ShipCity nvarchar(15),
	@ShipRegion nvarchar(15),
	@ShipPostalCode nvarchar(10),
    @ShipCountry nvarchar(15)
AS
    UPDATE [dbo].Orders set CustomerID = @CustomerID, EmployeeID = @EmployeeID, OrderDate = @OrderDate,RequiredDate = @RequiredDate,ShippedDate = @ShippedDate,
	ShipVia = @ShipVia,Freight = @Freight,ShipName = @ShipName,ShipAddress = @ShipAddress,ShipCity = @ShipCity,ShipRegion = @ShipRegion,ShipPostalCode = @ShipPostalCode,ShipCountry = @ShipCountry
    where OrderID = @OrderID