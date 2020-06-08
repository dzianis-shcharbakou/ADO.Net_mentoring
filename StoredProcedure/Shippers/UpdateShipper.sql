CREATE PROCEDURE [dbo].[UpdateShipper]
	@ShipperID int,
	@CompanyName nvarchar(40),
    @Phone nvarchar(24)
AS
    UPDATE [dbo].Shippers set CompanyName = @CompanyName, Phone = @Phone
    Where ShipperID = @ShipperID