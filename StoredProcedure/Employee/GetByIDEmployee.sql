CREATE PROCEDURE [dbo].[GetByIdEmployee]
@Id int
AS
    SELECT * FROM Employees
    WHERE EmployeeID=@Id