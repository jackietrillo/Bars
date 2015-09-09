namespace Bars.Core.DomainModels
{
	public sealed class TopList 
	{      
        private readonly string _barName;
        public string BarName { get { return _barName; } }

        private readonly byte _rank;
        public byte Rank { get { return _rank;  } }

        public TopList(byte rank, string barName)
        {
            _rank = rank;
            _barName = barName;            
        }
    }
}
