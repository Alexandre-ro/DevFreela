using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.ToTable("user")
                        .HasKey(u => u.Id);

            modelBuilder.HasMany(u => u.Skills)
                        .WithOne()
                        .HasForeignKey(u => u.IdSkill)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
