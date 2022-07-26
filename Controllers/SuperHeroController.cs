using Microsoft.AspNetCore.Mvc;
using User.Services.Implimentations;

namespace User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private SuperHeroServices _SuperHero;

        public SuperHeroController(DataContext context)=>
            _SuperHero = new SuperHeroServices(context);
        
        [HttpGet]
        public ActionResult<List<SuperHero>> Get()=>
            Ok(_SuperHero.GetHeroes());

        [HttpGet("{id}")]
        public ActionResult<SuperHero> Get(int id)
        {
            var hero = _SuperHero.GetHero(id);
            return hero !=null ? Ok(hero) : BadRequest("Hero not found.");
        }

        [HttpPost]
        public ActionResult<List<SuperHero>> AddHero(SuperHero hero)
        {
            _SuperHero.Add(hero);
            return Ok(_SuperHero.GetHeroes());
        }

        [HttpPut]
        public ActionResult<List<SuperHero>> UpdateHero(SuperHero request)
        {
            _SuperHero.Update(request);
            return Ok(_SuperHero.GetHeroes());
        }

        [HttpDelete("{id}")]
        public ActionResult<SuperHero> Delete(int id)
        {
            _SuperHero.Delete(id);
            return Ok(_SuperHero.GetHeroes());
        }
    }
}

