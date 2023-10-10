using Laul.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Laul.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Album> Albums { get;}
        DbSet<Artist> Artists { get;}
        DbSet<LikeDislike> LikeDislikes { get;}
        DbSet<ListeningStat> ListeningStats { get; }
        DbSet<Playlist> Playlists { get; }
        DbSet<Song> Songs { get; }
        Task<int> SaveChangesAsync();
    }
}
