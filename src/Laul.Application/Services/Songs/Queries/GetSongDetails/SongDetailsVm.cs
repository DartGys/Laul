using System;
using AutoMapper;
using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Laul.Application.Services.Songs.Queries.GetSongDetails
{
    public class SongDetailsVm : IMapWith<Song>
    {
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Storage { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public ulong likeCount { get; set; }
        public ulong dislikeCount { get; set; }
        public ulong listeningCount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Song, SongDetailsVm>()
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.PublishDate.Year))
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Artist.Name))
                .ForMember(dest => dest.AlbumName, opt => opt.MapFrom(src => src.Album.Image))
                .ForMember(dest => dest.likeCount, opt => opt.MapFrom(src => src.LikeDislikes.Where(l => l.IsLike == true).Count()))
                .ForMember(dest => dest.dislikeCount, opt => opt.MapFrom(src => src.LikeDislikes.Where(l => l.IsLike == false).Count()))
                .ForMember(dest => dest.listeningCount, opt => opt.MapFrom(src => src.ListeningStats.Count()));
        }
    }
}
