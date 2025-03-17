using DnDEncounterGenerator.Api.Models;
using DnDEncounterGenerator.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DnDEncounterGenerator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncounterController : Controller
    {
        private readonly IEncounterRepository _encounterRepository;
        public EncounterController(IEncounterRepository encounterRepository)
        {
            _encounterRepository = encounterRepository;
        }

        // GET: api/Encounter
        [HttpGet]
        public ActionResult GetAllMonsters()
        {
            return Ok(_encounterRepository.GetAllEncounters());
        }

        // GET: api/Encounter/#
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            return Ok(_encounterRepository.GetEncounterById(id));
        }

        // POST: api/Encounter
        [HttpPost]
        public IActionResult AddEncounter([FromBody] Encounter encounter)
        {
            if (encounter == null)
                return BadRequest();

            //This is not currently working.
            if (encounter.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The name or shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdEncounter = _encounterRepository.AddEncounter(encounter);

            return Created("encounter", createdEncounter);
        }

        // PUT: api/Monster
        [HttpPut]
        public IActionResult UpdateEncounter([FromBody] Encounter encounter)
        {
            if (encounter == null)
                return BadRequest();

            //This is not currently working.
            if (encounter.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The name or shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var encounterToUpdate = _encounterRepository.GetEncounterById(encounter.EncounterId);

            if (encounterToUpdate == null)
                return NotFound();

            encounter.Monsters.Add(new Monster { Name="Test"});

            _encounterRepository.UpdateEncounter(encounter);

            return NoContent(); //success
        }

        //// PUT: api/Monster
        //[HttpPut]
        //public IActionResult AddMonsterToEncounter([FromBody] Encounter encounter)
        //{
        //    if (encounter == null)
        //        return BadRequest();

        //    //This is not currently working.
        //    if (encounter.Name == string.Empty)
        //    {
        //        ModelState.AddModelError("Name", "The name or shouldn't be empty");
        //    }

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var encounterToUpdate = _encounterRepository.GetEncounterById(encounter.EncounterId);

        //    if (encounterToUpdate == null)
        //        return NotFound();

        //    _encounterRepository.AddMonsterToEncounter(encounter, monster);

        //    return NoContent(); //success
        //}

        // DELETE: api/Monster/#
        [HttpDelete("{id}")]
        public IActionResult DeleteEncounter(int id)
        {
            if (id == 0)
                return BadRequest();

            var monsterToDelete = _encounterRepository.GetEncounterById(id);
            if (monsterToDelete == null)
                return NotFound();

            _encounterRepository.DeleteEncounter(id);

            return NoContent();//success
        }
    }
}
