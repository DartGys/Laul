using Microsoft.AspNetCore.Mvc;
using Laul.WebUI.Models.LikeDislike;
using Newtonsoft.Json;
using System.Text;
using Laul.Application.Services.LikeDislikes.Queries.GetLikeDislike;
using MediatR;

namespace Laul.WebUI.Controllers
{
    public class LikeDislikeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly IMediator _mediator;

        public LikeDislikeController(IConfiguration config, IMediator mediator)
        {
            _config = config;
            _httpClient = new HttpClient();
            _mediator = mediator;
        }

        public async Task<IActionResult> CreateLikeDislike(string ArtistName, long SongId, bool isLike)
        {
            var model = new AddLikeDislikeDto()
            {
                ArtistName = ArtistName,
                SongId = SongId,
                IsLike = isLike
            };
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_config["apiUrl"]}/LikeDislike", model);

            if(response.IsSuccessStatusCode)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> DeleteLikeDislike(string ArtistName, long SongId)
        {
            var model = new DeleteLikeDislikeDto()
            {
                ArtistName = ArtistName,
                SongId = SongId
            };
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, $"{_config["apiUrl"]}/LikeDislike")
            {
                Content = content
            });


            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> UpdateLikeDislike(string ArtistName, long SongId)
        {
            var model = new UpdateLikeDislikeDto()
            {
                ArtistName = ArtistName,
                SongId = SongId
            };
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PatchAsync($"{_config["apiUrl"]}/LikeDislike", content);

            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> GetLikeDislike(string ArtistName, long SongId)
        {
            var request = new GetLikeDislikeQuery()
            {
                ArtistName = ArtistName,
                SongId = SongId
            };
            var model = await _mediator.Send(request);

            return Json(model);
        }
    }
}
