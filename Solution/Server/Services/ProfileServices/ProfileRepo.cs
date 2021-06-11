using Microsoft.EntityFrameworkCore;
using Solution.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.Server.Services.ProfileServices
{
    public class ProfileRepo : IProfile
    {
        private readonly ApplicationContextDb _context;

        public ProfileRepo(ApplicationContextDb context)
        {
            _context = context;
        }
        public async Task CreateProfile(Profile profile)
        {
            profile.Created = DateTime.Now;
            _context.Add(profile);
            await _context.SaveChangesAsync();
        }

        public async Task<Profile> Profile(Guid GID) => await _context.Profile.FirstOrDefaultAsync(a => a.GID.Equals(GID));
       

        public async Task UpdateProfile(Profile Old, Profile profile)
        {

            Old = profile;
            Old.Updated = DateTime.Now;

            await _context.SaveChangesAsync();
        }
    }
}
