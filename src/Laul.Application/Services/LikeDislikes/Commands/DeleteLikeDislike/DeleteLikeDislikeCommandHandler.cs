using Laul.Application.Interfaces.Persistance;
using Laul.Domain.Entities;
using MediatR;

namespace Laul.Application.Services.LikeDislikes.Commands.DeleteLikeDislike
{
    public class DeleteLikeDislikeCommandHandler : IRequestHandler<DeleteLikeDislikeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLikeDislikeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteLikeDislikeCommand command, CancellationToken cancellationToken)
        {
            var artist = (await _unitOfWork.Artist.FindAsyncNoTracking(a => a.Name == command.ArtistName, cancellationToken)).FirstOrDefault();

            var entity = new LikeDislike()
            {
                ArtistId = artist.Id,
                SongId = command.SongId,
            };

            _unitOfWork.LikeDislike.Remove(entity);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
