using System.Net;

namespace AppManager.DTO
{
    public class CustomerCreateResult
    {
        public int CustomerId;

        public HttpStatusCode Code { get; set; }
    }
}