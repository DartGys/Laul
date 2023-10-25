using Laul.Application.Common.Exeption;
using Laul.Application.Interfaces.Persistance;
using Laul.Domain.Entities;
using MediatR;

namespace Laul.Application.Services.Playlists.Commands.RemovePlaylistSong
{
    public class RemovePlaylistSongCommandHandler : IRequestHandler<RemovePlaylistSongCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemovePlaylistSongCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemovePlaylistSongCommand command, CancellationToken cancellationToken)
        {
            var playlist = await _unitOfWork.Playlist.GetById(command.PlaylistId);
            var song = await _unitOfWork.Song.GetById(command.SongId);

            if (song == null || playlist == null)
            {
                throw new NotFoundExeption(nameof(PlaylistSong), "No song or playlist");
            }

            var playlistSong = (await _unitOfWork.PlaylistSong.FindAsync(p => p.PlaylistId == command.PlaylistId && p.SongId == command.SongId)).FirstOrDefault();

            _unitOfWork.PlaylistSong.Remove(playlistSong);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
