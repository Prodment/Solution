using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution.Server.Services.ProfileServices;
using Solution.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionPP.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfile _repo;
        public ProfileController(IProfile repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Profile profile)
        {
            await _repo.CreateProfile(profile);

            return Created("", profile);
        }
        [HttpPut("{GID}")]
        public async Task<IActionResult> Update(Guid GID, Profile profile)
        {
            var found = await _repo.Profile(GID);
            if (found == null)
                return NotFound();

            await _repo.UpdateProfile(found, profile);

            return NoContent();

        }

        [HttpGet("{GID}")]
        public async Task<IActionResult> Find(Guid GID)
        {
            var user = await _repo.Profile(GID);

            return Ok(user);
        }
    }
}
