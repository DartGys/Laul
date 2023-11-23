using Microsoft.AspNetCore.Mvc;
using Laul.Application.Services.Songs.Commands.CreateSong;
using MediatR;
using Laul.Application.Services.Songs.Commands.DeleteSong;
using Laul.Application.Services.Songs.Commands.UpdateSong;
using Laul.Application.Services.Songs.Commands.AddSongToAlbum;
using Microsoft.AspNetCore.Authorization;

namespace Laul.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class SongController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SongController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSong(CreateSongCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> DeleteSong(DeleteSongCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpPatch]
        public async Task<IActionResult> UpdateSong(UpdateSongCommand command) =>
            Ok(await _mediator.Send(command));
    }
}
