using Solution.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.Client.ClientServices.Login
{
    public interface ILoginHttpRepo
    {
        Task<bool> Login(Users user);
    }
}
