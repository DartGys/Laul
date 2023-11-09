using Laul.Application.Services.Artists.Commands.CreateArtist;
using Laul.Application.Services.Artists.Commands.DeleteArtist;
using Laul.Application.Services.Artists.Commands.UpdateArtist;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Laul.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ArtistController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtist([FromBody]CreateArtistCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> DeleteArtist(DeleteArtistCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpPatch]
        public async Task<IActionResult> UpdateArtist(UpdateArtistCommand command) =>
            Ok(await _mediator.Send(command));
    }
}
