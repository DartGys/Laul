﻿using Laul.Application.Interfaces.EntitiesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAlbumRepository Album { get; }
        IArtistRepository Artist { get;}
        ILikeDislikeRepository LikeDislike { get; }
        IListeningStatsRepository ListeningStats { get; }
        IPlaylistRepository Playlist { get; }
        IPlaylistSongRepository PlaylistSong { get; }
        ISongRepository Song { get; }
        Task<int> SaveAsync();
    }
}