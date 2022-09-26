using Microsoft.AspNetCore.Mvc;

namespace rpgAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly DataContext _context;
        public SkillController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("AddSkill")]
        public async Task<ActionResult<List<Skill>>> AddSkill(AddSkillDto request)
        {

          Skill skill = new Skill
          {
              Name = request.Name,
              Damage = request.Damage
          };

          _context.Skills.Add(skill);
          await _context.SaveChangesAsync();
          return Ok(skill);
        }
    }
    
}