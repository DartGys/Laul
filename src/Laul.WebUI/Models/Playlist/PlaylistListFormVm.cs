using AutoMapper;
using Laul.Application.Services.Playlists.Queries.GetPlaylistList;
using Laul.WebUI.Common.Mapping;

namespace Laul.WebUI.Models.Playlist
{
    public class PlaylistListFormVm : IMapWith<PlaylistListVm>
    {
        public IList<PlaylistListFormDto> Playlists { get; set; }
        public long SongId { get; set; }

        public class PlaylistListFormDto : IMapWith<PlaylistLookupDto>
        {
            public long Id { get; set; }
            public string Title { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<PlaylistLookupDto, PlaylistListFormDto>();
            }
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PlaylistListVm, PlaylistListFormVm>();
        }
    }

}

