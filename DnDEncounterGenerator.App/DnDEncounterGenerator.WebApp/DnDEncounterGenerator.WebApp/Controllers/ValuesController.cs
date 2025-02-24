using DnDEncounterGenerator.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DnDEncounterGenerator.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonsterController : ControllerBase
    {
        private static DbCommands _dbCommands = new DbCommands();

        // GET: api/<MonsterController>
        [HttpGet]
        public IActionResult ViewAllMonstersWeb()
        {
            return Ok(_dbCommands.ViewAllMonstersWeb());
        }

        // GET api/<MonsterController>/5
        [HttpGet("{id}")]
        public string GetAllMonsters(int id)
        {
            return "value";
        }

        // POST api/<MonsterController>
        [HttpPost]
        public void PostMonster([FromBody]string value)
        {
        }

        // PUT api/<MonsterController>/5
        [HttpPut("{id}")]
        public void PutMonster(int id, [FromBody]string value)
        {
        }

        // DELETE api/<MonsterController>/5
        [HttpDelete("{id}")]
        public void DeleteMonster(int id)
        {
        }
    }
}
