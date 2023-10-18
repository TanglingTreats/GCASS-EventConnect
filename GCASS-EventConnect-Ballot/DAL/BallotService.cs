using System;
using GCASS_EventConnect_Ballot.Models;

namespace GCASS_EventConnect_Ballot.DAL
{
	public class BallotService : IBallotService
	{
	    private readonly IBallotRepository _ballotRepository;

		public BallotService(IBallotRepository ballotRepository)
		{
            _ballotRepository = ballotRepository;
		}

        public void Add(BallotRequest ballotReq)
        {
            Ballot ballot = new Ballot();
            ballot.amount = ballotReq.amount;
            ballot.boothId = ballotReq.boothId;
            ballot.userId = ballotReq.userId;
            ballot.status = 1;

            _ballotRepository.Add(ballot);
        }

        public IEnumerable<Ballot> GetBallots()
        {
            throw new NotImplementedException();
        }


    }
}

