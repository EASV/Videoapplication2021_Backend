using System.Collections.Generic;
using InnotTech.VideoApplication2021.Core.Models;

namespace InnoTech.VideoApplication2021.Domain.IRepositories
{
    public interface IGenreRepository
    {
        List<Genre> FindAll();
        Genre ReadById(int id);
        Genre Create(Genre genre);
        Genre Delete(int id);
        Genre Update(Genre genre);
    }
}