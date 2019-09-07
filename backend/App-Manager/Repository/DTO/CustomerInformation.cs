using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Repository.DTO
{
    // It appears postgre allows different cases for the tables
    // however when the case is not lower we have to wrap the object name with ""
    // the code for EF-Core-npgsql which uses this functionality lives here:
    //https://github.com/npgsql/Npgsql.EntityFrameworkCore.PostgreSQL/blob/master/src/EFCore.PG/Storage/Internal/NpgsqlSqlGenerationHelper.cs#L40
    [Table("customer")]
    public class CustomerInformation
    {
        //columns have to be applied this as well
        [Column("id")]
        public int Id { get; set; }
        [Column("customername")]
        public string CustomerName { get; set; }
        [Column("claimedamount")]
        public float ClaimedAmount { get; set; }
    }

    //there gotta be a cleaner way to do it. Maybe later when I get this up and running
}