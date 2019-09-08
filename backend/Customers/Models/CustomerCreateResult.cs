using System.Net;

namespace Customers.Models
{
    public class CustomerCreateResult
    {
        public int CustomerId;

        public HttpStatusCode Code { get; set; }
    }
}