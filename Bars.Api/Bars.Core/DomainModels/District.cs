namespace Bars.Core.DomainModels
{
	public sealed class District 
	{
        private readonly int _districtId;
        public int DistrictId { get { return _districtId; } }

        private readonly string _name;
        public string Name { get { return _name; } }

        public District(int districtId, string name)
        {
            _districtId = districtId;
            _name = name;
        }
    }
}
