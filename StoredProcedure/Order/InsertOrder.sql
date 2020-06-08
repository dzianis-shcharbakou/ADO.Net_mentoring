CREATE PROCEDURE [dbo].[InsertOrder]
	@CustomerID nchar(15),
	@EmployeeID int,
	@OrderDate datetime = null,
	@RequiredDate datetime,
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
    INSERT INTO [dbo].Orders(CustomerID, EmployeeID, OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry)
    VALUES (@CustomerID, @EmployeeID, @OrderDate,@RequiredDate,@ShippedDate,@ShipVia,@Freight,@ShipName,@ShipAddress,@ShipCity,@ShipRegion,@ShipPostalCode,@ShipCountry)
    SELECT SCOPE_IDENTITY()