using DnDEncounterGenerator.Api.Models;
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

        // GET: MonsterController
        [HttpGet]
        public ActionResult GetAllMonsters()
        {
            return Ok(_monsterRepository.GetAllMonsters());
        }
    }
}
