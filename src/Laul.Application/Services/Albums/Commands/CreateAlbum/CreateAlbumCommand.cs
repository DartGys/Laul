﻿using MediatR;
using Microsoft.AspNetCore.Http;

namespace Laul.Application.Services.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommand : IRequest<int>
    {
        public Guid ArtistId { get; set; }
        public string Title { get; set; }
        public IFormFile Image { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
    }
}