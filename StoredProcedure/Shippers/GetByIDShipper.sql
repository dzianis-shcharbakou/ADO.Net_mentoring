CREATE PROCEDURE [dbo].[GetByIdShipper]
@Id int
AS
    SELECT * FROM Shippers
    WHERE ShipperID=@Id