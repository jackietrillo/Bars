using System.Collections.Generic;

namespace Bars.Core.DomainModels
{
	public sealed class Bar : BaseEntity
	{
        private readonly int _barId;
		public int BarId { get { return _barId; } }     

        private readonly string _name;
        public string Name { get { return _name;  } }

        private readonly string _description;
        public string Description { get { return _description; } }

        private readonly string _address;
        public string Address { get { return _address; } }

        private readonly string _phone;
        public string Phone { get { return _phone; } }

        private readonly string _hours;
        public string Hours { get { return _hours; } }

        private readonly decimal _latitude;
        public decimal Latitude { get { return _latitude; } }

        private readonly decimal _longitude;
        public decimal Longitude { get { return _longitude; } }

        private readonly string _websiteUrl;
        public string WebsiteUrl { get { return _websiteUrl;  } }

        private readonly string _calendarUrl;
        public string CalendarUrl { get { return _calendarUrl; } }

        private readonly string _facebookUrl;
        public string FacebookUrl { get { return _facebookUrl; } }

        private readonly string _yelpUrl;
        public string YelpUrl { get { return _yelpUrl; } }

        private readonly string _imageUrl;
        public string ImageUrl { get { return _imageUrl; } }

        private readonly string _district;
        public string District { get { return _district; } }

        private readonly string _musicTypes;
        public string MusicTypes { get { return _musicTypes; } }

        private readonly string _barTypes;
        public string BarTypes { get { return _barTypes;  } }    

        /*  private readonly ICollection<Party> _parties;
          public ICollection<Party> Parties { get { return _parties; } }

          private readonly ICollection<Event> _events;
          public ICollection<Event> Events { get { return _events; } }

          public Bar(int barId, string name)
          {
              _barId = barId;
              _name = name;
          }
          */
        public Bar(int barId, string name, string description, string addresss, string phone, string hours, decimal latitude, decimal longitude, string websiteUrl, 
            string calenderUrl, string facebookUrl, string  yelpUrl, string imageUrl, string district, string musicTypes, string barTypes, bool statusFlag)
        {
            _barId = barId;
            _name = name;
            _description = description;
            _address = addresss;
            _phone = phone;
            _hours = hours;
            _latitude = latitude;
            _longitude = longitude;
            _websiteUrl = websiteUrl;
            _calendarUrl = calenderUrl;
            _facebookUrl = facebookUrl;
            _yelpUrl = yelpUrl;
            _imageUrl = imageUrl;
            _district = district;
            _musicTypes = musicTypes;
            _barTypes = barTypes;
            base.StatusFlag = statusFlag;
        }
    }
}

