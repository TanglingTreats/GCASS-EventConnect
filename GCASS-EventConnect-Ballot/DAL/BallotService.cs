using System;
using GCASS_EventConnect_Ballot.Models;

namespace GCASS_EventConnect_Ballot.DAL
{
	public class BallotService : IBallotService
	{

		public BallotService()
		{
		}

        public IEnumerable<Ballot> GetBallots()
        {
            throw new NotImplementedException();
        }
    }
}

