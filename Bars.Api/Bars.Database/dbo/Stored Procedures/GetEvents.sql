CREATE PROCEDURE [dbo].[GetEvents]
AS
	SET NOCOUNT ON

	SELECT E.Name AS EventName, E.[Address], E.EventDate, B.Name AS BarName
	FROM [Event] E 
		INNER JOIN Bar B ON E.BarId = B.BarId
	WHERE B.StatusFlag = 1 AND E.StatusFlag = 1
