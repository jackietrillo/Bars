using System.Collections.Generic;
using System.Data;
using Bars.Core.DomainModels;

namespace Bars.Data
{
    public static class BarsDataReaderToModelAdapter
    {
        public static Bar CreateBarInstance(IDataRecord dataRecord)
        {
            return new Bar(
                            (int)dataRecord["BarId"],
                            (string)dataRecord["Name"],
                            (string)dataRecord["Description"],
                            (string)dataRecord["Address"],
                            (string)dataRecord["Phone"],
                            (string)dataRecord["Hours"],
                            (decimal)dataRecord["Latitude"],
                            (decimal)dataRecord["longitude"],
                            (string)dataRecord["WebsiteUrl"],
                            (string)dataRecord["CalendarUrl"],
                            (string)dataRecord["FacebookUrl"],
                            (string)dataRecord["YelpUrl"],
                            (string)dataRecord["ImageUrl"],
                            (string)dataRecord["District"],
                            (string)dataRecord["MusicTypes"],
                            (string)dataRecord["BarTypes"],
                            (bool)dataRecord["StatusFlag"]
                        );
        }

        public static IEnumerable<Bar> CreateBarSequenceInstance(IDataReader dataReader)
        {
            var bars = new List<Bar>();
     
            while (dataReader.Read())
            {
                bars.Add(new Bar(
                            (int)dataReader["BarId"],
                            (string)dataReader["Name"],
                            (string)dataReader["Description"],
                            (string)dataReader["Address"],
                            (string)dataReader["Phone"],
                            (string)dataReader["Hours"],
                            (decimal)dataReader["Latitude"],
                            (decimal)dataReader["longitude"],
                            (string)dataReader["WebsiteUrl"],
                            (string)dataReader["CalendarUrl"],
                            (string)dataReader["FacebookUrl"],
                            (string)dataReader["YelpUrl"],
                            (string)dataReader["ImageUrl"],
                            (string)dataReader["District"],
                            (string)dataReader["MusicTypes"],
                            (string)dataReader["BarTypes"],
                            (bool)dataReader["StatusFlag"]
                        ));
            }
            return bars;
        }
    }
}
