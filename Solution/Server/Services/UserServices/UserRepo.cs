using Microsoft.EntityFrameworkCore;
using Solution.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.Server.Services.UserServices
{
    public class UserRepo : IUser
    {
        private readonly ApplicationContextDb _context;
        public UserRepo(ApplicationContextDb context)
        {
            _context = context;
        }

        public Task<Users> Access(Users user) => _context.User.Include(a => a.Roles).FirstOrDefaultAsync(a => a.Email.Equals(user.Email) && a.Password.Equals(user.Password));
        

        public async Task CreateUser(Users user)
        {
            try
            {
                user.Password = "Solution@1";
                user.Created = DateTime.Now;
                //var role = await _context.Role.AsNoTracking().FirstOrDefaultAsync(a => a.Id.Equals(user.Roles.Id));
                //user.Roles = role;
                _context.Add(user);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
           
        }

        public async Task DeleteUser(Guid GID)
        {
            var user = await _context.User.FirstOrDefaultAsync(a => a.GID.Equals(GID));

            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        public Task<List<Users>> ListUsers() => _context.User.ToListAsync();


        public Task<Users> ReadUser(Guid GID) => _context.User.Include(a => a.Roles).Include(a => a.Profile).FirstOrDefaultAsync(a => a.GID.Equals(GID));
        

        public async Task UpdateUser(Users old, Users user)
        {
            old.Name = user.Name;
            old.Surname = user.Surname;
            old.Email = user.Email;
            old.Password = user.Password;
            old.Updated = DateTime.Now;
            old.Roles = await _context.Role.FirstOrDefaultAsync(a => a.Id.Equals(user.Roles.Id));

            await _context.SaveChangesAsync();
                
        }

        public async Task<Roles> UserRole(int id) => await _context.Role.FirstOrDefaultAsync(a => a.Equals(id));

        public async Task<List<Roles>> UsersRole() => await _context.Role.ToListAsync();
        
    }
}
