using Laul.Application.Interfaces.Persistance;
using Laul.Domain.Entities;
using MediatR;

namespace Laul.Application.Services.Playlists.Commands.DeletePlaylist
{
    public class DeletePlaylistCommandHandler : IRequestHandler<DeletePlaylistCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePlaylistCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeletePlaylistCommand command, CancellationToken cancellationToken)
        {
            var entity = new Playlist() { Id = command.Id };

            var playlistSongs = (await _unitOfWork.PlaylistSong.FindAsync(p => p.PlaylistId == command.Id)).ToList();

            if(playlistSongs != null)
            {
                _unitOfWork.PlaylistSong.RemoveRange(playlistSongs);
            }

            _unitOfWork.Playlist.Remove(entity);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
