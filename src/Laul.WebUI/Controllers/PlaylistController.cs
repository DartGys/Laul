using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Laul.Application.Services.Playlists.Queries.GetPlaylistList;
using Laul.Application.Services.Playlists.Queries.GetPlaylistDetails;
using Laul.WebUI.Models.Playlist;
using AutoMapper;

namespace Laul.WebUI.Controllers
{
    [Authorize]
    public class PlaylistController : Controller
    {
        private readonly IMediator _mediator;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;


        public PlaylistController(IMediator mediator, IConfiguration config, IMapper mapper)
        {
            _mediator = mediator;
            _httpClient = new HttpClient();
            _config = config;
            _mapper = mapper;
        }

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> GetPlaylistListForm(long SongId)
        {
            var UserName = HttpContext.User.FindFirstValue("name");
            var request = new GetPlaylistListQuery()
            {
                UserName = UserName,
            };
            var response = await _mediator.Send(request);

            var model = _mapper.Map<PlaylistListFormVm>(response);
            model.SongId = SongId;

            return PartialView(model);
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

        [HttpGet]
        public IActionResult CreatePlaylist()
        {
            var model = new CreatePlaylistDto()
            {
                UserName = HttpContext.User.FindFirstValue("name"),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlaylist(CreatePlaylistDto model)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_config["apiUrl"]}/Playlist", model);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetPlaylistList");
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
