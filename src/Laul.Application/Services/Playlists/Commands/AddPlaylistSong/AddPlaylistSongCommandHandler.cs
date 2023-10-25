using Laul.Application.Interfaces.Persistance;
using MediatR;

namespace Laul.Application.Services.Playlists.Commands.AddPlaylistSong
{
    public class AddPlaylistSongCommandHandler : IRequestHandler<AddPlaylistSongCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddPlaylistSongCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AddPlaylistSongCommand command, CancellationToken cancellationToken)
        {
            var playlist = await _unitOfWork.Playlist.GetById(command.PlaylistId);
            //var song = await _unitOfWork.Song.GetById(command)

            return 1;
        }
    }
}
