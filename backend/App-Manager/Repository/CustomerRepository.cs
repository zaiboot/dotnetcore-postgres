using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AppManager.Common.JSonConverter;
using AppManager.DTO;
using Microsoft.Extensions.Logging;

namespace AppManager.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly HttpClient client;
        private readonly IJsonConverter jsonConverter;
        private readonly ILogger logger;

        public CustomerRepository(IHttpClientFactory clientFactory, IJsonConverter jsonConverter, ILogger<CustomerRepository> logger)
        {
            this.client = clientFactory.CreateClient("customer-api");
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.jsonConverter = jsonConverter;
            this.logger = logger;
            this.client.BaseAddress = new Uri("http://localhost:6000/api/Customer");
        }

        public async Task<CustomerCreateResult> Create(CustomerCreateRequest customerCreateRequest)
        {
            var request = jsonConverter.SerializeObject(customerCreateRequest);
            this.logger.LogInformation("POST {0} {1}", client.BaseAddress, request);
            HttpRequestMessage r = new HttpRequestMessage(HttpMethod.Post, string.Empty);
            r.Content = new StringContent(request, Encoding.UTF8, "application/json");

            var response = await this.client.SendAsync(r);
            var stringContent = await response.Content.ReadAsStringAsync();
            var result = jsonConverter.DeserializeObject<CustomerCreateResult>(stringContent);
            result.Code = response.StatusCode;
            return result;
        }
    }
}