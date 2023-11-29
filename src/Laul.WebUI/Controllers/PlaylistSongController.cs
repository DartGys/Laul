using Laul.WebUI.Models.PlaylistSong;
using Laul.WebUI.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Laul.WebUI.Controllers
{
    [Authorize]
    public class PlaylistSongController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;

        public PlaylistSongController(IConfiguration config, ITokenService tokenService)
        {
            _httpClient = new HttpClient();
            _config = config;
            _tokenService = tokenService;
        }

        public async Task<IActionResult> AddSongToPlaylist(long songId, long playlistId)
        {
            var model = new PlaylistSongInputDto()
            {
                PlaylistId = playlistId,
                SongId = songId
            };
            var tokenResponse = await _tokenService.GetToken("WebAPI.write");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_config["apiUrl"]}/PlaylistSong", model);
            if (response.IsSuccessStatusCode)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("Error occured");
            }
        }

        public async Task<IActionResult> RemoveSongFromPlaylist(long songId, long playlistId)
        {
            var model = new PlaylistSongInputDto()
            {
                PlaylistId = playlistId,
                SongId = songId
            };
            var tokenResponse = await _tokenService.GetToken("WebAPI.write");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);

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
