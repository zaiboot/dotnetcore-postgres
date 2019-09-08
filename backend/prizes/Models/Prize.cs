using Prizes.DTO;

namespace Prizes.Models
{
    public class Prize
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }

    }
}