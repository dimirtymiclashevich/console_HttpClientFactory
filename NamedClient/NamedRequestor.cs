using System.Net.Http;
using System.Threading.Tasks;

namespace NamedClient
{
    public class NamedRequestor
    {
        private readonly IHttpClientFactory _clientFactory;

        public NamedRequestor(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> GetGoogleHtml()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/");
            var httpClient = _clientFactory.CreateClient("google");
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAmazonHtml()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/");
            var httpClient = _clientFactory.CreateClient("amazon");
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
