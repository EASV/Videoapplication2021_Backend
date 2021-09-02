using System.Collections.Generic;
using System.Linq;
using InnoTech.VideoApplication2021.Domain.IRepositories;
using InnoTech.VideoApplication2021.SQL.Converters;
using InnoTech.VideoApplication2021.SQL.Entities;
using InnotTech.VideoApplication2021.Core.Models;

namespace InnoTech.VideoApplication2021.SQL.Repositories
{
    public class VideoRepository: IVideoRepository
    {
        private static List<VideoEntity> _videosTable = new List<VideoEntity>();
        private static int _id = 1;
        private readonly VideoConverter _videoConverter;


        public VideoRepository()
        {
            _videoConverter = new VideoConverter();
        }
        public Video Add(Video video)
        {
            var videoEntity = _videoConverter.Convert(video);
            videoEntity.Id = _id++;
            _videosTable.Add(videoEntity);
            return _videoConverter.Convert(videoEntity);
        }

        public List<Video> FindAll()
        {
            var listOfVideos = new List<Video>();
            foreach (var videoEntity in _videosTable)
            {
                listOfVideos.Add(_videoConverter.Convert(videoEntity));
            }

            return listOfVideos;
        }
    }
}