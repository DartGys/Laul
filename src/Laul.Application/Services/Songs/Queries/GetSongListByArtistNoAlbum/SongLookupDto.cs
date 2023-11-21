using AutoMapper;
using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;

namespace Laul.Application.Services.Songs.Queries.GetSongListByArtistNoAlbum
{
    public class SongLookupDto : IMapWith<Song>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Photo {  get; set; }
        public string Storage { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Song, SongLookupDto>();
        }

    }
}
