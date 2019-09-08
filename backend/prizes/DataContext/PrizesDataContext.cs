namespace Prizes.DataContext
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Npgsql;
    using Prizes.DTO;

    public class PrizesDataContext : DbContext
    {
        //https://www.npgsql.org/efcore/mapping/enum.html
        static PrizesDataContext() => NpgsqlConnection.GlobalTypeMapper.MapEnum<StatusEnum>();

        public PrizesDataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ForNpgsqlHasEnum<StatusEnum>();
            //builder.ForNpgsqlHasEnum("statusenum", Enum.GetNames(typeof(StatusEnum)));
        }

        public DbSet<Prize> Prizes { get; set; }
    }
}