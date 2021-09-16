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
        private readonly IGenreRepository _genreRepository;

        public VideoRepository(IGenreRepository genreRepository)
        {
            _videoConverter = new VideoConverter();
            _genreRepository = genreRepository;
        }
        public Video Add(Video video)
        {
            var videoEntity = _videoConverter.Convert(video);
            videoEntity.Id = _id++;
            videoEntity.GenreId = video.Genre.Id;
            videoEntity.Genre = _genreRepository.ReadById(video.Genre.Id);
            _videosTable.Add(videoEntity);
            return _videoConverter.Convert(videoEntity);
        }

        public List<Video> FindAll()
        {
            var listOfVideos = new List<Video>();
            foreach (var videoEntity in _videosTable)
            {
                var video = _videoConverter.Convert(videoEntity);
                video.Genre = _genreRepository.ReadById(video.Genre.Id);
                listOfVideos.Add(video);
            }

            return listOfVideos;
        }

        public Video FindById(int id)
        {
            var entity = _videosTable.FirstOrDefault(video => video.Id == id);
            return _videoConverter.Convert(entity);
        }

        public Video Update(Video video)
        {
            _videosTable = _videosTable.Where(v => v.Id != video.Id).ToList();
            _videosTable.Add(_videoConverter.Convert(video));
            var videoUpdate = _videosTable.FirstOrDefault(v => v.Id == video.Id);
            return videoUpdate == null ? null : _videoConverter.Convert(videoUpdate);
        }

        public Video Remove(int id)
        {
            var videoRemove = _videosTable.FirstOrDefault(v => v.Id == id);
            _videosTable = _videosTable.Where(v => v.Id != id).ToList();
            return videoRemove == null ? null : _videoConverter.Convert(videoRemove);
        }
    }
}