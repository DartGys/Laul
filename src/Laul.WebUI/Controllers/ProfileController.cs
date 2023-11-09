using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Laul.WebUI.Services.Identity;
using System.Security.Claims;
using MediatR;
using Laul.Application.Services.Artists.Queries.GetArtistDetails;

namespace Laul.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetArtist()
        {
            var userName = HttpContext.User.FindFirstValue("name");
            var command = new GetArtistDetailsQuery() { name = userName };
            var result = await _mediator.Send(command);
            return View();
        }
    }
}
