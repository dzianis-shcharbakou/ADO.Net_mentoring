CREATE PROCEDURE [dbo].[InsertCustomerDemo]
	@CustomerID nchar(5),
    @CustomerTypeID nchar(10)
AS
    INSERT INTO [dbo].CustomerCustomerDemo(CustomerID, CustomerTypeID)
    VALUES (@CustomerID, @CustomerTypeID)
    SELECT SCOPE_IDENTITY()