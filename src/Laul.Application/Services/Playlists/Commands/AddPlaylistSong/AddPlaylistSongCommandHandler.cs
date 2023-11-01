using Laul.Application.Interfaces.Persistance;
using Laul.Application.Common.Exeption;
using Laul.Domain.Entities;
using MediatR;

namespace Laul.Application.Services.Playlists.Commands.AddPlaylistSong
{
    public class AddPlaylistSongCommandHandler : IRequestHandler<AddPlaylistSongCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddPlaylistSongCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(AddPlaylistSongCommand command, CancellationToken cancellationToken)
        {
            var playlist = await _unitOfWork.Playlist.GetById(command.PlaylistId);
            var song = await _unitOfWork.Song.GetById(command.SongId);
            
            if(song == null || playlist == null)
            {
                throw new NotFoundExeption(nameof(PlaylistSong), "No song or playlist");
            }

            var playlistSong = new PlaylistSong()
            {
                SongId = command.SongId,
                PlaylistId = playlist.Id,
            };

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return playlistSong.PlaylistId;
        }
    }
}
