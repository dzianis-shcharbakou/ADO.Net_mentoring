CREATE PROCEDURE [dbo].[DeleteShipper]
		@Id int
AS
    DELETE FROM [dbo].Shippers 
	WHERE ShipperID=@Id;