using InnoTech.VideoApplication2021.SQL.Entities;
using InnotTech.VideoApplication2021.Core.Models;

namespace InnoTech.VideoApplication2021.SQL.Converters
{
    public class VideoConverter
    {
        public Video Convert(VideoEntity entity)
        {
            return new Video
            {
                Id = entity.Id,
                ReleaseDate = entity.ReleaseDate,
                StoryLine = entity.StoryLine,
                Title = entity.Title
            };
        }
        
        public VideoEntity Convert(Video video)
        {
            return new VideoEntity
            {
                Id = video.Id,
                ReleaseDate = video.ReleaseDate,
                StoryLine = video.StoryLine,
                Title = video.Title,
                GenreId = video.Genre != null ? video.Genre.Id : 0
            };
        }
    }
}