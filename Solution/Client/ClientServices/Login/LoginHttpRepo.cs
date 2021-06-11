using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Solution.Client.Authentication;
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
        private readonly AuthenticationStateProvider _customAuthenticationProvider;
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _http;
        public LoginHttpRepo(ILocalStorageService localStorageService,
    AuthenticationStateProvider customAuthenticationProvider,
    HttpClient http)
        {
            _localStorageService = localStorageService;
            _customAuthenticationProvider = customAuthenticationProvider;
            _http = http;
        }

        public async Task<bool> Login(Users user)
        {
            var response = await _http.PostAsJsonAsync<Users>("api/user/account/login", user);
          

            if (!response.IsSuccessStatusCode)
            {

                throw new ApplicationException();
            }
           
            try
            {
                AuthResponse authData = await response.Content.ReadFromJsonAsync<AuthResponse>();
                await _localStorageService.SetItemAsync("token", authData.Token);
                (_customAuthenticationProvider as CustomAuthenticationStateProvider).Notify();
                return true;
            }
            catch(Exception e)
            {
                throw new ApplicationException(e.Message);
            }
           

            
        }
    }
}
