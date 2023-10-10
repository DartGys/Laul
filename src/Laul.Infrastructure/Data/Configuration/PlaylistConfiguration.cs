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

            builder.Property(ld => ld.UserId)
            .HasMaxLength(255)
            .IsRequired();

            builder.HasMany(p => p.PlaylistSongs)
            .WithOne(ps => ps.Playlist)
            .HasForeignKey(ps => ps.PlaylistId);
        }
    }
}
