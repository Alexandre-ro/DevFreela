using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configuration
{
    public class ProjectCommentConfiguration : IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(EntityTypeBuilder<ProjectComment> modelBuilder)
        {
            modelBuilder.ToTable("project_comment")
                        .HasKey(p => p.Id);

            modelBuilder.HasOne(p => p.Project)
                        .WithMany(p => p.Comments)
                        .HasForeignKey(p => p.IdProject)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.HasOne(p => p.User)
                        .WithMany(p => p.Comments)
                        .HasForeignKey(p => p.IdUser)
                        .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
