using Laul.Application.Services.LikeDislikes.Commands.CreateLikeDislike;
using Laul.Application.Services.LikeDislikes.Commands.UpdateLikeDislike;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Laul.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LikeDislike : ControllerBase
    {
        private readonly IMediator _mediator;

        public LikeDislike(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLikeDislike(CreateLikeDislikeCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpPatch]
        public async Task<IActionResult> UpdateLikeDislike(UpdateLikeDislikeCommand command) =>
            Ok(await _mediator.Send(command));
    }
}
