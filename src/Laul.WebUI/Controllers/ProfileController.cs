using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Text;
using Laul.WebUI.Models.Artist;
using Laul.WebUI.Common.Interpretator;
using MediatR;
using Laul.Application.Services.Artists.Queries.GetArtistDetails;
using Laul.WebUI.Services.Identity;
using System.Net.Http.Headers;

namespace Laul.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly IMediator _mediator;
        private readonly ITokenService _tokenService;

        public ProfileController(IMediator mediator, IConfiguration configuration, ITokenService tokenService)
        {
            _httpClient = new HttpClient();
            _config = configuration;
            _mediator = mediator;
            _tokenService = tokenService;
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
        public IActionResult EditArtist(Guid id, string Photo)
        {

            var model = new ArtistUpdateDto()
            {
                Id = id,
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
                    Photo = PhotoInBytes
                };
                var tokenResponse = await _tokenService.GetToken("WebAPI.write");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);

                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PatchAsync($"{_config["apiUrl"]}/Artist", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetArtistDetails");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error updating profile. Please try again later.");
                }
            }
            return View(request);
        }
    }
}
