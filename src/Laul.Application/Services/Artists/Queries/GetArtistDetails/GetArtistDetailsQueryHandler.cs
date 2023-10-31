using AutoMapper;
using AutoMapper.QueryableExtensions;
using Laul.Application.Common.Exeption;
using Laul.Application.Interfaces.Persistance;
using Laul.Domain.Entities;
using MediatR;


namespace Laul.Application.Services.Artists.Queries.GetArtistDetails
{
    public class GetArtistDetailsQueryHandler : IRequestHandler<GetArtistDetailsQuery, ArtistDetilsVm>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetArtistDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ArtistDetilsVm> Handle(GetArtistDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Artist.GetById(request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundExeption(nameof(Artist), entity.Id);
            }

            var songs = (await _unitOfWork.Song.FindAsyncNoTracking(s => s.ArtistId == request.Id))
                .AsQueryable()
                .ProjectTo<ArtistSongListDto>(_mapper.ConfigurationProvider)
                .ToList();

            var albums = (await _unitOfWork.Album.FindAsyncNoTracking(s => s.ArtistId == request.Id))
                .AsQueryable()
                .ProjectTo<ArtistAlbumListDto>(_mapper.ConfigurationProvider)
                .ToList();

            var artist = (await _unitOfWork.Artist.FindAsyncNoTracking(a => a.Id == request.Id))
                .AsQueryable()
                .ProjectTo<ArtistDetilsVm>(_mapper.ConfigurationProvider)
                .ToList();

            var artistDetilsVm = _mapper.Map<ArtistDetilsVm>(artist);
            artistDetilsVm.Songs = _mapper.Map<IList<ArtistSongListDto>>(songs);
            artistDetilsVm.Albums = _mapper.Map<IList<ArtistAlbumListDto>>(albums);

            return artistDetilsVm;
        }
    }
}
