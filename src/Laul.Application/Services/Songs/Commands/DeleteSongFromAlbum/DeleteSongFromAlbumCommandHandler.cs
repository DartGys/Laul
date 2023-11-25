using Laul.Application.Interfaces.Persistance;
using Laul.Application.Common.Exeption;
using MediatR;

namespace Laul.Application.Services.Songs.Commands.DeleteSongFromAlbum
{
    public class DeleteSongFromAlbumCommandHandler : IRequestHandler<DeleteSongFromAlbumCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSongFromAlbumCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteSongFromAlbumCommand command, CancellationToken cancellationToken)
        {
            var song = (await _unitOfWork.Song.FindAsync(s => s.Id == command.SongId, cancellationToken, s => s.Album)).FirstOrDefault();

            if (song == null)
            {
                throw new NotFoundExeption(nameof(song), command.SongId);
            }

            song.Album = null;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
