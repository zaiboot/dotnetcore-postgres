using System.ComponentModel.DataAnnotations;

namespace Customers.Models
{
    public class CreateCustomerRequest
    {
        [MaxLength(100)]
        [Required]
        public string CustomerName { get; set; }
    }
}