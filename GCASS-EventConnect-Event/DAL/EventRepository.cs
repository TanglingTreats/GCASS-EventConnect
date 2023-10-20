using System;


namespace  GCASS_EventConnect_Event.DAL{
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
        public IEnumerable<Event> GetEvents()
        {
            throw new NotImplementedException();
        }

        public void CreateEvent(Event event)
        {
        }
    }
}

