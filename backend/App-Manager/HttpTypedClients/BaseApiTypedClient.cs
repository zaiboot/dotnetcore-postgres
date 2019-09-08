using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppManager.Common.JSonConverter;

namespace AppManager.HttpTypedClients
{
    public abstract class BaseApiTypedClient
    {
        protected HttpClient client;
        private readonly IJsonConverter jsonConverter;

        public BaseApiTypedClient(IHttpClientFactory clientFactory, string clientName, IJsonConverter jsonConverter)
        {
            this.client = clientFactory.CreateClient(clientName);
            this.jsonConverter = jsonConverter;
        }
        protected async Task<string> DoPostAsync<TRequest>(TRequest r11)
        {
            var request = jsonConverter.SerializeObject(r11);
            HttpRequestMessage r = new HttpRequestMessage(HttpMethod.Post, string.Empty);
            r.Content = new StringContent(request, Encoding.UTF8, "application/json");

            var response = await this.client.SendAsync(r);
            var stringContent = await response.Content.ReadAsStringAsync();
            return stringContent;
        }
    }
}