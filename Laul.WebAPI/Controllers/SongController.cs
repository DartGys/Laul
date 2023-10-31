using Microsoft.AspNetCore.Mvc;
using Laul.Application.Services.Songs.Commands.CreateSong;
using MediatR;

namespace Laul.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SongController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost(Name = "CreateSong")]
        public async Task<IActionResult> CreateSong(CreateSongCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
