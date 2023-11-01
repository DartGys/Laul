﻿using Laul.Application.Services.Artists.Commands.CreateArtist;
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

        [HttpPost(Name="CreateArist")]
        public async Task<IActionResult> CreateArtist(CreateArtistCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
