using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Text;
using Laul.WebUI.Models.Artist;
using MediatR;
using Laul.Application.Services.Artists.Queries.GetArtistDetails;

namespace Laul.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator, IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _config = configuration;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetArtistDetails(string UserName)
        {
            if(string.IsNullOrEmpty(UserName))
            {
                UserName = HttpContext.User.FindFirstValue("name");
            }
            var reqeust = new GetArtistDetailsQuery()
            {
                Name = UserName
            };
            var model = await _mediator.Send(reqeust);
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult EditArtist(Guid id)
        {
            var model = new ArtistUpdateDto()
            {
                Id = id
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditArtist(ArtistUpdateDto request)
        {
            if(ModelState.IsValid)
            {
                byte[] PhotoInBytes = null;
                if (request.Photo != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await request.Photo.CopyToAsync(memoryStream);
                        PhotoInBytes = memoryStream.ToArray();
                    }
                }
                var model = new ArtistUpdateOutputDto()
                {
                    Id = request.Id,
                    Description = request.Description,
                    Name = request.Name,
                    Photo = PhotoInBytes
                };
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PatchAsync($"{_config["apiUrl"]}/Artist", content);

                if (response.IsSuccessStatusCode)
                {
                    // Обробка успішного відгуку від API (наприклад, редірект)
                    return RedirectToAction("GetArtistDetails");
                }
                else
                {
                    // Обробка помилки від API (наприклад, відображення повідомлення про помилку)
                    ModelState.AddModelError(string.Empty, "Error updating profile. Please try again later.");
                }
            }
            return View(request);
        }
    }
}
