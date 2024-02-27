using DevFreela.Application.Commands.Skills;
using DevFreela.Application.Queries.Skills.GetAllSkills;
using DevFreela.Application.Queries.Skills.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    public class SkillController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillController(IMediator mediator)
        {
            _mediator = mediator;        
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllSkillsQuery();

            var skills = await _mediator.Send(query);

            return Ok(skills);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var query = new GetSkillByIdQuery(id);

            var skill = await _mediator.Send(query);

            if (skill == null) 
            {
                return BadRequest();
            }

            return Ok(skill);        
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSkillCommand command) 
        {
            if (command.Description.Length < 4 ) 
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { Id = id}, command);
        
        }
    }
}
