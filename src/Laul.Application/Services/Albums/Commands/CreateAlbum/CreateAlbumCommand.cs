using MediatR;

namespace Laul.Application.Services.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommand : IRequest<int>
    {
        public Guid ArtisId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
