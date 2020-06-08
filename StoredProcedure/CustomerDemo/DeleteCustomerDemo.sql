CREATE PROCEDURE [dbo].[DeleteCustomerDemo]
		@Id int
AS
    DELETE FROM [dbo].CustomerCustomerDemo 
	WHERE CustomerID=@Id;