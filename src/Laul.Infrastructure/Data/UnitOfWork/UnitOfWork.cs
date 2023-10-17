using Laul.Application.Interfaces;
using Laul.Application.Interfaces.EntitiesRepository;
using Laul.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context) 
        {
            _context = context;
            Album = new AlbumRepository(context);
            Artist = new ArtistRepository(context);
            LikeDislike = new LikeDislikeRepository(context);
            ListeningStats = new ListeningStatsRepository(context);
            Playlist = new PlaylistRepository(context);
            PlaylistSong = new PlaylistSongRepository(context);
            Song = new SongRepository(context);
        }

        public IAlbumRepository Album { get; private set; }

        public IArtistRepository Artist { get; private set; }

        public ILikeDislikeRepository LikeDislike { get; private set; }

        public IListeningStatsRepository ListeningStats { get; private set; }

        public IPlaylistRepository Playlist { get; private set; }

        public IPlaylistSongRepository PlaylistSong { get; private set; }

        public ISongRepository Song { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
