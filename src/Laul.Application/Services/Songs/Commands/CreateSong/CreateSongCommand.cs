using System;
using MediatR;

namespace Laul.Application.Services.Songs.Commands.CreateSong
{
    public class CreateSongCommand : IRequest<int>
    {
        public Guid ArtistId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public int AlbumId { get; set; }
    }
}
