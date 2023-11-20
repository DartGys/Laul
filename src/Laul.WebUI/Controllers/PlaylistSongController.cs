using Laul.WebUI.Models.PlaylistSong;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

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

        public async Task<IActionResult> RemoveSongFromPlaylist(long songId, long playlistId)
        {
            var model = new PlaylistSongInputDto()
            {
                PlaylistId = playlistId,
                SongId = songId
            };
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, $"{_config["apiUrl"]}/PlaylistSong")
            {
                Content = content
            });

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetPlaylistDetails", "Playlist", new { Id = playlistId });
            }
            else
            {
                return Content("Error occured");
            }
        }
    }
}
