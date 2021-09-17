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

        [HttpGet("{id}")]
        public ActionResult<Genre> GetById(int id)
        {
            return Ok(_genreService.ReadById(id));
        }

        [HttpPost]
        public ActionResult<Genre> Create([FromBody] Genre genre)
        {
            return Ok(_genreService.Create(genre));
        }
        
        [HttpDelete("{id}")]
        public ActionResult<Genre> Delete(int id)
        {
            return Ok(_genreService.Delete(id));
        }
        
        [HttpPut("{id}")]
        public ActionResult<Genre> Put(int id, [FromBody] Genre genre)
        {
            if (id != genre.Id)
            {
                return BadRequest("Id must match id in json object");
            }
            return Ok(_genreService.Update(genre));
        }

    }
}