using Laul.WebUI.Models.PlaylistSong;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Laul.WebUI.Controllers
{
    public class PlaylistSongController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public PlaylistSongController(IConfiguration config)
        {
            _httpClient = new HttpClient();
            _config = config;
        }

        public async Task<IActionResult> AddSongToPlaylist(long songId, long playlistId)
        {
            var model = new PlaylistSongInputDto()
            {
                PlaylistId = playlistId,
                SongId = songId
            };
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_config["apiUrl"]}/PlaylistSong", model);
            if (response.IsSuccessStatusCode)
            {
                return Ok(response);
            }
            else
            {
                return Content("Error occured");
            }
        }
    }
}
