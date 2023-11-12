using Laul.WebUI.Models.Song;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Laul.WebUI.Common.Inspector;

namespace Laul.WebUI.Controllers
{
    public class SongController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly IMediator _mediator;

        public SongController(IMediator mediator, IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _config = configuration;
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult CreateSong(Guid ArtistId)
        {
            var model = new CreateSongDto()
            {
                ArtistId = ArtistId,
                PublishDate = DateTime.Now,
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateSong(CreateSongDto request)
        {
            if(ModelState.IsValid)
            {
                if(Inspector.IsImage(request.Photo) && Inspector.IsAudio(request.Song))
                {
                    byte[] photoBytes, songBytes;

                    using (var photoStream = new MemoryStream())
                    {
                        await request.Photo.CopyToAsync(photoStream);
                        photoBytes = photoStream.ToArray();
                    }

                    using (var songStream = new MemoryStream())
                    {
                        await request.Song.CopyToAsync(songStream);
                        songBytes = songStream.ToArray();
                    }

                    var model = new CreateSongDtoInput()
                    {
                        PublishDate = request.PublishDate,
                        ArtistId = request.ArtistId,
                        Genre = request.Genre,
                        Photo = photoBytes,
                        Storage = songBytes,
                        Title = request.Title,
                    };

                    HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_config["apiUrl"]}/Song", model);
                        
                    if (response.IsSuccessStatusCode)
                    {
                        // Обробка успішного відгуку від API (наприклад, редірект)
                        return RedirectToAction("GetArtistDetails","Profile");
                    }
                    else
                    {
                        // Обробка помилки від API (наприклад, відображення повідомлення про помилку)
                        ModelState.AddModelError(string.Empty, "Error updating profile. Please try again later.");
                    }
                }
            }
            return View(request);
        }
    }
}
