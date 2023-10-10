using Laul.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laul.Infrastructure.Data.Configuration
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(album => album.Title)
            .HasMaxLength(255)
            .IsRequired();

            builder.Property(album => album.Image)
            .HasMaxLength(255);

            builder.Property(album => album.Year)
                .IsRequired();

            builder.Property(album => album.Genre)
            .HasMaxLength(50);

            builder.HasOne(album => album.Artist)
            .WithMany(artist => artist.Albums)
            .HasForeignKey(album => album.ArtistId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(album => album.Songs)
            .WithOne(song => song.Album)
            .HasForeignKey(song => song.AlbumId);
        }
    }
}
