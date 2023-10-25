using Laul.Application.Interfaces.Persistance;
using MediatR;
using Laul.Application.Common.Exeption;
using Laul.Domain.Entities;

namespace Laul.Application.Services.LikeDislikes.Commands.UpdateLikeDislike
{
    public class UpdateLikeDislikeCommandHandler : IRequestHandler<UpdateLikeDislikeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLikeDislikeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateLikeDislikeCommand command, CancellationToken cancellationToken)
        {
            var entity = (await _unitOfWork.LikeDislike.FindAsync(e => e.UserId == command.UserId && e.SongId == command.SongId)).FirstOrDefault();

            if (entity == null)
            {
                throw new NotFoundExeption(nameof(LikeDislike), command.UserId);
            }

            entity.IsLike = !entity.IsLike;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
