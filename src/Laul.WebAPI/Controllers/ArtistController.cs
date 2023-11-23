using Laul.Application.Services.Artists.Commands.CreateArtist;
using Laul.Application.Services.Artists.Commands.DeleteArtist;
using Laul.Application.Services.Artists.Commands.UpdateArtist;
using Laul.Application.Services.Artists.Queries.GetArtistDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Laul.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<IActionResult> DeleteArtist([FromBody]DeleteArtistCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpPatch]
        public async Task<IActionResult> UpdateArtist([FromBody]UpdateArtistCommand command) =>
            Ok(await _mediator.Send(command));
    }
}
