using Solution.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.Client.ClientServices.Account
{
    public interface IAccountHttpRepo
    {
        Task<bool> CreateUser(Users user);
        Task<bool> CreateProfile(Profile profile);
        Task<List<Users>> Get();
        Task<List<Roles>> GetRoles();
        Task<Users> GetUser(Guid GID);
        Task<Profile> GetProfile(Guid GID);
        Task<bool> UpdateProfile(Guid GID, Users users);
        Task<bool> UpdateUser(Guid GID, Users users);
    }
}
