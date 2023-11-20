using Laul.Application.Services.Albums.Queries.GetAlbumDetails;
using Laul.Application.Services.Albums.Queries.GetAlbumListByArtist;
using Laul.WebUI.Common.Inspector;
using Laul.WebUI.Models.Album;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace Laul.WebUI.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IMediator _mediator;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public AlbumController(IConfiguration config, IMediator mediator)
        {
            _config = config;
            _httpClient = new HttpClient();
            _mediator = mediator;
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

                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_config["apiUrl"]}/Album", model);

                RedirectToAction("GetArtistDetails", "Profile");
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
