using System;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Laul.Application.Services.Songs.Commands.CreateSong
{
    public class CreateSongCommand : IRequest<long>
    {
        public Guid ArtistId { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public byte[] Photo { get; set; }
        public byte[] Storage { get; set; }
        public string Genre { get; set; }
        public long AlbumId { get; set; }
    }
}
