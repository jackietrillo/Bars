namespace Bars.Core.DomainModels
{
	public sealed class BarType 
	{
        private readonly int _barTypeId;
		public int BarTypeId { get { return _barTypeId; } }

        private readonly string _name;
        public string Name { get { return _name;  } }

        public BarType(int barTypeId, string name)
        {
            _barTypeId = barTypeId;
            _name = name;            
        }
    }
}
