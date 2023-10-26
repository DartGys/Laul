using Laul.Application.Interfaces.Persistance;
using Laul.Domain.Entities;
using MediatR;
using Laul.Application.Common.Exeption;

namespace Laul.Application.Services.Playlists.Commands.UpdatePlaylist
{
    public class UpdatePlaylistCommandHandler : IRequestHandler<UpdatePlaylistCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePlaylistCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdatePlaylistCommand command, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Playlist.GetById(command.Id, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundExeption(nameof(Playlist), command.Id);
            }

            entity.Title = command.Title;
            entity.Description = command.Description;

            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
