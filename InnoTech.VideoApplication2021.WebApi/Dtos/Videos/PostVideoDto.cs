using System;

namespace InnoTech.VideoApplication2021.WebApi.Dtos.Videos
{
    public class PostVideoDto
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string StoryLine { get; set; }
        public int GenreId { get; set; }
    }
}