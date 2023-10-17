using System;
using GCASS_EventConnect_Ballot.Models;

namespace GCASS_EventConnect_Ballot.DAL
{
	public interface IBallotService
	{
		IEnumerable<Ballot> GetBallots();
	}
}