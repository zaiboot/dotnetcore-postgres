namespace prizes
{
    using Microsoft.EntityFrameworkCore;
    using prizes.Repository.DTO;

    public class ApiDataContext : DbContext
    {
        public ApiDataContext(DbContextOptions<ApiDataContext> options) : base(options)
        {
        }

        public DbSet<CustomerInformation> Customer { get; set; }  
    }
}