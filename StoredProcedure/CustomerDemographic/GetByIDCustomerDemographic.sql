CREATE PROCEDURE [dbo].[GetByIdCustomerDemographic]
@Id int
AS
    SELECT * FROM CustomerDemographics
    WHERE CustomerTypeID=@Id