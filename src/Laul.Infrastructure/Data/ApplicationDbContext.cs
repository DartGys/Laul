using Laul.Domain.Entities;
using Laul.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Laul.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Album> Albums => Set<Album>();
        public DbSet<Artist> Artists => Set<Artist>();
        public DbSet<LikeDislike> LikeDislikes => Set<LikeDislike>();
        public DbSet<ListeningStat> ListeningStats => Set<ListeningStat>();
        public DbSet<Playlist> Playlists => Set<Playlist>();
        public DbSet<Song> Songs => Set<Song>();

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
