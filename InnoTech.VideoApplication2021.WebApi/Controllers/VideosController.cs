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
        
        [HttpGet]
        public List<Video> Get()
        {
            return _service.ReadAll();
        }
    }
}