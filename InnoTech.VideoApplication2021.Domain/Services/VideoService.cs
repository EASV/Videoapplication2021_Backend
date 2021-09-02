using System.Collections.Generic;
using InnoTech.VideoApplication2021.Domain.IRepositories;
using InnotTech.VideoApplication2021.Core.IServices;
using InnotTech.VideoApplication2021.Core.Models;

namespace InnoTech.VideoApplication2021.Domain.Services
{
    public class VideoService : IVideoService
    {
        private IVideoRepository _repo;
        public VideoService(IVideoRepository repo)
        {
            _repo = repo;
        }
        
        public Video Create(Video video)
        {
            return _repo.Add(video);
        }

        public List<Video> ReadAll()
        {
            return _repo.FindAll();
        }
    }
}