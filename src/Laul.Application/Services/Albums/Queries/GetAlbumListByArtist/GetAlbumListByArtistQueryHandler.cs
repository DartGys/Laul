using Laul.Application.Interfaces.Persistance;
using Laul.Application.Common.Exeption;
using MediatR;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace Laul.Application.Services.Albums.Queries.GetAlbumListByArtist
{
    public class GetAlbumListByArtistQueryHandler : IRequestHandler<GetAlbumListByArtistQuery, AlbumListVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAlbumListByArtistQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AlbumListVm> Handle(GetAlbumListByArtistQuery request, CancellationToken cancellationToken)
        {
            var artist = (await _unitOfWork.Artist.FindAsyncNoTracking(a => a.Name == request.UserName, cancellationToken)).FirstOrDefault();

            if (artist == null && artist.Name != request.UserName)
            {
                throw new NotFoundExeption(nameof(artist), request.UserName);
            }

            var albumList = (await _unitOfWork.Album.FindAsyncNoTracking(a => a.ArtistId == artist.Id, cancellationToken))
                .AsQueryable()
                .ProjectTo<AlbumLookupDto>(_mapper.ConfigurationProvider)
                .ToList();

            return new AlbumListVm { Albums = albumList, ArtistId = artist.Id };
        }
    }
}
