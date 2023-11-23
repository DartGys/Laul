using Laul.Application.Services.Albums.Queries.GetAlbumDetails;
using Laul.Application.Services.Albums.Queries.GetAlbumListByArtist;
using Laul.WebUI.Common.Inspector;
using Laul.WebUI.Models.Album;
using Laul.WebUI.Services.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Laul.WebUI.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IMediator _mediator;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;

        public AlbumController(IConfiguration config, IMediator mediator, ITokenService tokenService)
        {
            _config = config;
            _mediator = mediator;
            _httpClient = new HttpClient();
            _tokenService = tokenService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult CreateAlbum(Guid ArtistId)
        {
            var request = new CreateAlbumDto()
            {
                ArtistId = ArtistId,
                PublishDate = DateTime.UtcNow
            };

            return View(request);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAlbum(CreateAlbumDto request)
        {
            if(ModelState.IsValid)
            {
                byte[] ImageInBytes = null;
                if (request.Image != null)
                {   
                    if(Inspector.IsImage(request.Image))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await request.Image.CopyToAsync(memoryStream);
                            ImageInBytes = memoryStream.ToArray();
                        }
                    }
                }
                var model = new CreateAlbumInputDto()
                {
                    ArtistId = request.ArtistId,
                    Genre = request.Genre,
                    Image = ImageInBytes,
                    PublishDate = request.PublishDate,
                    Title = request.Title,
                };

                var tokenResponse = await _tokenService.GetToken("WebAPI.write");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);

                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_config["apiUrl"]}/Album", model);

                if (response.IsSuccessStatusCode)
                {
                    RedirectToAction("GetArtistDetails", "Profile");
                }
                else
                {
                    return BadRequest(response.Content);
                }
            }

            return View(request);

        }

        public async Task<IActionResult> GetAlbumListByArtist(string UserName)
        {
            var request = new GetAlbumListByArtistQuery()
            {
                UserName = UserName
            };
            var model = await _mediator.Send(request);

            return View(model);
        }

        public async Task<IActionResult> GetAlbumDetails(long AlbumId, Guid ArtistId)
        {
            var request = new GetAlbumDetailsQuery()
            {
                Id = AlbumId,
                ArtistId = ArtistId
            };
            var model = await _mediator.Send(request);

            return View(model);
        }
    }
}
