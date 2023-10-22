using Laul.Application.Interfaces.Persistance;
using Laul.Domain.Entities;
using MediatR;
using System.Security.Cryptography.X509Certificates;

namespace Laul.Application.Services.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateAlbumCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateAlbumCommand command, CancellationToken cancellationToken)
        {
            var album = new Album()
            {
                Title = command.Title,
                Image = command.Image,
                PublishDate = command.PublishDate,
                Genre = command.Genre,
                ArtistId = command.ArtisId,
            };

            await _unitOfWork.Album.AddAsync(album);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return album.Id;
        }
    }
}
