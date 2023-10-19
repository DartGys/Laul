using Laul.Application.Interfaces.Persistance;
using Laul.Application.Interfaces.Persistance.Repository;
using Laul.Infrastructure.Data;
using Laul.Infrastructure.Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Infrastructure.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context) 
        {
            _context = context;
            Album = new AlbumRepository(_context);
            Artist = new ArtistRepository(_context);
            LikeDislike = new LikeDislikeRepository(_context);
            ListeningStats = new ListeningStatRepository(_context);
            Playlist = new PlaylistRepository(_context);
            PlaylistSong = new PlaylistSongRepository(_context);
            Song = new SongRepository(_context);
        }
        private bool disposed = false;
        public IAlbumRepository Album { get; private set; }

        public IArtistRepository Artist { get; private set; }

        public ILikeDislikeRepository LikeDislike { get; private set; }

        public IListeningStatsRepository ListeningStats { get; private set; }

        public IPlaylistRepository Playlist { get; private set; }

        public IPlaylistSongRepository PlaylistSong { get; private set; }

        public ISongRepository Song { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Визвільнення управляються ресурси (наприклад, відкриті файли або з'єднання з базою даних)
                    // Для кожного ресурсу слід викликати його Dispose або Close метод, якщо такий існує.
                }

                // Визвільнення неуправляються ресурси (наприклад, великі буфери пам'яті)

                disposed = true;
            }
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangeAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
