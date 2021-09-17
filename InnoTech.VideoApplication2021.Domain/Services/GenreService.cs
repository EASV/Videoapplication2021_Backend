using System.Collections.Generic;
using InnoTech.VideoApplication2021.Domain.IRepositories;
using InnotTech.VideoApplication2021.Core.IServices;
using InnotTech.VideoApplication2021.Core.Models;

namespace InnoTech.VideoApplication2021.Domain.Services
{
    public class GenreService: IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        
        public List<Genre> ReadAll()
        {
            return _genreRepository.FindAll();
        }

        public Genre ReadById(int id)
        {
            return _genreRepository.ReadById(id);
        }

        public Genre Create(Genre genre)
        {
            return _genreRepository.Create(genre);
        }

        public Genre Delete(int id)
        {
            return _genreRepository.Delete(id);
        }

        public Genre Update(Genre genre)
        {
            return _genreRepository.Update(genre);
        }
    }
}