using Microsoft.EntityFrameworkCore;

namespace GCASS_EventConnect.DataLayer
{
    public class UsersDbContext : DbContext {
        public UsersDbContext() { }
        public UsersDbContext(DbContextOptions opts) : base(opts) { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SnakeCaseIdentityTableNames(modelBuilder);
        }

        private void SnakeCaseIdentityTableNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(b => { b.ToTable("user"); });
        }
    }
}
