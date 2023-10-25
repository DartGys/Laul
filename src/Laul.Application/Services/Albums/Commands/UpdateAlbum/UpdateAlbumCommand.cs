using MediatR;
using Microsoft.AspNetCore.Http;

namespace Laul.Application.Services.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public IFormFile Image { get; set; }
    }
}
