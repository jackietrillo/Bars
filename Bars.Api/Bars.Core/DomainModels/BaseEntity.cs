using System;

namespace Bars.Core.DomainModels
{
    public class BaseEntity
    {
		public int LastUserId { get; set; }
		public DateTime LastUpdate { get; set; }
		public DateTime CreateDate { get; set; }
		public bool StatusFlag { get; set; }
    }
}
