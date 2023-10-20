using MediatR;
using System;


namespace Laul.Application.Services.Songs.Commands.UpdateSong
{
    public class UpdateSongCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
    }
}
