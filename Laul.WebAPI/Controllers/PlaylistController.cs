using Laul.Application.Services.Playlists.Commands.CreatePlaylist;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost(Name="PlaylistCreate")]
        public async Task<IActionResult> CreatePlaylist(CreatePlaylistCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
