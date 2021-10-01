using System.Collections.Generic;
using System.Linq;
using InnoTech.VideoApplication2021.Domain.IRepositories;
using InnoTech.VideoApplication2021.EFCore.Entities;
using InnotTech.VideoApplication2021.Core.Models;

namespace InnoTech.VideoApplication2021.EFCore.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly VideoApplicationDbContext _ctx;

        public VideoRepository(VideoApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Video Add(Video video)
        {
            var entity = _ctx.Videos.Add(new VideoEntity
            {
                Id = video.Id,
                Title = video.Title,
                ReleaseDate = video.ReleaseDate,
                StoryLine = video.StoryLine
            }).Entity;
            _ctx.SaveChanges();
            return new Video()
            {
                Id = entity.Id,
                Title = entity.Title,
                ReleaseDate = entity.ReleaseDate,
                StoryLine = entity.StoryLine
            };
        }

        public List<Video> FindAll()
        {
            return _ctx.Videos
                .Select(entity => new Video()
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    ReleaseDate = entity.ReleaseDate,
                    StoryLine = entity.StoryLine,
                    Genre = entity.GenreId.HasValue ? new Genre
                    {
                        Id = entity.Genre.Id,
                        Name = entity.Genre.Name
                    } : null
                })
                .ToList();
        }

        public Video FindById(int id)
        {
            return _ctx.Videos
                .Select(entity => new Video()
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    ReleaseDate = entity.ReleaseDate,
                    StoryLine = entity.StoryLine
                })
                .FirstOrDefault(v => v.Id == id);
        }

        public Video Update(Video video)
        {
            var entity = _ctx.Videos.Update(
                new VideoEntity()
                {
                    Id = video.Id,
                    Title = video.Title,
                    ReleaseDate = video.ReleaseDate,
                    StoryLine = video.StoryLine
                }).Entity;
            _ctx.SaveChanges();
            return new Video()
            {
                Id = entity.Id,
                Title = entity.Title,
                ReleaseDate = entity.ReleaseDate,
                StoryLine = entity.StoryLine
            };
        }

        public Video Remove(int id)
        {
            var entity = _ctx.Videos.Remove(new VideoEntity { Id = id }).Entity;
            _ctx.SaveChanges();
            return new Video()
            {
                Id = entity.Id
            };
        }
    }
}