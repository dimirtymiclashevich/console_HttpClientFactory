using System.Net.Http;
using System.Threading.Tasks;

namespace TypedClient
{
    class AmazonService
    {
        private  HttpClient _httpClient { get; }

        public AmazonService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<string> GetAmazonHtml()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/");
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
