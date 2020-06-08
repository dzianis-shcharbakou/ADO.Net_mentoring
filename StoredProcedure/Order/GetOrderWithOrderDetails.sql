CREATE PROCEDURE [dbo].[GetOrderWithOrderDetils]
@Id int
AS
    SELECT ord.CustomerID, ord.EmployeeID, ord.OrderDate, ord.RequiredDate, ord.ShippedDate, ord.ShipVia, ord.Freight, ord.ShipName, ord.ShipAddress, ord.ShipCity, ord.ShipRegion,ord.ShipPostalCode, ord.ShipCountry
	FROM Orders as ord 
	Where OrderID = @id;

	Select det.ProductID, prod.ProductName, det.UnitPrice, det.Quantity, det.Discount
	from Northwind.dbo.[Order Details] as det JOIN Northwind.dbo.Products as prod 
	ON prod.ProductID = det.ProductID where det.OrderID = @id