using AutoMapper;
using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;
using System.Net.Sockets;

namespace Laul.Application.Services.Songs.Queries.GetSongListByArtist
{
    public class SongLookupDto : IMapWith<Song>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Photo {  get; set; }
        public string Storage { get; set; }
        public long AlbumId { get; set; }
        public string AlbumTitle { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Song, SongLookupDto>()
                .ForMember(dest => dest.AlbumTitle, opt => opt.MapFrom(src => src.Album != null ? src.Album.Title : null));
        }

    }
}
