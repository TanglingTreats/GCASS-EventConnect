using GCASS_EventConnect_Ballot.DAL;
using GCASS_EventConnect_Ballot.Models;
using Microsoft.AspNetCore.Mvc;

namespace GCASS_EventConnect_Ballot.Controllers;

[ApiController]
[Route("[controller]")]
public class BallotsController : ControllerBase
{

    private readonly IBallotService _ballotService;

    private readonly ILogger<BallotsController> _logger;

    public BallotsController(ILogger<BallotsController> logger, IBallotService ballotService)
    {
        _logger = logger;
        _ballotService = ballotService;
    }

    [HttpGet]
    public IEnumerable<Ballot> Get()
    {
        return _ballotService.GetBallots();
    }
}

