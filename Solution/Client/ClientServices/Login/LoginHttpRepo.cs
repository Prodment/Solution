using Solution.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Solution.Client.ClientServices.Login
{
    public class LoginHttpRepo : ILoginHttpRepo
    {
        private readonly HttpClient _http;
        public LoginHttpRepo(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> Login(Users user)
        {
            var response = await _http.PostAsJsonAsync("api/user/account/login", user);
            var result = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {

                throw new ApplicationException(result);
            }
            if(result == "")
               return false;

            return true;
        }
    }
}
