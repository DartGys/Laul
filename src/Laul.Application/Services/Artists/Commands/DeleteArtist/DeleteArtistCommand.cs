using MediatR;

namespace Laul.Application.Services.Artists.Commands.DeleteArtist
{
    public class DeleteArtistCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
