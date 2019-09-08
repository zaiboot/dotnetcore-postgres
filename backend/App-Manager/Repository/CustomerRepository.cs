using System;
using System.Net.Http;
using System.Threading.Tasks;
using AppManager.Common.JSonConverter;
using AppManager.DTO;

namespace AppManager.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly HttpClient client;
        private readonly IJsonConverter jsonConverter;

        public CustomerRepository(IHttpClientFactory clientFactory, IJsonConverter jsonConverter)
        {
            this.client = clientFactory.CreateClient("customer-api");
            this.jsonConverter = jsonConverter;
            this.client.BaseAddress = new Uri("http://localhost:6000/api/Customer");
        }

        public async Task<CustomerCreateResult> Create(CustomerCreateRequest customerCreateRequest)
        {
            var request = jsonConverter.SerializeObject(customerCreateRequest);
            var response = await this.client.PostAsJsonAsync(string.Empty, request);
            CustomerCreateResult result = new CustomerCreateResult()
            {
                Code = response.StatusCode
            };
            
            return result;
        }
    }
}