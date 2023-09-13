using Microsoft.AspNetCore.Mvc;

namespace GCASS_EventConnect_Event.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{
    private readonly ILogger<EventsController> _logger;

    public EventsController(ILogger<EventsController> logger)
    {
        _logger = logger;
    }


    public IEnumerable<Event> Get()
    {
        return null;
    }
}

