using System;
using System.Collections.Generic;
using InnoTech.VideoApplication2021.WebApi.Dtos.Videos;
using InnotTech.VideoApplication2021.Core.IServices;
using InnotTech.VideoApplication2021.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnoTech.VideoApplication2021.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IVideoService _service;
        
        public VideosController(IVideoService service)
        {
            _service = service;
        }
        
        //Read All Videos
        [HttpGet]
        public ActionResult<List<Video>> Get()
        {
            return Ok(_service.ReadAll());
        }

        [HttpGet("{id}")]
        public ActionResult<GetVideoByIdDto> GetById(int id)
        {
            var video = _service.ReadById(id);
            return Ok(new GetVideoByIdDto
            {
                Title = video.Title,
                StoryLine = video.StoryLine,
                ReleaseDate = video.ReleaseDate
            });
        }
        
        //Create Video by passing in JSON in the Body
        [HttpPost]
        public ActionResult<Video> CreateVideo([FromBody] PostVideoDto dto)
        {
            var videoFromDto = new Video
            {
                Title = dto.Title,
                StoryLine = dto.StoryLine,
                ReleaseDate = dto.ReleaseDate,
                Genre = new Genre
                {
                    Id = dto.GenreId
                }
            };
            try
            {
                var newVideo = _service.Create(videoFromDto);
                return Created(
                    $"https://localhost:5001/api/videos/{newVideo.Id}",
                    newVideo);
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }

        [HttpPut("{id}")]
        public ActionResult<Video> PutVideo(int id, [FromBody] PutVideoDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("Id in param must be the same as in object");
            }
            return Ok(_service.Update(new Video
            {
                Id = id,
                Title = dto.Title,
                ReleaseDate = dto.ReleaseDate,
                StoryLine = dto.StoryLine
            }));
        }

        [HttpDelete("{id}")]
        public ActionResult<Video> DeleteVideo(int id)
        {
            return Ok(_service.Delete(id));
        }
    }
}