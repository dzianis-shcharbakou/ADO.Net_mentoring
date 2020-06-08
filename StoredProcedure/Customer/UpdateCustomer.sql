CREATE PROCEDURE [dbo].[UpdateCustomer]
	@CustomerID nchar(5),
	@CompanyName nvarchar(40),
	@ContactName nvarchar(30),
    @ContactTitle nvarchar(30),
    @Address nvarchar(60),
    @City nvarchar(15),
    @Region nvarchar(15),
    @PostalCode nvarchar(10),
    @Country nvarchar(15),
    @Phone nvarchar(24),
    @Fax nvarchar(24)
AS
    UPDATE Customers set CompanyName=@CompanyName, ContactName=@ContactName, ContactTitle=@ContactTitle, Address=@Address, 
	City=@City, Region=@Region, PostalCode=@PostalCode, Country=@Country, Phone=@Phone, Fax=@Fax
	where CustomerID = @CustomerID