CREATE PROCEDURE [dbo].[GetParties]
AS
	SET NOCOUNT ON

	SELECT P.Name AS PartyName, P.[Address], P.PartyDate, ISNULL(B.Name, '') AS BarName
	FROM [Party] P
		LEFT OUTER JOIN Bar B ON P.BarId = B.BarId
	WHERE B.StatusFlag = 1 AND P.StatusFlag = 1