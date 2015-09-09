using Bars.WebApi.Models;

namespace Bars.WebApi.Mappers
{
    public class DomainModelToApiModelMapper
    {
        public static Bar Map(Bars.Core.DomainModels.Bar source)
        {
            return new Bar(source.Name, source.Description, source.Address, source.Phone, source.Hours,
                            source.Latitude, source.Longitude, source.WebsiteUrl, source.CalendarUrl,
                            source.FacebookUrl, source.YelpUrl, source.ImageUrl, source.District,
                            source.MusicTypes, source.BarTypes, source.StatusFlag);
        }

    }
}