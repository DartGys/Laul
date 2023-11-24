using Laul.Application.Interfaces.Persistance;
using Laul.Application.Common.Exeption;
using MediatR;
using Laul.Domain.Entities;
using Laul.Application.Interfaces.BlobStorage;

namespace Laul.Application.Services.Artists.Commands.DeleteArtist
{
    public class DeleteArtistCommandHandler : IRequestHandler<DeleteArtistCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlobStorageContext _blobStorageContext;

        public DeleteArtistCommandHandler(IUnitOfWork unitOfWork ,IBlobStorageContext blobStorageContext)
        {
            _unitOfWork = unitOfWork;
            _blobStorageContext = blobStorageContext;
        }

        public async Task<Unit> Handle(DeleteArtistCommand command, CancellationToken cancellationToken)
        {
            var entity = (await _unitOfWork.Artist.FindAsync(e => e.Id == command.Id, cancellationToken,
                e => e.LikeDislikes, e => e.ListeningStats, e => e.Playlists, e => e.Albums, e => e.Songs)).FirstOrDefault();

            if(entity.ListeningStats != null)
                _unitOfWork.ListeningStats.RemoveRange(entity.ListeningStats);

            if(entity.LikeDislikes != null)
                _unitOfWork.LikeDislike.RemoveRange(entity.LikeDislikes);

            if(entity.Playlists != null)
            {
                foreach (var playlist in entity.Playlists)
                {
                    var playlistSong = (await _unitOfWork.PlaylistSong.FindAsync(p => p.PlaylistId == playlist.Id)).ToList();
                    if (playlistSong != null && playlistSong.Count() > 0)
                        _unitOfWork.PlaylistSong.RemoveRange(playlistSong);
                }

                _unitOfWork.Playlist.RemoveRange(entity.Playlists);
            }

            if (entity.Songs != null)
            {
                _unitOfWork.Song.RemoveRange(entity.Songs);

                foreach(var song in entity.Songs)
                {
                    await _blobStorageContext.DeleteAsync.DeleteFileAsync(song.Photo);
                    await _blobStorageContext.DeleteAsync.DeleteFileAsync(song.Storage);
                }
            }

            if (entity.Albums != null)
                _unitOfWork.Album.RemoveRange(entity.Albums);

            await _blobStorageContext.DeleteAsync.DeleteFileAsync(entity.Photo);

            _unitOfWork.Artist.Remove(entity);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
