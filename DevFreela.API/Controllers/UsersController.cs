using DevFreela.API.Models;
using DevFreela.Application.InputModels.User;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    [Authorize]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] CreateUserInputModel inputModel)
        {
            if (!ModelState.IsValid) 
            {
                var messages = ModelState.SelectMany(ms => ms.Value.Errors)
                                         .Select(e => e.ErrorMessage)
                                         .ToList();

                return BadRequest(messages);
            }

            var id = _userService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { Id = 1 }, inputModel);
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginInputModel loginInputModel)
        {
            var loginUserViewModel = await _userService.Login(loginInputModel);

            if (loginUserViewModel == null) 
            {
                return BadRequest();
            }

            return Ok(loginUserViewModel);
        }
    }
}
