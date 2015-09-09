CREATE PROCEDURE [dbo].[GetMusicTypes]
AS
	SET NOCOUNT ON

	SELECT MusicTypeId, Name              
	FROM MusicType