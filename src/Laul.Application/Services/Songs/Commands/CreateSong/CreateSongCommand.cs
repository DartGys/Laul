using System;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Laul.Application.Services.Songs.Commands.CreateSong
{
    public class CreateSongCommand : IRequest<ulong>
    {
        public Guid ArtistId { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public IFormFile Photo { get; set; }
        public IFormFile Storage { get; set; }
        public string Genre { get; set; }
        public ulong AlbumId { get; set; }
    }
}
