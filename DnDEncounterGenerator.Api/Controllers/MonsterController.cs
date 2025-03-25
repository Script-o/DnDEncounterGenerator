using DnDEncounterGenerator.Api.Models;
using DnDEncounterGenerator.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DnDEncounterGenerator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonsterController : Controller
    {
        private readonly IMonsterRepository _monsterRepository;

        public MonsterController(IMonsterRepository monsterRepository)
        {
            _monsterRepository = monsterRepository;
        }

        // GET: api/Monster
        [HttpGet]
        public ActionResult GetAllMonsters()
        {
            return Ok(_monsterRepository.GetAllMonsters());
        }

        // GET: api/Monster/#
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            return Ok(_monsterRepository.GetMonsterById(id));
        }

        // POST: api/Monster
        [HttpPost]
        public IActionResult AddMonster([FromBody] Monster monster)
        {
            if (monster == null)
                return BadRequest();

            //This is not currently working.
            if (monster.Name == string.Empty || monster.ArmorClass < 0)
            {
                ModelState.AddModelError("Name/Armor Class", "The name or shouldn't be empty and the Armor Class must be a positive number");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdMonster = _monsterRepository.AddMonster(monster);

            return Created("monster", createdMonster);
        }

        // PUT: api/Monster
        [HttpPut]
        public IActionResult UpdateMonster([FromBody] Monster monster)
        {
            if (monster == null)
                return BadRequest();

            //This is not currently working.
            if (monster.Name == string.Empty || monster.ArmorClass < 0)
            {
                ModelState.AddModelError("Name/Armor Class", "The name or shouldn't be empty and the Armor Class must be a positive number");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var monsterToUpdate = _monsterRepository.GetMonsterById(monster.MonsterId);

            if (monsterToUpdate == null)
                return NotFound();

            var updatedMonster = _monsterRepository.UpdateMonster(monster);

            return Created("monster", updatedMonster);
        }

        // DELETE: api/Monster/#
        [HttpDelete("{id}")]
        public IActionResult DeleteMonster(int id)
        {
            if (id == 0)
                return BadRequest();

            var monsterToDelete = _monsterRepository.GetMonsterById(id);
            if (monsterToDelete == null)
                return NotFound();

            _monsterRepository.DeleteMonster(id);

            return NoContent();//success
        }
    }
}
