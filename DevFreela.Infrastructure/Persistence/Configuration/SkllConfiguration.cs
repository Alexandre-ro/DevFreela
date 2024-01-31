using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configuration
{
    public class SkllConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> modelBuilder)
        {
            modelBuilder.ToTable("skill")
                       .HasKey(s => s.Id);
        }
    }
}
