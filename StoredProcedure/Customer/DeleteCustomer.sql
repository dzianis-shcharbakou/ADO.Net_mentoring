CREATE PROCEDURE [dbo].[DeleteCustomer]
		@Id int
AS
    DELETE FROM [dbo].Customers 
	WHERE CustomerID=@Id;