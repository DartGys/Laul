using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Laul.Application.Services.Playlists.Queries.GetPlaylistList;
using Laul.Application.Services.Playlists.Queries.GetPlaylistDetails;
using Laul.WebUI.Models.Playlist;

namespace Laul.WebUI.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly IMediator _mediator;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;


        public PlaylistController(IMediator mediator, IConfiguration config)
        {
            _mediator = mediator;
            _httpClient = new HttpClient();
            _config = config;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPlaylistList()
        {
            var UserName = HttpContext.User.FindFirstValue("name");
            var reqeust = new GetPlaylistListQuery()
            {
                UserName = UserName,
            };
            var model = await _mediator.Send(reqeust);

            return View(model);
        }

        public async Task<IActionResult> GetPlaylistDetails(long Id)
        {
            var request = new GetPlaylistDetailsQuery()
            {
                Id = Id
            };
            var model = await _mediator.Send(request);

            return View(model);
        }

        public async Task<IActionResult> AddSongToPlaylist(long id)
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult CreatePlaylist()
        {
            var model = new CreatePlaylistDto()
            {
                UserName = HttpContext.User.FindFirstValue("name"),
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePlaylist(CreatePlaylistDto model)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_config["apiUrl"]}/Playlist", model);
                if (response.IsSuccessStatusCode)
                {
                    RedirectToAction("GetPlaylistList");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error. Please try again later.");
                }
            }
            return View(model);
        }
    }
}
