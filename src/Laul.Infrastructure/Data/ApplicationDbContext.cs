using Laul.Domain.Entities;
using Laul.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
        public DbSet<PlaylistSong> PlaylistSongs => Set<PlaylistSong>();

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
