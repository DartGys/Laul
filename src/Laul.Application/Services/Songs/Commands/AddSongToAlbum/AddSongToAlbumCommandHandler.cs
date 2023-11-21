using Laul.Application.Interfaces.Persistance;
using Laul.Application.Common.Exeption;
using MediatR;
using Laul.Domain.Entities;

namespace Laul.Application.Services.Songs.Commands.AddSongToAlbum
{
    public class AddSongToAlbumCommandHandler : IRequestHandler<AddSongToAlbumCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddSongToAlbumCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddSongToAlbumCommand command, CancellationToken cancellationToken)
        {
            var songs = new List<Song>();
            foreach(var songId in command.SongsId)
              songs.Add(await _unitOfWork.Song.GetById(songId, cancellationToken));
            var album = await _unitOfWork.Album.GetById(command.AlbumId, cancellationToken);

            if(songs == null || album == null)
            {
                throw new NotFoundExeption(nameof(album), command.AlbumId);
            }

            foreach(var song in songs)
                song.AlbumId = command.AlbumId;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
