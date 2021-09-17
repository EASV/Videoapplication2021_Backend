using System.Collections.Generic;
using InnotTech.VideoApplication2021.Core.Models;

namespace InnotTech.VideoApplication2021.Core.IServices
{
    public interface IGenreService
    {
        List<Genre> ReadAll();
        Genre ReadById(int id);
        Genre Create(Genre genre);
        Genre Delete(int id);
        Genre Update(Genre genre);
    }
}