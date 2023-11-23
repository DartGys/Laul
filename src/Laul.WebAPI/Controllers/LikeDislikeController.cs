using Laul.Application.Services.LikeDislikes.Commands.CreateLikeDislike;
using Laul.Application.Services.LikeDislikes.Commands.DeleteLikeDislike;
using Laul.Application.Services.LikeDislikes.Commands.UpdateLikeDislike;
using Laul.Application.Services.LikeDislikes.Queries.GetLikeDislike;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Laul.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LikeDislikeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LikeDislikeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLikeDislike(CreateLikeDislikeCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpPatch]
        public async Task<IActionResult> UpdateLikeDislike(UpdateLikeDislikeCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> DeleteLikeDislike(DeleteLikeDislikeCommand command) =>
            Ok(await _mediator.Send(command));
    }
}
