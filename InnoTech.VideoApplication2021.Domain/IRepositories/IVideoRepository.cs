using System.Collections.Generic;
using InnotTech.VideoApplication2021.Core.Models;

namespace InnoTech.VideoApplication2021.Domain.IRepositories
{
    public interface IVideoRepository
    {
        Video Add(Video video);
        List<Video> FindAll();
        Video FindById(int id);
        Video Update(Video video);
        Video Remove(int id);
    }
}