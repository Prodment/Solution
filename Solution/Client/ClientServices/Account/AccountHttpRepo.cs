using Solution.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Solution.Client.ClientServices.Account
{
    public class AccountHttpRepo : IAccountHttpRepo
    {
        private readonly HttpClient _http;

        public HttpResponseMessage response = new HttpResponseMessage();
      
        public string result = "";

        public AccountHttpRepo(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> CreateProfile(Profile profile)
        {
            var response = await _http.PostAsJsonAsync("api/profile", profile);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> CreateUser(Users user)
        {
           
           
            response = await _http.PostAsJsonAsync("api/user", user);
            result = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(result);
            }

            return true;
        }

        public async Task<List<Users>> Get()
        {
            var response = await _http.GetAsync("api/user");
            var result = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var users = JsonSerializer.Deserialize<List<Users>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return users;
           
            }

            throw new ApplicationException(result);
        }

        public async Task<Profile> GetProfile(Guid GID)
        {
            var response = await _http.GetAsync($"api/user/{GID}");
            var result = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var user = JsonSerializer.Deserialize<Profile>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return user;
            }

            throw new ApplicationException(result); 
        }

        public async Task<List<Roles>> GetRoles()
        {
            var response = await _http.GetAsync("api/user/getroles");
            var result = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var roles = JsonSerializer.Deserialize<List<Roles>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return roles;

            }

            throw new ApplicationException(result);
        }

        public async Task<Users> GetUser(Guid GID)
        {
            var response = await _http.GetAsync($"api/user/{GID}");
            var result = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var user = JsonSerializer.Deserialize<Users>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return user;
            }

            throw new ApplicationException(result);
        }

        public Task<bool> UpdateProfile(Guid GID, Users users)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUser(Guid GID, Users users)
        {
            var url = Path.Combine("api/user/" + GID.ToString());
            var response = await _http.PutAsJsonAsync(url, users);
            var result = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode) {

                return true; 
            }

            throw new ApplicationException(result);
        }
    }
}
