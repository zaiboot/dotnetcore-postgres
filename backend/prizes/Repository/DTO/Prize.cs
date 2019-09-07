using System.ComponentModel.DataAnnotations.Schema;

namespace Prizes.DTO
{
    [Table("prize")]
    public class Prize
    {
         [Column("id")]
        public int Id { get; set; }
         [Column("amount")]
        public float Amount { get; set; }
         [Column("name")]
        public string Name { get; set; }
    }
}