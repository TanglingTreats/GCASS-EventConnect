using System;
namespace GCASS_EventConnect_Ballot.Models
{
	public class BallotRequest
	{
		public Guid userId { get; set; }
		public Guid boothId { get; set; }
		public int amount { get; set; }

		public BallotRequest()
		{
		}
	}
}

