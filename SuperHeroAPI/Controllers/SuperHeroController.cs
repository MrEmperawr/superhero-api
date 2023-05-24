using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return _superHeroService.GetAllHeroes();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<SuperHero?>> GetHero(int id)
        {
            var result = _superHeroService.GetHero(id);
            if (result is null) return NotFound("Sorry, does not exist in the database.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _superHeroService.AddHero(hero);
            return Ok(_superHeroService.GetAllHeroes());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<SuperHero?>> UpdateHero(int id, SuperHero request)
        {
            var result = _superHeroService.UpdateHero(id, request);
            if (result is null) return NotFound("Sorry that hero does not exist.");

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<SuperHero?>> DeleteHero(int id)
        {
            _superHeroService.DeletHero(id);

            return Ok(_superHeroService.GetAllHeroes());
        }
    }
}
