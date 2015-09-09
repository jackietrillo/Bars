CREATE PROCEDURE [dbo].[GetTopList]
AS
	SET NOCOUNT ON

	SELECT TL.Rank, B.Name as BarName 
	FROM TopList TL
		INNER JOIN Bar B ON TL.BarId = B.BarId 
	WHERE B.StatusFlag = 1 