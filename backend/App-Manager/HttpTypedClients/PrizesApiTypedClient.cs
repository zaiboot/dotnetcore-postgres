
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AppManager.Common.JSonConverter;
using AppManager.DTO;

namespace AppManager.HttpTypedClients
{

    //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-2.2#typed-clients
    public class PrizesApiTypedClient : BaseApiTypedClient
    {

        public PrizesApiTypedClient(IHttpClientFactory clientFactory, IJsonConverter jsonConverter) : base(clientFactory, "prizes-api", jsonConverter)
        {
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.client.BaseAddress = new Uri("http://localhost:5000/api/Prize"); //get this from config file

        }

        public async Task<string> CreatePrizesBulkAsync(PrizeBulkCreationRequest prizeBulkCreationRequest)
        {
            return await DoPostAsync(prizeBulkCreationRequest);
        }


    }
}