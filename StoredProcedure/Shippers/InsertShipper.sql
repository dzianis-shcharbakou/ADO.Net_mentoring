CREATE PROCEDURE [dbo].[InsertShipper]
	@CompanyName nvarchar(40),
    @Phone nvarchar(24)
AS
    INSERT INTO [dbo].Shippers(CompanyName, Phone)
    VALUES (@CompanyName, @Phone)
    SELECT SCOPE_IDENTITY()
