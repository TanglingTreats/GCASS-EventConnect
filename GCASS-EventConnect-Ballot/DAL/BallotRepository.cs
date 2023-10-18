using System;
using GCASS_EventConnect_Ballot.Models;

namespace GCASS_EventConnect_Ballot.DAL
{
	public class BallotRepository : IBallotRepository
	{
        private readonly BallotDbContext _context;

		public BallotRepository(BallotDbContext context)
		{
            this._context = context;
		}

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Add(Ballot ballot)
        {
            Console.WriteLine("Add ballot");
            _context.Ballots.Add(ballot);
            _context.SaveChanges();
        }

        public IEnumerable<Ballot> GetBallots()
        {
            throw new NotImplementedException();
        }
    }
}

