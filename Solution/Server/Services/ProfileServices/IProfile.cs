using Solution.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.Server.Services.ProfileServices
{
    public interface IProfile
    {
        Task CreateProfile(Profile profile);
        Task UpdateProfile(Profile Old, Profile profile);
        Task<Profile> Profile(Guid GID);
    }
}
