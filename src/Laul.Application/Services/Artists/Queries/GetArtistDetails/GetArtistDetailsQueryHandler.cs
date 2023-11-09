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
            var entity = (await _unitOfWork.Artist.FindAsyncNoTracking(e => e.Name == request.name, cancellationToken)).FirstOrDefault();

            if (entity == null || entity.Name != request.name)
            {
                throw new NotFoundExeption(nameof(Artist), entity.Id);
            }

            var songs = (await _unitOfWork.Song.FindAsyncNoTracking(s => s.ArtistId == entity.Id, cancellationToken))
                .ToList();

            var albums = (await _unitOfWork.Album.FindAsyncNoTracking(s => s.ArtistId == entity.Id, cancellationToken))
                .ToList();

            var artistDetilsVm = _mapper.Map<ArtistDetilsVm>(entity);
            artistDetilsVm.Songs = _mapper.Map<IList<ArtistSongListDto>>(songs);
            artistDetilsVm.Albums = _mapper.Map<IList<ArtistAlbumListDto>>(albums);

            return artistDetilsVm;
        }
    }
}
