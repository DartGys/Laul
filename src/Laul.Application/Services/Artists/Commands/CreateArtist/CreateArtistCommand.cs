﻿using MediatR;
using Microsoft.AspNetCore.Http;

namespace Laul.Application.Services.Artists.Commands.CreateArtist
{
    public class CreateArtistCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Photo { get; set; }
    }
}
