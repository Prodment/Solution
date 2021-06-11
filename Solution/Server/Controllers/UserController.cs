using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution.Server.Services.UserServices;
using Solution.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Solution.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        
        [HttpGet]
      
        public async Task<IActionResult> Get()
        {
            var users = await _user.ListUsers();

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Users user)
        {
            await _user.CreateUser(user);

            return Created("",user);
        }
        [HttpPost("account/login")]
        public async Task<ActionResult<Users>> GetAccess([FromBody] Users user)
        {
            var details = await _user.Access(user);
            if(details != null)
            {
                var Email = new Claim(ClaimTypes.Name, details.Email);
                var GID = new Claim(ClaimTypes.NameIdentifier, Convert.ToString(details.GID));
                var Role = new Claim(ClaimTypes.Role, details.Roles.DescriptionType);
                var Identity = new ClaimsIdentity(new[] { Email, GID, Role }, "serverAuth");
                var Principal = new ClaimsPrincipal(Identity);

                await HttpContext.SignInAsync(Principal);
            }

            return await Task.FromResult(details);
        }

        [HttpPut("{GID}")]
        public async Task<IActionResult> Update(Guid GID, Users user)
        {
            var found = await _user.ReadUser(GID);
            if (found == null)
                return NotFound();

            await _user.UpdateUser(found, user);

            return NoContent();

        }

        [HttpGet("userstate")]
        public async Task<ActionResult<Users>> UserState()
        {
            Users user = new Users();
            Roles role = new Roles();
            if (User.Identity.IsAuthenticated)
            {
                role.DescriptionType = (User.FindFirstValue(ClaimTypes.Role));
                user.Roles = role;
                user.Email = User.FindFirstValue(ClaimTypes.Name);
                user.GID = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                
                
            }
               

            return await Task.FromResult(user);
        }

        [HttpGet("{GID}")]
        public async Task<IActionResult> Find(Guid GID)
        {
            var user = await _user.ReadUser(GID);

            return Ok(user);
        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _user.UsersRole();

            return Ok(roles);
        }
    }
}
