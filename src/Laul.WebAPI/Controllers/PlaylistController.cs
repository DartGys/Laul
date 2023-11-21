using Laul.Application.Services.Playlists.Commands.CreatePlaylist;
using Laul.Application.Services.Playlists.Commands.DeletePlaylist;
using Laul.Application.Services.Playlists.Commands.UpdatePlaylist;
using Laul.Application.Services.Playlists.Queries.GetPlaylistList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Laul.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlaylistController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlaylist(CreatePlaylistCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpPatch]
        public async Task<IActionResult> UpdatePlaylist(UpdatePlaylistCommand command) => 
            Ok(await _mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> DeletePlaylist(DeletePlaylistCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpGet]
        public async Task<IActionResult> GetPlaylistList([FromBody]GetPlaylistListQuery request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
