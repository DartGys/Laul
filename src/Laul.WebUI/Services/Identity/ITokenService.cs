using IdentityModel.Client;

namespace Laul.WebUI.Services.Identity
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}
