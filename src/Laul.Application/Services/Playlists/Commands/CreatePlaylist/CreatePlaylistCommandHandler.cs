using Laul.Application.Interfaces.Persistance;
using Laul.Domain.Entities;
using MediatR;

namespace Laul.Application.Services.Playlists.Commands.CreatePlaylist
{
    public class CreatePlaylistCommandHandler : IRequestHandler<CreatePlaylistCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePlaylistCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreatePlaylistCommand command, CancellationToken cancellationToken)
        {
            var userId = (await _unitOfWork.Artist.FindAsync(u => u.Name == command.UserName)).FirstOrDefault().Id;

            var Playlist = new Playlist()
            {
                Title = command.Title,
                Description = command.Description,
                UserId = userId,
            };

            await _unitOfWork.Playlist.AddAsync(Playlist,cancellationToken);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return Playlist.Id;
        }
    }
}
