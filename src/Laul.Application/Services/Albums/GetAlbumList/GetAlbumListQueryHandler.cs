using AutoMapper;
using AutoMapper.QueryableExtensions;
using Laul.Application.Interfaces.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Laul.Application.Services.Albums.GetAlbumList
{
    public class GetAlbumListQueryHandler : IRequestHandler<GetAlbumListQuery, AlbumListVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public GetAlbumListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AlbumListVm> Handle(GetAlbumListQuery request, CancellationToken cancellation)
        {
            var artist = (await _unitOfWork.Artist.FindAsync(a => a.Id == request.ArtistId)).FirstOrDefault();

            var albumsList = (await _unitOfWork.Album.FindAsync(a => a.ArtistId == request.ArtistId))
                .AsQueryable()
                .Include(artist.Name)
                .ProjectTo<AlbumLookupDto>(_mapper.ConfigurationProvider)
                .ToList();

            return new AlbumListVm { Albums = albumsList };
        }
    }
}
