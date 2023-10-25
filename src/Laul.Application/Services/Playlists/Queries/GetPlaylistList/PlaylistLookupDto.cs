using AutoMapper;
using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;

namespace Laul.Application.Services.Playlists.Queries.GetPlaylistList
{
    public class PlaylistLookupDto : IMapWith<Playlist>
    {
        public ulong Id { get; set; }
        public string Title { get; set; }

        public void Mapper(Profile profile)
        {
            profile.CreateMap<PlaylistLookupDto, Playlist>();
        }
    }
}
