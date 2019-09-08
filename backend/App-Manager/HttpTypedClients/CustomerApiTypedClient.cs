using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AppManager.Common.JSonConverter;
using AppManager.DTO;

namespace AppManager.HttpTypedClients
{
    public class CustomerApiTypedClient
    {
        private readonly IJsonConverter jsonConverter;
        private HttpClient client;

        public CustomerApiTypedClient(IHttpClientFactory clientFactory, IJsonConverter jsonConverter)
        {
            this.client = clientFactory.CreateClient("customer-api");
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.client.BaseAddress = new Uri("http://localhost:6000/api/Customer");
            this.jsonConverter = jsonConverter;
        }

        public async Task<string> CreateCustomerAsync(CustomerCreateRequest customerCreateRequest)
        {

            var request = jsonConverter.SerializeObject(customerCreateRequest);            
            HttpRequestMessage r = new HttpRequestMessage(HttpMethod.Post, string.Empty);
            r.Content = new StringContent(request, Encoding.UTF8, "application/json");

            var response = await this.client.SendAsync(r);
            var stringContent = await response.Content.ReadAsStringAsync();
            return stringContent;
        }

       
    }
}