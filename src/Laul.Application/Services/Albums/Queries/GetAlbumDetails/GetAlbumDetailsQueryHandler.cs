using AutoMapper;
using AutoMapper.QueryableExtensions;
using Laul.Application.Common.Exeption;
using Laul.Application.Interfaces.BlobStorage;
using Laul.Application.Interfaces.Persistance;
using Laul.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Laul.Application.Services.Albums.Queries.GetAlbumDetails
{
    public class GetAlbumDetailsQueryHandler : IRequestHandler<GetAlbumDetailsQuery, AlbumDetailsVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAlbumDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AlbumDetailsVm> Handle(GetAlbumDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Album.GetById(request.Id, cancellationToken);

            if (entity == null || entity.ArtistId != request.ArtistId)
            {
                throw new NotFoundExeption(nameof(Song), entity.Id);
            }

            var artist = await _unitOfWork.Artist.GetById(request.ArtistId, cancellationToken);
            var songs = await _unitOfWork.Song.FindAsyncNoTracking(s => s.AlbumId == request.Id, cancellationToken);

            var album = (await _unitOfWork.Album.FindAsyncNoTracking(a => a.Id == request.Id, cancellationToken))
                .AsQueryable()
                .Include(artist.Name)
                .ProjectTo<AlbumDetailsVm>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            var AlbumDetailsVm = _mapper.Map<AlbumDetailsVm>(album);
            

            return _mapper.Map<AlbumDetailsVm>(album);
        }
    }
}
