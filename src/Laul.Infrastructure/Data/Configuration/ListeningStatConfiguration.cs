using Laul.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laul.Infrastructure.Data.Configuration
{
    public class ListeningStatConfiguration : IEntityTypeConfiguration<ListeningStat>
    {
        public void Configure(EntityTypeBuilder<ListeningStat> builder)
        {
            builder.HasKey(ls => ls.Id);

            builder.Property(ls => ls.ListeningDate)
            .IsRequired();

            builder.HasOne(ls => ls.Artist)
            .WithMany(ls => ls.ListeningStats)
            .HasForeignKey(album => album.ArtistId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ls => ls.Song)
            .WithMany(song => song.ListeningStats)
            .HasForeignKey(ls => ls.SongId) 
            .IsRequired();
        }
    }
}
