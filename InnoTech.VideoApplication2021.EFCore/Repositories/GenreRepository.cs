using System.Collections.Generic;
using System.Linq;
using InnoTech.VideoApplication2021.Domain.IRepositories;
using InnoTech.VideoApplication2021.EFCore.Entities;
using InnotTech.VideoApplication2021.Core.Models;

namespace InnoTech.VideoApplication2021.EFCore.Repositories
{
    public class GenreRepository: IGenreRepository
    {
        private readonly VideoApplicationDbContext _ctx;

        public GenreRepository(VideoApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Genre> FindAll()
        {
            /*var list = new List<Genre>();
            var entityList = _ctx.Genres.ToList();
            foreach (var entity in entityList)
            {
                list.Add(new Genre
                {
                    Id = entity.Id,
                    Name = entity.Name
                });
            }
            return list;*/

            return _ctx.Genres
                .Select(genreEntity => new Genre
                {
                    Id = genreEntity.Id,
                    Name = genreEntity.Name
                })
                .ToList();
        }

        public Genre ReadById(int id)
        {
            return _ctx.Genres
                .Select(genreEntity => new Genre
                {
                    Id = genreEntity.Id,
                    Name = genreEntity.Name
                })
                .FirstOrDefault(g => g.Id == id);
        }

        public Genre Create(Genre genre)
        {
            var entity = _ctx.Genres.Add(new GenreEntity
            {
                Name = genre.Name
            }).Entity;
            _ctx.SaveChanges();
            return new Genre
            {
                Name = entity.Name,
                Id = entity.Id
            };
        }

        public Genre Delete(int id)
        {
            var entity = _ctx.Genres.Remove(new GenreEntity { Id = id }).Entity;
            _ctx.SaveChanges();
            return new Genre
            {
                Id = entity.Id
            };
        }

        public Genre Update(Genre genre)
        {
            var entity = _ctx.Genres.Update(
                new GenreEntity
                {
                    Id = genre.Id,
                    Name = genre.Name
                }).Entity;
            _ctx.SaveChanges();
            return new Genre
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}