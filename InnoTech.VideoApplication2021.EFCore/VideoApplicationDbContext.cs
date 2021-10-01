using System;
using InnoTech.VideoApplication2021.EFCore.Entities;
using InnotTech.VideoApplication2021.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace InnoTech.VideoApplication2021.EFCore
{
    public class VideoApplicationDbContext: DbContext
    {
        public VideoApplicationDbContext(DbContextOptions<VideoApplicationDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoEntity>()
                .HasOne(v => v.Genre)
                .WithMany()
                .HasForeignKey(v => new { v.GenreId })
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<GenreEntity>().HasData(new GenreEntity { Id = 1, Name = "Horror" });
            modelBuilder.Entity<GenreEntity>().HasData(new GenreEntity { Id = 2, Name = "Comedy" });
            
            modelBuilder.Entity<VideoEntity>().HasData(new VideoEntity()
            {
                Id = 1, 
                Title = "Horror Days", 
                ReleaseDate = DateTime.Now, 
                StoryLine = "Yahh", 
                GenreId = 1
            });
            modelBuilder.Entity<VideoEntity>().HasData(new VideoEntity()
            {
                Id = 2, 
                Title = "Comedy Days", 
                ReleaseDate = DateTime.Now, 
                StoryLine = "juibii", 
                GenreId = 2
            });
        }

        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<VideoEntity> Videos { get; set; }
    }
}