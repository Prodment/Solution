using Microsoft.AspNetCore.Components;
using Solution.Client.ClientServices.Login;
using Solution.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.Client.Pages
{
    public partial class Login
    {
        [Inject]
        public ILoginHttpRepo _httpRepo { get; set; }

        [Inject]
        NavigationManager Navigation { get; set; }

        public string Response = "";

        public Users user = new Users();

        async Task<string> UserLogin()
        {
            if (await _httpRepo.Login(user))
            {
                Navigation.NavigateTo("/");
            }
                

            return Response = "Incorrect Credentials";
        }
    }
}
