using Laul.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laul.Infrastructure.Data.Configuration
{
    internal class PlaylistConfiguration : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(255);

            builder.Property(p => p.Description)
            .HasMaxLength(1000);

            builder.HasOne(p => p.Artist)
            .WithMany(p => p.Playlists)
            .HasForeignKey(album => album.ArtistId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.PlaylistSongs)
            .WithOne(ps => ps.Playlist)
            .HasForeignKey(ps => ps.PlaylistId);
        }
    }
}
