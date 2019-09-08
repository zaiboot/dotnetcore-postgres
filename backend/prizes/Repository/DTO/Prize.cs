using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prizes.DTO
{
    [Table("prize_customer")]
    public class Prize
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("amount")]
        public float Amount { get; set; }

        [Column("prizename")]
        public string Name { get; set; }

        [Column("customerid")]
        public int CustomerId { get; set; }

        [Column("prize_status")]
        public string PrizeStatus { get; set; }

        [NotMapped]
        public StatusEnum Status
        {
            get
            {
                StatusEnum result;
                if (!Enum.TryParse<StatusEnum>(PrizeStatus, out result))
                {
                    result = StatusEnum.NOT_INITIALIZED;
                }
                return result;
            }
            set {
                PrizeStatus = value.ToString();
            }
        }
    }
}