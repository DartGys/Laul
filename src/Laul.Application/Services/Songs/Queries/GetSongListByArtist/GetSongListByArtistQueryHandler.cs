using AutoMapper;
using Laul.Application.Interfaces.Persistance;
using Laul.Application.Common.Exeption;
using MediatR;
using AutoMapper.QueryableExtensions;
using Laul.Application.Services.Songs.Queries.GetSongByArtist;

namespace Laul.Application.Services.Songs.Queries.GetSongListByArtist
{
    public class GetSongListByArtistHandler : IRequestHandler<GetSongListByArtistQuery, SongListByArtistVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSongListByArtistHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SongListByArtistVm> Handle(GetSongListByArtistQuery request, CancellationToken cancellationToken)
        {
            var artist = (await _unitOfWork.Artist.FindAsyncNoTracking(a => a.Name == request.UserName, cancellationToken))
                .FirstOrDefault();

            if(artist == null && artist.Name != request.UserName)
            {
                throw new NotFoundExeption(nameof(artist), artist.Id);
            }

            var songs = (await _unitOfWork.Song.FindAsyncNoTracking(s => s.ArtistId == artist.Id, cancellationToken, a => a.Album))
                .AsQueryable()
                .ProjectTo<SongLookupDto>(_mapper.ConfigurationProvider)
                .ToList();

            return new SongListByArtistVm { Songs = songs };
        }
    }
}
