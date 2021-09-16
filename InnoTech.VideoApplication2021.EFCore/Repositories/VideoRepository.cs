using System.Collections.Generic;
using InnoTech.VideoApplication2021.Domain.IRepositories;
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
            throw new System.NotImplementedException();
        }

        public List<Video> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Video FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Video Update(Video video)
        {
            throw new System.NotImplementedException();
        }

        public Video Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}