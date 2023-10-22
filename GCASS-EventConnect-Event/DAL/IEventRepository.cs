using System;
using System.Collections.Generic;
using GCASS_EventConnect_Event.Models;

namespace GCASS_EventConnect_Event.DAL
{
	public interface IEventRepository : IDisposable
	{
		void Add(Event _event);
		
		IEnumerable<Event> GetEventswithID(string id);

		IEnumerable<Event> GetEventswithName(string name);

		bool UpdateEvent(Event _event, out string reason);

		void DeleteEvent(string id);

	}
}

