using System;
using GCASS_EventConnect_Event.DAL;
using GCASS_EventConnect_Event.Models;
using GCASS_EventConnect_Event.DataAccess;

namespace GCASS_EventConnect_Event.DAL
{
	public class EventRepository : IEventRepository
    {
        private readonly EventDbContext _context;

		public EventRepository(EventDbContext context)
		{
            this._context = context;
		}

        public void Dispose()
        {
            _context.Dispose();
        }
        public void Add(Event _event)
        {
            Console.WriteLine("Add Event");
            _context.Event.Add(_event);
            _context.SaveChanges();
        }
        public IEnumerable<Event> GetEventswithID(string id)
        {
            var results = _context.Event.Where(currentEvent => currentEvent.id.Equals(id) && currentEvent.status.status == "1").ToList();
            return results; 
        }
        public IEnumerable<Event> GetEventswithName(string name)
        {
            var results = _context.Event.Where(currentEvent => currentEvent.title.Contains(name) && currentEvent.status.status == "1").ToList();
            return results;
        }

        public bool UpdateEvent(Event _event, out string reason)
        {
            try
            {
                var result = _context.Event.FirstOrDefault<Event>(item => item.id == _event.id);

                if (result == null)
                {
                    reason = "No event found";
                    return false;
                }
                else
                {
                    _event.status.status = _event.status == null ? result.status.status : _event.status.status;
                    _event.location = _event.location == null ? result.location : _event.location;


                    result = _event;
                    _context.SaveChanges();
                    reason = "";
                    return true;
                }
            }         

             catch (Exception ex)
            {
                reason="Some errors occured";
                return false;
            }

        }

        public void DeleteEvent(string id)
        {
            var result = _context.Event.FirstOrDefault<Event>(item => item.id.ToString() == id);
            if (result != null)
                _context.Remove(result);
        }

    }
}

