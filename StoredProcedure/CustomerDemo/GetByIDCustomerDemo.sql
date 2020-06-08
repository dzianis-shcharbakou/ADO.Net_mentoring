CREATE PROCEDURE [dbo].[GetByIdCustomerDemo]
@Id int
AS
    SELECT * FROM CustomerCustomerDemo
    WHERE CustomerID=@Id