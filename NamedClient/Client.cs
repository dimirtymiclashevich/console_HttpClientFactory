using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Threading.Tasks;

namespace NamedClient
{
    class Client
    {
        private readonly NamedRequestor _requestor;

        public Client()
        {
            var _httpClientFactory = Program.Container.GetRequiredService<IHttpClientFactory>();
            _requestor = new NamedRequestor(_httpClientFactory);
        }

        public async Task<string> GetGoogle()
        {
            var html = await _requestor.GetGoogleHtml();
            return html;
        }

        public async Task<string> GetAmazon()
        {
            var html = await _requestor.GetAmazonHtml();
            return html;
        }
    }
}
