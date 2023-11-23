using Laul.WebUI.Models.ListeningStat;
using Laul.WebUI.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Laul.WebUI.Controllers
{
    [Authorize]
    public class ListeningStatController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;

        public ListeningStatController(IConfiguration config, ITokenService tokenService)
        {
            _config = config;
            _httpClient = new HttpClient();
            _tokenService = tokenService;
        }

        public async Task<IActionResult> CreateListeningStat(string ArtistName, long SongId)
        {
            var model = new ListeningStatDto()
            {
                ArtistName = ArtistName,
                SongId = SongId
            };
            var tokenResponse = await _tokenService.GetToken("WebAPI.write");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_config["apiUrl"]}/ListeningStat", model);

            if(response.IsSuccessStatusCode)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
