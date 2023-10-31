using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Laul.WebAPI.Controllers
{
    public class ArtistController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ArtistController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //public async Task<IActionResult> CreateArtist()
    }
}
