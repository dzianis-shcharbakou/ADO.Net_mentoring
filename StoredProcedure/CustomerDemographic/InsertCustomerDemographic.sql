CREATE PROCEDURE [dbo].[InsertCustomerDemographic]
	@CustomerTypeID nchar(10),
    @CustomerDesc ntext
AS
    INSERT INTO [dbo].CustomerDemographics(CustomerTypeID, CustomerDesc)
    VALUES (@CustomerTypeID, @CustomerDesc)
    SELECT SCOPE_IDENTITY()