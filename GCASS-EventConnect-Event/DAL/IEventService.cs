using System;
using GCASS_EventConnect_Event.Models;

namespace GCASS_EventConnect_Event.DAL
{
	public interface IEventService
	{
		IEnumerable<Event> GetEvents();

		void CreateEvent(Event event);
	}
}