CREATE PROCEDURE [dbo].[GetBarTypes]	
AS
	SET NOCOUNT ON

	SELECT BarTypeId, Name              
	FROM BarType

