using System;

namespace Bars.Core.DomainModels
{
	public sealed class Event : BaseEntity
	{
        private readonly int _eventId;
		public int EventId { get { return _eventId; } }

        private readonly string _name;
        public string Name { get { return _name; } }

        private readonly string _description;
        public string Description { get { return _description; } }

        private readonly string _address;
        public string Address { get { return _address;  } }

        private readonly DateTime _eventDate;
        public DateTime EventDate { get { return _eventDate; } }

        public Event(int eventId, string name, string description, string address, DateTime eventDate)
        {
            _eventId = eventId;
            _name = name;
            _description = description;
            _address = address;
            _eventDate = eventDate;
        }
    }
}
