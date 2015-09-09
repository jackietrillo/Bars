using System;

namespace Bars.Core.DomainModels
{
    public sealed class Party : BaseEntity
    {
        private readonly int _partyId;
        public int PartyId { get { return _partyId; } }

        private readonly string _name;
        public string Name { get { return _name; } }

        private readonly string _description;
        public string Description { get { return _description; } }

        private readonly string _address;
        public string Address { get { return _address; } }

        private readonly DateTime _partyDate;
        public DateTime PartyDate { get { return _partyDate; } }

        public Party(int partyId, string name, string description, string address, DateTime partyDate)
        {
            _partyId = partyId;
            _name = name;
            _description = description;
            _address = address;
            _partyDate = partyDate;
        }
    }
}
