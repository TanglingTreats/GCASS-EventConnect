using System;
using System.Collections.Generic;
using GCASS_EventConnect_Event.Models;

namespace GCASS_EventConnect_Event.DAL
{
	public interface IEventRepository : IDisposable
	{
		void Add(Event _event);
		
		IEnumerable<Event> GetEvents();
	}
}

