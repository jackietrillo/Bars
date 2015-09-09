CREATE PROCEDURE [dbo].[GetBars]
AS
	SET NOCOUNT ON

	SELECT		Bar.BarId, Bar.Name, Bar.[Description], Bar.[Address], Bar.Phone, Bar.[Hours], Bar.Latitude, Bar.Longitude, 
				Bar.WebsiteUrl, Bar.CalendarUrl, Bar.FacebookUrl, Bar.YelpUrl, Bar.ImageUrl, District.Name AS District, 
				ISNULL(SUBSTRING((SELECT ', ' + MusicType.Name
								  FROM			 MusicType 
								  INNER JOIN	 MusicTypeBar ON MusicType.MusicTypeId = MusicTypeBar.MusicTypeId
								  WHERE		 MusicTypeBar.BarId = Bar.BarId
								  FOR XML PATH('')), 3, 1000), '') AS MusicTypes, 
				ISNULL(SUBSTRING((SELECT ', ' +  BarType.Name
								  FROM			 BarType 
								  INNER JOIN	 BarTypeBar ON BarType.BarTypeId = BarTypeBar.BarTypeId
								  WHERE			 BarTypeBar.BarId = Bar.BarId
								  FOR XML PATH('')), 3, 1000), '') AS BarTypes,
				Bar.StatusFlag
	FROM		Bar	
	INNER JOIN	District ON Bar.DistrictId = District.DistrictId		

	SET NOCOUNT OFF

