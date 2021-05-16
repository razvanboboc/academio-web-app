using Academio.DTOs.DTOs;
using Academio.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Academio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]UserDto userDto)
        {

            var sessionModel = await _userService.Authenticate(userDto);
            if (sessionModel is null)
            {
                return StatusCode(401, "Email Address or password is invalid");
            }
            return Ok(sessionModel);

        }

        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(UserDto userDto)
        {
            var user = await _userService.Add(userDto);
            return Ok(user);
        }

        //[Authorize(Roles = "Administrator, User")]
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult> Get(int id)
        {
            var data = await _userService.Get(id);
            return Ok(data);
        }

        //[Authorize(Roles = "Administrator, User")]
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult> GetAll()
        {
            var data = await _userService.GetAll();
            return Ok(data);
        }
       
        //[Authorize(Roles = "Administrator")]
        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _userService.Delete(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> Update(UserDto userDto)
        {

            var user = await _userService.Update(userDto);
            return Ok(user);
        }

        //[Authorize(Roles = "Administrator, User")]
        [HttpPut]
        [Route("changeAccountPreferences")]
        public async Task<ActionResult> ChangeAccountPreferences(UserDto userDto)
        {

            var user = await _userService.ChangeAccountPreferences(userDto);
            return Ok(user);
        }
    }
}
