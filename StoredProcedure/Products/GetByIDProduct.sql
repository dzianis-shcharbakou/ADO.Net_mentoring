CREATE PROCEDURE [dbo].[GetByIdProduct]
@Id int
AS
    SELECT * FROM Products
    WHERE ProductID=@Id