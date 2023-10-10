using Laul.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laul.Infrastructure.Data.Configuration
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(artist => artist.Id);

            builder.Property(artist => artist.Name)
            .HasMaxLength(255)
            .IsRequired();

            builder.Property(artist => artist.Description)
            .HasMaxLength(1000);

            builder.HasMany(artist => artist.Albums)
            .WithOne(album => album.Artist)
            .HasForeignKey(album => album.ArtistId);

            builder.HasMany(artist => artist.Songs)
           .WithOne(album => album.Artist)
           .HasForeignKey(album => album.ArtistId);
        }
    }
}
