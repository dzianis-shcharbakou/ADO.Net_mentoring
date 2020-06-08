CREATE PROCEDURE [dbo].[UpdateCustomerDemographic]
	@CustomerTypeID nchar(10),
    @CustomerDesc ntext
AS
    UPDATE CustomerDemographics set CustomerDesc=@CustomerDesc
	where CustomerTypeID = @CustomerTypeID