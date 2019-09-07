namespace Prizes.DataContext
{
    using Microsoft.EntityFrameworkCore;
    using Prizes.Repository.DTO;

    public class CustomerDataContext : DbContext
    {
        public CustomerDataContext(DbContextOptions<CustomerDataContext> options) : base(options)
        {
        }

        public DbSet<CustomerInformation> Customer { get; set; }  
    }
}