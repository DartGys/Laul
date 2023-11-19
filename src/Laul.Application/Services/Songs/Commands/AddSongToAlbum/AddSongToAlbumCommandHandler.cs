using Laul.Application.Interfaces.Persistance;
using Laul.Application.Common.Exeption;
using MediatR;

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
            var song = await _unitOfWork.Song.GetById(command.SongId, cancellationToken);
            var album = await _unitOfWork.Album.GetById(command.AlbumId, cancellationToken);

            if(song == null || album == null)
            {
                throw new NotFoundExeption(nameof(song), command.SongId);
            }

            song.AlbumId = album.Id;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
