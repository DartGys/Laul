﻿using MediatR;

namespace Laul.Application.Services.Artists.Queries.GetArtistDetails
{
    public class GetArtistDetailsQuery : IRequest<ArtistDetilsVm>
    {
        public string Name { get; set; }
    }
}
