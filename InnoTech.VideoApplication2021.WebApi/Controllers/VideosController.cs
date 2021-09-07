using System;
using System.Collections.Generic;
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
        
        //Create Video by passing in JSON in the Body
        [HttpPost]
        public ActionResult<Video> CreateVideo([FromBody] Video video)
        {
            var newVideo = _service.Create(video);
            return Created(
                $"https://localhost:5001/api/videos/{newVideo.Id}", 
                newVideo);
        }
    }
}