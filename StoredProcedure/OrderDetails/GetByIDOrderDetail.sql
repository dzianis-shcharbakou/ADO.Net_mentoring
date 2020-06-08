CREATE PROCEDURE [dbo].[GetByIdOrderDetail]
@Id int
AS
    SELECT * FROM [Order Details]
    WHERE OrderID=@Id