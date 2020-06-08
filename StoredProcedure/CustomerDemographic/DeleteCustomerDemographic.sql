CREATE PROCEDURE [dbo].[DeleteCustomerDemographic]
		@Id int
AS
    DELETE FROM [dbo].CustomerDemographics
	WHERE CustomerTypeID=@Id;