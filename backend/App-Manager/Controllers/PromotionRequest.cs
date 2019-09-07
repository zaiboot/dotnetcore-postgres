namespace AppManager.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class PromotionRequest
    {
        [MaxLength(100)] 
        public string CustomerName { get; set; }

        [PositiveRange(1)]
        public int NumberOfPrizes { get; set; }

        [PositiveRange(1f)]
        public float TotalAmount { get; set; }
    }
}