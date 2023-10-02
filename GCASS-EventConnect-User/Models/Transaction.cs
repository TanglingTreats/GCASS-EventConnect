using System;
namespace GCASS_EventConnect_User.Models
{
	public class Transaction
	{
		public Guid id { get; set; }
		public Guid eventId { get; set; }
		public Guid userId { get; set; }
		public Guid ballotId { get; set; }
        public string? createdBy { get; set; }
        public DateTime? createdTime { get; set; }
        public string? updatedBy { get; set; }
        public DateTime? updatedTime { get; set; }

        public Transaction()
		{
		}
	}
}

