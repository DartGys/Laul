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

            builder.Property(ls => ls.UserId)
            .HasColumnName("UserId")
            .HasColumnType("uniqueidentifier");

            builder.HasOne(ls => ls.Song)
            .WithMany(song => song.ListeningStats)
            .HasForeignKey(ls => ls.SongId) 
            .IsRequired();
        }
    }
}
