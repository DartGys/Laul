using Laul.Application.Services.ListeningStats.Command.CreateListeningStat;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Laul.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ListeningStatController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ListeningStatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateListeningStat(CreateListeningStatCommand command) =>
            Ok(await _mediator.Send(command));
    }
}
