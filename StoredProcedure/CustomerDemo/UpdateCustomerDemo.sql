CREATE PROCEDURE [dbo].[UpdateCustomerDemo]
	@CustomerID nchar(5),
    @CustomerTypeID nchar(10)
AS
    UPDATE CustomerCustomerDemo set CustomerTypeID=@CustomerTypeID
	where CustomerID=@CustomerID