using Laul.Application.Services.Albums.Commands.CreateAlbum;
using Laul.Application.Services.Albums.Commands.DeleteAlbum;
using Laul.Application.Services.Albums.Commands.UpdateAlbum;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Laul.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AlbumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlbum(CreateAlbumCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> DeleteAlbum(DeleteAlbumCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpPatch]
        public async Task<IActionResult> UpdateAlbum(UpdateAlbumCommand command) =>
            Ok(await _mediator.Send(command));
    }
}
