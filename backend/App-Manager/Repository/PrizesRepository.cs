using System;
using System.Net.Http;
using System.Threading.Tasks;
using AppManager.Common.JSonConverter;
using AppManager.DTO;

namespace AppManager.Controllers
{
    public class PrizesRepository : IPrizesRepository
    {

        private readonly HttpClient client;
        private readonly IJsonConverter jsonConverter;

        public PrizesRepository(IHttpClientFactory clientFactory, IJsonConverter jsonConverter)
        {
            this.client = clientFactory.CreateClient("prizes-api");
            this.jsonConverter = jsonConverter;
            this.client.BaseAddress = new Uri("https://localhost:5001/api/Customer");
        }

        public async Task<PrizeBulkCreationResult> CreatePrizes(PrizeBulkCreationRequest prizeBulkCreationRequest)
        {
            //something can be done here to make it generic and make the code easier to maintain and 
            // easier to unit tests. lack of time is a constraint here.
            var request = jsonConverter.SerializeObject(prizeBulkCreationRequest);
            var response = await this.client.PostAsJsonAsync(string.Empty, request);
            var result = new PrizeBulkCreationResult()
            {
                Code = response.StatusCode
            };
            
            return result;
        }
    }
}