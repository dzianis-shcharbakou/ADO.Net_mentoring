CREATE PROCEDURE [dbo].[InsertSupplier]
	@CompanyName nvarchar(40),
	@ContactName nvarchar(30),
	@ContactTitle nvarchar(30),
	@Address nvarchar(60),
	@City nvarchar(15),
	@Region nvarchar(15),
	@PostalCode nvarchar(10),
	@Country nvarchar(15),
	@Phone nvarchar(24),
    @Fax nvarchar(24),
    @HomePage ntext
AS
    INSERT INTO [dbo].Suppliers(CompanyName, ContactName, ContactTitle, Address, City, Region,PostalCode,Country,Phone,Fax,HomePage)
    VALUES (@CompanyName, @ContactName, @ContactTitle, @Address, @City,@Region,@PostalCode,@Country,@Phone,@Fax,@HomePage)
    SELECT SCOPE_IDENTITY()
