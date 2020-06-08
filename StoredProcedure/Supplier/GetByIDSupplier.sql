CREATE PROCEDURE [dbo].[GetByIdSupplier]
@Id int
AS
    SELECT * FROM Suppliers
    WHERE SupplierID=@Id