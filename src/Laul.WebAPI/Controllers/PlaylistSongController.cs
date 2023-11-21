using Laul.Application.Services.PlaylistSongs.Commands.AddPlaylistSong;
using Laul.Application.Services.PlaylistSongs.Commands.RemovePlaylistSong;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Laul.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlaylistSongController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlaylistSongController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddPlaylistSong([FromBody]AddPlaylistSongCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> RemovePlaylistSong(RemovePlaylistSongCommand command) =>
            Ok(await _mediator.Send(command));
    }
}
