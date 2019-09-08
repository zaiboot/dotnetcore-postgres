using System;
using System.Net.Http;
using System.Threading.Tasks;
using AppManager.Common.JSonConverter;
using AppManager.DTO;

namespace AppManager.HttpTypedClients
{
    //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-2.2#typed-clients
    public class CustomerApiTypedClient: BaseApiTypedClient
    {

        public CustomerApiTypedClient(IHttpClientFactory clientFactory, IJsonConverter jsonConverter) : base(clientFactory, "customer-api", jsonConverter)
        {
            
            this.client.BaseAddress = new Uri("http://localhost:6000/api/Customer"); //get this from config file
        }

        public async Task<string> CreateCustomerAsync(CustomerCreateRequest customerCreateRequest)
        {
            var stringContent = await DoPostAsync(customerCreateRequest);
            return stringContent;
        }

       
    }
}