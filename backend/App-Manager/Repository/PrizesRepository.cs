using System;
using System.Net.Http;
using System.Threading.Tasks;
using AppManager.Common.JSonConverter;
using AppManager.DTO;
using AppManager.HttpTypedClients;

namespace AppManager.Controllers
{
    public class PrizesRepository : IPrizesRepository
    {

        private readonly IJsonConverter jsonConverter;
        private readonly PrizesApiTypedClient prizesApiClient;

        public PrizesRepository(IJsonConverter jsonConverter, PrizesApiTypedClient prizesApiClient)
        {
            this.jsonConverter = jsonConverter;
            this.prizesApiClient = prizesApiClient;
        }

        public async Task<PrizeBulkCreationResult> CreatePrizes(PrizeBulkCreationRequest prizeBulkCreationRequest)
        {

            var stringContent = await prizesApiClient.CreatePrizesBulkAsync(prizeBulkCreationRequest);
            var result = jsonConverter.DeserializeObject<PrizeBulkCreationResult>(stringContent);
            return result;

        }
    }
}