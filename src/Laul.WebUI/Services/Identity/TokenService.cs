using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace Laul.WebUI.Services.Identity
{
    public class TokenService : ITokenService
    {
        public readonly IOptions<IdentityServerSettings> identityServerSettings;
        public readonly DiscoveryDocumentResponse discoveryDocument;
        private readonly HttpClient _httpClient;
        public TokenService(IOptions<IdentityServerSettings> identityServerSettings)
        {
            this.identityServerSettings = identityServerSettings;
            _httpClient = new HttpClient();
            discoveryDocument = _httpClient.GetDiscoveryDocumentAsync(
                this.identityServerSettings.Value.DiscoveryUrl).Result;

            if(discoveryDocument.IsError)
            {
                throw new Exception("discovery document error", discoveryDocument.Exception);
            }
        }
        public async Task<TokenResponse> GetToken(string scope)
        {
            var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = discoveryDocument.TokenEndpoint,
                    ClientId = identityServerSettings.Value.ClientName,
                    ClientSecret = identityServerSettings.Value.ClientPassword,
                    Scope = scope
                });

            if (tokenResponse.IsError)
                throw new Exception("Unable to get token", tokenResponse.Exception);

            return tokenResponse;
        }
    }
}
