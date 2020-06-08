CREATE PROCEDURE [dbo].[GetByIdOrder]
@Id int
AS
    SELECT * FROM Orders
    WHERE OrderID=@Id