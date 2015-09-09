CREATE PROCEDURE [dbo].[GetDistricts]	
AS
	SET NOCOUNT ON

	SELECT DistrictId, Name              
	FROM District