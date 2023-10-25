using MediatR;

namespace Laul.Application.Services.Albums.Commands.DeleteAlbum
{
    public class DeleteAlbumCommand : IRequest<Unit>
    {
        public ulong Id { get; set; }
        public Guid ArtistId { get; set; }
    }
}
