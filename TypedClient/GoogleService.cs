using System.Net.Http;
using System.Threading.Tasks;

namespace TypedClient
{
    class GoogleService
    {
        private HttpClient _httpClient { get; }

        public GoogleService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<string> GetGoogleHtml()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/");
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
