using AutoMapper;
using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;

namespace Laul.Application.Services.Playlists.Queries.GetPlaylistDetails
{
    public class PlaylistSongListDto : IMapWith<Song>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Storage { get; set; }
        public Guid ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int AlbumId { get; set; }
        public string AlbumTitle { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Song, PlaylistSongListDto>()
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Artist.Name))
                .ForMember(dest => dest.AlbumTitle, opt => opt.MapFrom(src => src.Album.Title))

        }
    }
}
