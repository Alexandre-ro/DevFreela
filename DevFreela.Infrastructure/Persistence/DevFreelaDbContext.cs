using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        protected DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
        {

        }

 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Primary Key            
            
            modelBuilder.Entity<Project>()
                        .ToTable("project")
                        .HasKey(p => p.Id);

            modelBuilder.Entity<Project>()
                        .HasOne(p => p.Freelancer)
                        .WithMany(f => f.FreelanceProjects)
                        .HasForeignKey(p => p.IdFreelancer)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                        .HasOne(p => p.Client)
                        .WithMany(p => p.OwnedProjects)
                        .HasForeignKey(p => p.IdClient)
                        .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ProjectComment>()
                        .ToTable("project_comment")
                        .HasKey(p => p.Id);


            modelBuilder.Entity<ProjectComment>()
                        .HasOne(p => p.Project)
                        .WithMany(p => p.Comments)
                        .HasForeignKey(p => p.IdProject)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectComment>()
                        .HasOne(p => p.User)
                        .WithMany(p => p.Comments)
                        .HasForeignKey(p => p.IdUser)
                        .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Skill>()
                        .ToTable("skill")
                        .HasKey(s => s.Id);

            modelBuilder.Entity<User>()
                         .ToTable("user")
                         .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                        .HasMany(u => u.Skills)
                        .WithOne()
                        .HasForeignKey(u => u.IdSkill)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserSkill>()
                        .ToTable("user_skill")
                        .HasKey(u => u.Id);
        }



        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ProjectComment> Comments { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }

    }
}
