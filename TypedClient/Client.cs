using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace TypedClient
{
    class Client
    {
        private readonly GoogleService _googleService;
        private readonly AmazonService _amazonService;

        public Client()
        {
            _googleService = Program.Container.GetRequiredService<GoogleService>();
            _amazonService = Program.Container.GetRequiredService<AmazonService>();
        }

        public async Task<string> GetGoogle()
        {
            var html = await _googleService.GetGoogleHtml();
            return html;
        }

        public async Task<string> GetAmazon()
        {
            var html = await _amazonService.GetAmazonHtml();
            return html;
        }
    }
}
