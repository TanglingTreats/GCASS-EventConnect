using System;
namespace GCASS_EventConnect_User.Models
{
	public class Transaction
	{
		public Guid id { get; set; }
		public Guid eventId { get; set; }
		public Guid userId { get; set; }
		public Guid ballotId { get; set; }
		public Guid createdBy { get; set; }
		public Guid createdTime { get; set; }
		public Guid updatedBy { get; set; }
		public Guid updatedTime { get; set; }

		public Transaction()
		{
		}
	}
}

