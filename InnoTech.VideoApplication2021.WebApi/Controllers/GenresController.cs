using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnotTech.VideoApplication2021.Core.IServices;
using InnotTech.VideoApplication2021.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnoTech.VideoApplication2021.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        
        [HttpGet]
        public ActionResult<List<Genre>> GetAll()
        {
            return Ok(_genreService.ReadAll());
        }
    }
}