using System.ComponentModel.DataAnnotations;
using Prizes.Attributes;

namespace Prizes.Model
{
    public class PrizeBulkCreationRequest
    {
        [Required]        
        public int CustomerId { get; set; }
        
        [Required]
        [Range(0,10)] //no more than 10 prizes, more than that might break.
        // if necessary add kafka or something different
        public int TotalPrizes { get; set; }

        [Required]
        [PositiveRange(1)]
        public float DistributionPerPrize { get; set; }
    }
}