using System;
using GCASS_EventConnect_Ballot.Models;

namespace GCASS_EventConnect_Ballot.DAL
{
	public class BallotRepository : IBallotRepository
	{
        private BallotDbContext context;

		public BallotRepository(BallotDbContext context)
		{
            this.context = context;
		}

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ballot> GetBallots()
        {
            throw new NotImplementedException();
        }
    }
}

