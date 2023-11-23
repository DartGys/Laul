using Laul.WebUI.Models.ListeningStat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Laul.WebUI.Controllers
{
    [Authorize]
    public class ListeningStatController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public ListeningStatController(IConfiguration config)
        {
            _config = config;
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> CreateListeningStat(string ArtistName, long SongId)
        {
            var model = new ListeningStatDto()
            {
                ArtistName = ArtistName,
                SongId = SongId
            };

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
