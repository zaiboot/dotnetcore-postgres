using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AppManager.Common.JSonConverter;
using AppManager.DTO;
using AppManager.HttpTypedClients;
using Microsoft.Extensions.Logging;

namespace AppManager.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerApiTypedClient customerApiClient;
        private readonly IJsonConverter jsonConverter;
        private readonly ILogger logger;

        public CustomerRepository(CustomerApiTypedClient customerApiClient,
                                  IJsonConverter jsonConverter,
                                  ILogger<CustomerRepository> logger)
        {
            this.customerApiClient = customerApiClient;
            this.jsonConverter = jsonConverter;
            this.logger = logger;
        }

        public async Task<CustomerCreateResult> Create(CustomerCreateRequest customerCreateRequest)
        {
            var stringContent = await customerApiClient.CreateCustomerAsync(customerCreateRequest);            
            var result = jsonConverter.DeserializeObject<CustomerCreateResult>(stringContent);
            return result;
        }
    }
}