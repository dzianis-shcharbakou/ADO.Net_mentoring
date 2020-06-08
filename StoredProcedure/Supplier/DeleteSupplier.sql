CREATE PROCEDURE [dbo].[DeleteSupplier]
		@Id int
AS
    DELETE FROM [dbo].Suppliers 
	WHERE SupplierID=@Id;