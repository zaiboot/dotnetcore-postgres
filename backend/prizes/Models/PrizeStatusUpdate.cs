namespace Prizes.Controllers
{
    public class PrizeStatusUpdateRequest
    {
        public int Id { get; set; }
        public Status NewStatus { get; set; }
    }
}