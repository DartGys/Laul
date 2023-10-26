using Laul.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laul.Infrastructure.Data.Configuration
{
    public class LikeDislikeConfiguration : IEntityTypeConfiguration<LikeDislike>
    {
        public void Configure(EntityTypeBuilder<LikeDislike> builder)
        {
            builder.HasKey(ld => new { ld.UserId, ld.SongId });

            builder.Property(ld => ld.ActionDate)
            .IsRequired();

            builder.Property(ld => ld.IsLike)
            .IsRequired();

            builder.Property(ld => ld.UserId)
            .HasMaxLength(255)
            .IsRequired();

            builder.HasOne(ld => ld.Song)
           .WithMany()
           .HasForeignKey(ld => ld.SongId);
        }
    }
}
