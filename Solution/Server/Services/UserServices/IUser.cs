using Solution.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.Server.Services.UserServices
{
    public interface IUser
    {
        Task CreateUser(Users user);
        Task UpdateUser(Users old, Users user);
        Task<Users> ReadUser(Guid GID);
        Task DeleteUser(Guid GID);
        Task<Roles> UserRole(int id);
        Task<List<Roles>> UsersRole();
        Task<List<Users>> ListUsers();
        Task<Users> Access(Users user);

    }
}
