using Microsoft.AspNetCore.Mvc;
using GCASS_EventConnect_Event.DAL;
using GCASS_EventConnect_Event.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GCASS_EventConnect_Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private IEventRepository _eventRepository;
        private readonly ILogger<EventsController> _logger;

        public EventsController(ILogger<EventsController> logger, IEventRepository eventRepository)
        {
            _logger = logger;
            _eventRepository = eventRepository;
        }
        // GET: api/<ValuesController>
       

        // GET api/<ValuesController>/5
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var result=_eventRepository.GetEventswithName(name);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Event _event)
        {
            _eventRepository.Add(_event);
            return Ok("");
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Event _event)
        {
            if (_eventRepository.UpdateEvent(_event, out string reason) == true)
                return Ok("");
            else
            {
                return BadRequest(reason);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                _eventRepository.DeleteEvent(id);
                return Ok("The event is deleted");
            }
            catch   (Exception ex)
            {
                return BadRequest("Some errors occured");
            }
        }
    }
}
