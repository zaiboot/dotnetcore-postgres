namespace Prizes.DataContext
{
    using Microsoft.EntityFrameworkCore;
    using Prizes.DTO;

    public class PrizesDataContext : DbContext
    {
        public PrizesDataContext(DbContextOptions<CustomerDataContext> options) : base(options)
        {
        }
        
        public DbSet<Prize> Prizes { get; set; }
    }
}