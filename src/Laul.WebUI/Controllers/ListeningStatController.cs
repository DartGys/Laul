using Laul.Application.Services.ListeningStats.Queries.GetListeningStatCount;
using Laul.WebUI.Models.ListeningStat;
using Laul.WebUI.Services.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Laul.WebUI.Controllers
{
    
    public class ListeningStatController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;
        private readonly IMediator _mediator;

        public ListeningStatController(IConfiguration config, ITokenService tokenService, IMediator mediator)
        {
            _config = config;
            _httpClient = new HttpClient();
            _tokenService = tokenService;
            _mediator = mediator;
        }

        [Authorize]
        public async Task<IActionResult> CreateListeningStat(string ArtistName, long SongId)
        {
            var model = new ListeningStatDto()
            {
                ArtistName = ArtistName,
                SongId = SongId
            };
            var tokenResponse = await _tokenService.GetToken("WebAPI.write");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_config["apiUrl"]}/ListeningStat", model);

            if(response.IsSuccessStatusCode)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> GetListeningStatCount(Guid ArtistId)
        {
            var request = new GetListeningStatCountQuery() 
            { 
                ArtistId = ArtistId 
            };
            var model = await _mediator.Send(request);

            return Ok(model);
        }
    }
}
