using Microsoft.AspNetCore.Mvc;
using GCASS_EventConnect_User.Models;

namespace GCASS_EventConnect_User.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<User> Get()
    {
        return null;
    }
}

