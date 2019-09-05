/*
    
    Customer name
- Number of Prizes
- Total Prize amount to distribute
     */
using System.ComponentModel.DataAnnotations;

namespace Prizes.Models
{
    public class PrizeInitRequest
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int NumberOfPrizes { get; set; }
                
        [Required]
        [Range(1, float.MaxValue)]
        public float TotalPrize { get; set; }

    }

}