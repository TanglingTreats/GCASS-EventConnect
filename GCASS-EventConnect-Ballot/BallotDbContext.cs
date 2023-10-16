using System;
using GCASS_EventConnect_Ballot.Models;
using Microsoft.EntityFrameworkCore;
namespace GCASS_EventConnect_Ballot
{
	public class BallotDbContext : DbContext
	{
		public BallotDbContext()
		{
		}
        public BallotDbContext(DbContextOptions opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SnakeCaseIdentityTableNames(modelBuilder);
        }

        private void SnakeCaseIdentityTableNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ballot>(b => { b.ToTable("ballot"); });
        }
	}
}

