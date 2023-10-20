using System;
using Microsoft.EntityFrameworkCore;

namespace GCASS_EventConnect_Event
{
	public class EventDbContext : DbContext
	{
        public DbSet<Event> Events { get; set; }

		public EventDbContext()
		{
		}
        public EventDbContext(DbContextOptions opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SnakeCaseIdentityTableNames(modelBuilder);
        }

        private void SnakeCaseIdentityTableNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(b => { b.ToTable("event"); });
        }
	}
}

