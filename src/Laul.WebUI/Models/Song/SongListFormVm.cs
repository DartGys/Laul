using AutoMapper;
using Laul.WebUI.Common.Mapping;
using Laul.Application.Services.Songs.Queries.GetSongListByArtistNoAlbum;

namespace Laul.WebUI.Models.Song
{
    public class SongListFormVm : IMapWith<SongListByArtistNoAlbumVm>
    {
        public IList<SongLookupDto> Songs { get; set; }
        public long AlbumId { get; set; }

        public class SongListFormDto : IMapWith<SongLookupDto>
        {
            public long Id { get; set; }
            public string Title { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<SongLookupDto, SongListFormDto>();
            }
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SongListByArtistNoAlbumVm, SongListFormVm>();
        }
    }
}
