namespace prizes
{
    using Microsoft.EntityFrameworkCore;
    using prizes.Repository.DTO;

    public class CustomerDataContext : DbContext
    {
        public CustomerDataContext(DbContextOptions<CustomerDataContext> options) : base(options)
        {
        }

        public DbSet<CustomerInformation> Customer { get; set; }  
    }
}