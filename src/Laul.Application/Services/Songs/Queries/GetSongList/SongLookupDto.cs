﻿using AutoMapper;
using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;
using System;

namespace Laul.Application.Services.Songs.Queries.GetSongList
{
    public class SongLookupDto : IMapWith<Song>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Storage { get; set; }
        public Guid ArtistId { get; set; }
        public string ArtistName { get; set; }
        public long AlbumId { get; set; }
        public string AlbumTitle { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Song, SongLookupDto>()
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Artist.Name))
                .ForMember(dest => dest.AlbumTitle, opt => opt.MapFrom(src => src.Album != null ? src.Album.Title : null));
        }
    }
}
