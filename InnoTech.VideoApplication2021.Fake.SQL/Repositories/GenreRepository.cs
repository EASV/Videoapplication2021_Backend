using System.Collections.Generic;
using System.Linq;
using InnoTech.VideoApplication2021.Domain.IRepositories;
using InnoTech.VideoApplication2021.SQL.Entities;
using InnotTech.VideoApplication2021.Core.Models;

namespace InnoTech.VideoApplication2021.SQL.Repositories
{
    public class GenreRepository: IGenreRepository
    {
        private static List<GenreEntity> _genreTable;
        private static int _id = 1;

        public GenreRepository()
        {
            if (_genreTable == null)
            {
                _genreTable = new List<GenreEntity>
                {
                    new GenreEntity
                    {
                        Id = _id++,
                        Name = "Genre 1"
                    },
                    new GenreEntity
                    {
                        Id = _id++,
                        Name = "Genre 2"
                    }
                };
            }
            
        }
        
        public List<Genre> FindAll()
        {
            return _genreTable.Select(ge => new Genre()
                {   Name   = ge.Name,
                    Id = ge.Id
                }
            ).ToList();
        }

        public Genre ReadById(int id)
        {
            var entity = _genreTable.FirstOrDefault(g => g.Id == id);
            if (entity == null) return null;
            return new Genre
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}