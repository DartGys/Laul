using System;
using MediatR;

namespace Laul.Application.Songs.Commands.CreateSong
{
    public class CreateSongCommand : IRequest<Guid>
    {
        public Guid ArtistId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public int AlbumId { get; set; }
    }
}
