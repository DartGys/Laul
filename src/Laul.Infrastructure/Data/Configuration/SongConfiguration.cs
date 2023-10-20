using Laul.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laul.Infrastructure.Data.Configuration
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Title)
            .IsRequired()
            .HasMaxLength(255);

            builder.Property(s => s.Duration)
            .IsRequired();

            builder.Property(s => s.PublishDate)
                .HasColumnType("date");

            builder.Property(s => s.Photo)
           .HasMaxLength(255);

            builder.Property(s => s.Storage)
           .IsRequired()
           .HasMaxLength(255);

            builder.Property(s => s.Genre)
            .HasMaxLength(50);

            builder.HasOne(s => s.Artist)
           .WithMany(a => a.Songs)
           .HasForeignKey(s => s.ArtistId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Album)
            .WithMany(a => a.Songs)
            .HasForeignKey(s => s.AlbumId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.LikeDislikes)
            .WithOne(ld => ld.Song)
            .HasForeignKey(ld => ld.SongId);

            builder.HasMany(s => s.ListeningStats)
           .WithOne(ls => ls.Song)
           .HasForeignKey(ls => ls.SongId);

            builder.HasMany(s => s.PlaylistSongs)
            .WithOne(ps => ps.Song)
            .HasForeignKey(ps => ps.SongId);
        }
    }
}
