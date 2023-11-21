using AutoMapper;
using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;

namespace Laul.Application.Services.Playlists.Queries.GetPlaylistList
{
    public class PlaylistLookupDto : IMapWith<Playlist>
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Playlist, PlaylistLookupDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));;
        }
    }
}
