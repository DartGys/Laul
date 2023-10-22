using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Laul.Application.Interfaces.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Laul.Application.Services.Songs.Queries.GetSongList
{
    public class GetSongListQueryHandler : IRequestHandler<GetSongListQuery, SongListVm>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetSongListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<SongListVm> Handle(GetSongListQuery request, CancellationToken cancellationToken)
        {
            var songsList = (await _unitOfWork.Song.GetAllAsync())
                .AsQueryable()
                .ProjectTo<SongLookupDto>(_mapper.ConfigurationProvider)
                .ToList();


            return new SongListVm { Songs = songsList };
        }
    }
}
