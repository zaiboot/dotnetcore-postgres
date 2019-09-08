namespace AppManager.DTO
{
    public class PrizeBulkCreationRequest
    {
        public int CustomerId { get; set; }
        public int TotalPrizes { get; set; }
        public float DistributionPerPrize { get; set; }
    }
}