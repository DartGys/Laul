using Laul.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laul.Infrastructure.Data.Configuration
{
    public class LikeDislikeConfiguration : IEntityTypeConfiguration<LikeDislike>
    {
        public void Configure(EntityTypeBuilder<LikeDislike> builder)
        {
            builder.HasKey(ld => new { ld.ArtistId, ld.SongId });

            builder.Property(ld => ld.ActionDate)
            .IsRequired();

            builder.Property(ld => ld.IsLike)
            .IsRequired();

            builder.HasOne(ld => ld.Artist)
            .WithMany(ld => ld.LikeDislikes)
            .HasForeignKey(album => album.ArtistId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ld => ld.Song)
           .WithMany()
           .HasForeignKey(ld => ld.SongId);
        }
    }
}
