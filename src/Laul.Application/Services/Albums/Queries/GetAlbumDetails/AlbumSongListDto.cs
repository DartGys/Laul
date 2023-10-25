using AutoMapper;
using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;

namespace Laul.Application.Services.Albums.Queries.GetAlbumDetails
{
    public class SongLookupDto : IMapWith<Song>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Storage { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Song, SongLookupDto>();
        }
    }
}
