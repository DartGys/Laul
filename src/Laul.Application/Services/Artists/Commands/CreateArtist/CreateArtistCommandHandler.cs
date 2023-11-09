using Laul.Application.Interfaces.BlobStorage;
using Laul.Application.Interfaces.Persistance;
using Laul.Domain.Entities;
using MediatR;

namespace Laul.Application.Services.Artists.Commands.CreateArtist
{
    class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlobStorageContext _blobStorageContext;

        public CreateArtistCommandHandler(IUnitOfWork unitOfWork ,IBlobStorageContext blobStorageContext)
        {
            _unitOfWork = unitOfWork;
            _blobStorageContext = blobStorageContext;
        }

        public async Task<Guid> Handle(CreateArtistCommand command, CancellationToken cancellationToken)
        {
            string photoToken = command.Photo != null ? await _blobStorageContext.UploadAsync.UploadFileAsync(command.Photo, command.Name) : null;

            var artist = new Artist()
            {
                Id = command.Id,
                Name = command.Name,
                Description = command.Description,
                Photo = photoToken,
            };

            await _unitOfWork.Artist.AddAsync(artist, cancellationToken);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return artist.Id;
        }
    }
}
