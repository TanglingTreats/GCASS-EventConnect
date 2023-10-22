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
        public IEnumerable<Event> GetEvents()
        {
            throw new NotImplementedException();
        }
    }
}

