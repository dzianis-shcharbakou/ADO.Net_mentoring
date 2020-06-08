CREATE PROCEDURE [dbo].[DeleteEmployee]
		@Id int
AS
    DELETE FROM [dbo].Employees 
	WHERE EmployeeID=@Id;