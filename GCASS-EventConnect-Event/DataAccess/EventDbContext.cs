using Microsoft.EntityFrameworkCore;
using GCASS_EventConnect_Event.Models;

namespace GCASS_EventConnect_Event.DataAccess
{
    public class EventDbContext:DbContext
    {
        public EventDbContext() { }
        public EventDbContext(DbContextOptions opts):base(opts) { }

        public DbSet<Event> Event { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SnakeCaseIdentityTableNames(modelBuilder);
        }

        private static void SnakeCaseIdentityTableNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(b => { b.ToTable("event"); });
        }
    }
}
