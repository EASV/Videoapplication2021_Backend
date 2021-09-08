using System;

namespace InnoTech.VideoApplication2021.WebApi.Dtos.Videos
{
    public class PutVideoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string StoryLine { get; set; }
    }
}