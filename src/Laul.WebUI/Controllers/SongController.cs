using Laul.WebUI.Models.Song;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Laul.WebUI.Common.Inspector;
using System.Security.Claims;
using AutoMapper;
using Laul.Application.Services.Songs.Queries.GetSongByArtist;
using Laul.Application.Services.Songs.Queries.GetSongListByArtistNoAlbum;
using Laul.Application.Services.Songs.Commands.AddSongToAlbum;
using Laul.WebUI.Services.Identity;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using Laul.Application.Services.Songs.Commands.DeleteSongFromAlbum;

namespace Laul.WebUI.Controllers
{
    public class SongController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public SongController(IMediator mediator, IConfiguration configuration, IMapper mapper, ITokenService tokenService)
        {
            _httpClient = new HttpClient();
            _config = configuration;
            _mediator = mediator;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<IActionResult> GetSongListByArtist(string UserName)
        {
            var request = new GetSongListByArtistQuery()
            {
                UserName = UserName,
            };
            var model = await _mediator.Send(request);

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> GetSongListForm(long AlbumId)
        {
            var UserName = HttpContext.User.FindFirstValue("name");
            var request = new GetSongListByArtistNoAlbumQuery()
            {
                UserName = UserName
            };
            var response = await _mediator.Send(request);

            var model = _mapper.Map<SongListFormVm>(response);
            model.AlbumId = AlbumId;

            return PartialView(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddSongToAlbum(List<long> SongsId, long AlbumId)
        {
            var model = new AddSongToAlbumCommand()
            {
                AlbumId = AlbumId,
                SongsId = SongsId
            };
            var response = await _mediator.Send(model);

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteSongFromAlbum(long SongId)
        {
            var model = new DeleteSongFromAlbumCommand()
            {
                SongId = SongId
            };
            var response = await _mediator.Send(model);

            return Ok();
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
                    var tokenResponse = await _tokenService.GetToken("WebAPI.write");
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);

                    HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_config["apiUrl"]}/Song", model);
                        
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetArtistDetails","Profile");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error Creating song. Please try again later.");
                    }
                }
            }
            return View(request);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSong(long SongId)
        {
            var model = new DeleteSongDto()
            {
                Id = SongId
            };
            var tokenResponse = await _tokenService.GetToken("WebAPI.write");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, $"{_config["apiUrl"]}/Song")
            {
                Content = content
            });
            
            if(response.IsSuccessStatusCode)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
