using System;
using GCASS_EventConnect_Event.Models;

namespace GCASS_EventConnect_Event.DAL
{
	public class EventService : IEventService
	{
	    private readonly IEventRepository _eventRepository;

		public EventService(IEventRepository eventRepository)
		{
            _eventRepository = eventRepository;
		}

        public  Event CreateEvent(Event event)
        {
            _eventRepository.Add(event)
        }

        public IEnumerable<Event> GetEvents()
        {
            throw new NotImplementedException();
        }


    }
}

