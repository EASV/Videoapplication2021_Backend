using System;

namespace InnoTech.VideoApplication2021.WebApi.Dtos.Videos
{
    public class GetVideoByIdDto
    {
        public string Title { get; set; }
        public string StoryLine { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}