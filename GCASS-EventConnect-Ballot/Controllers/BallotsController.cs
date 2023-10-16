using Microsoft.AspNetCore.Mvc;

namespace GCASS_EventConnect_Ballot.Controllers;

[ApiController]
[Route("[controller]")]
public class BallotsController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<BallotsController> _logger;

    public BallotsController(ILogger<BallotsController> logger)
    {
        _logger = logger;
    }

    public IEnumerable<Ballot> Get()
    {
        return null;
    }
}


