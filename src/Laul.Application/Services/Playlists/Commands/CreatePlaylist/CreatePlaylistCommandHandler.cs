using Laul.Application.Interfaces.Persistance;
using Laul.Domain.Entities;
using MediatR;

namespace Laul.Application.Services.Playlists.Commands.CreatePlaylist
{
    public class CreatePlaylistCommandHandler : IRequestHandler<CreatePlaylistCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePlaylistCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreatePlaylistCommand command, CancellationToken cancellationToken)
        {
            var Playlist = new Playlist()
            {
                Title = command.Title,
                Description = command.Description,
                UserId = command.UserId,
            };

            await _unitOfWork.Playlist.AddAsync(Playlist,cancellationToken);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return Playlist.Id;
        }
    }
}
