namespace Customers.DataContext
{
    using Microsoft.EntityFrameworkCore;
    using Customers.Repository.DTO;

    public class CustomerDataContext : DbContext
    {
        public CustomerDataContext(DbContextOptions<CustomerDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ForNpgsqlUseSequenceHiLo();
            // modelBuilder.Entity<CustomerInformation>()
            //     .HasKey( c => c.Id);
        }

        public DbSet<CustomerInformation> Customer { get; set; }
    }
}