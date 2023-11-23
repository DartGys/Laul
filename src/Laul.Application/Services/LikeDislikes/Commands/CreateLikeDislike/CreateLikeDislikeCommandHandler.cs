using Laul.Application.Interfaces.Persistance;
using Laul.Domain.Entities;
using MediatR;

namespace Laul.Application.Services.LikeDislikes.Commands.CreateLikeDislike
{
    public class CreateLikeDislikeCommandHandler : IRequestHandler<CreateLikeDislikeCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateLikeDislikeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateLikeDislikeCommand command, CancellationToken cancellationToken)
        {
            var artist = (await _unitOfWork.Artist.FindAsyncNoTracking(a => a.Name == command.ArtistName, cancellationToken)).FirstOrDefault();

            var likeDislike = new LikeDislike()
            {
                ActionDate = DateTime.UtcNow,
                IsLike = command.IsLike,
                SongId = command.SongId,
                ArtistId = artist.Id,
            };

            await _unitOfWork.LikeDislike.AddAsync(likeDislike, cancellationToken);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return likeDislike.ArtistId;
        }
    }
}
