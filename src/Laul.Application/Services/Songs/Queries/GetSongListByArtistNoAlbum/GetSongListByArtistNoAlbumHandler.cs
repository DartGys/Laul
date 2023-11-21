using AutoMapper;
using Laul.Application.Interfaces.Persistance;
using Laul.Application.Common.Exeption;
using MediatR;
using AutoMapper.QueryableExtensions;

namespace Laul.Application.Services.Songs.Queries.GetSongListByArtistNoAlbum
{
    public class GetSongListByArtistNoAlbumHandler : IRequestHandler<GetSongListByArtistNoAlbumQuery, SongListByArtistNoAlbumVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSongListByArtistNoAlbumHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SongListByArtistNoAlbumVm> Handle(GetSongListByArtistNoAlbumQuery request, CancellationToken cancellationToken)
        {
            var artist = (await _unitOfWork.Artist.FindAsyncNoTracking(a => a.Name == request.UserName, cancellationToken))
                .FirstOrDefault();

            if(artist == null && artist.Name != request.UserName)
            {
                throw new NotFoundExeption(nameof(artist), artist.Id);
            }

            var songs = (await _unitOfWork.Song.FindAsyncNoTracking(s => s.ArtistId == artist.Id && s.Album == null, cancellationToken, a => a.Album))
                .AsQueryable()  
                .ProjectTo<SongLookupDto>(_mapper.ConfigurationProvider)
                .ToList();

            return new SongListByArtistNoAlbumVm { Songs = songs };
        }
    }
}
