using MediatR;
using Microsoft.AspNetCore.Http;

namespace Laul.Application.Services.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommand : IRequest<long>
    {
        public Guid ArtistId { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
