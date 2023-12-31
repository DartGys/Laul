﻿using Microsoft.AspNetCore.Mvc;
using Laul.WebUI.Models.LikeDislike;
using Newtonsoft.Json;
using System.Text;
using Laul.Application.Services.LikeDislikes.Queries.GetLikeDislike;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Laul.WebUI.Services.Identity;
using System.Net.Http.Headers;

namespace Laul.WebUI.Controllers
{
    [Authorize]
    public class LikeDislikeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly IMediator _mediator;
        private readonly ITokenService _tokenService;

        public LikeDislikeController(IConfiguration config, IMediator mediator, ITokenService tokenService)
        {
            _config = config;
            _httpClient = new HttpClient();
            _mediator = mediator;
            _tokenService = tokenService;
        }

        public async Task<IActionResult> CreateLikeDislike(string ArtistName, long SongId, bool isLike)
        {
            var model = new AddLikeDislikeDto()
            {
                ArtistName = ArtistName,
                SongId = SongId,
                IsLike = isLike
            };
            var tokenResponse = await _tokenService.GetToken("WebAPI.write");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);

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
            var tokenResponse = await _tokenService.GetToken("WebAPI.write");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);

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
            var tokenResponse = await _tokenService.GetToken("WebAPI.write");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);

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
