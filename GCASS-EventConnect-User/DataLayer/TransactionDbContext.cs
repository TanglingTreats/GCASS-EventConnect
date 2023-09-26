using Microsoft.EntityFrameworkCore;

namespace GCASS_EventConnect_User.DataLayer
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext() { }
        public TransactionDbContext(DbContextOptions opts) : base(opts) { }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SnakeCaseIdentityTableNames(modelBuilder);
        }

        private void SnakeCaseIdentityTableNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>(b => { b.ToTable("transaction"); });
        }
    }
}
