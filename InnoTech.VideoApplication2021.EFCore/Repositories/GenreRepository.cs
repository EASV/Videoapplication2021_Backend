using System.Collections.Generic;
using InnoTech.VideoApplication2021.Domain.IRepositories;
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
            throw new System.NotImplementedException();
        }

        public Genre ReadById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}