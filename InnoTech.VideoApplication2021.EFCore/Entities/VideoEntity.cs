using System;

namespace InnoTech.VideoApplication2021.EFCore.Entities
{
    public class VideoEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string StoryLine { get; set; }
        //Writing 
        public int? GenreId { get; set; }
        //Read
        public GenreEntity Genre { get; set; }
    }
}