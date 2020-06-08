CREATE PROCEDURE [dbo].[GetByIdCustomer]
@Id int
AS
    SELECT * FROM Customers
    WHERE CustomerID=@Id