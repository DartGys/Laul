using Laul.Application.Services.Playlists.Commands.AddPlaylistSong;
using Laul.Application.Services.Playlists.Commands.CreatePlaylist;
using Laul.Application.Services.Playlists.Commands.DeletePlaylist;
using Laul.Application.Services.Playlists.Commands.RemovePlaylistSong;
using Laul.Application.Services.Playlists.Commands.UpdatePlaylist;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Laul.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
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
    }
}
