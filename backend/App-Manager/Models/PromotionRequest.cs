namespace AppManager.Models
{
    using System.ComponentModel.DataAnnotations;
    using  Attributes;
    public class PromotionRequest
    {
        [MaxLength(100)] 
        [Required]
        public string CustomerName { get; set; }

        [PositiveRange(1)]
        public int NumberOfPrizes { get; set; }

        [PositiveRange(1F)]
        public float TotalAmount { get; set; }
    }
}