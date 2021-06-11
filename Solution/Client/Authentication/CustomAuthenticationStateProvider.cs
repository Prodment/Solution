using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Solution.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using static Solution.Client.Authentication.Helper;

namespace Solution.Client.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorageService;

        public CustomAuthenticationStateProvider(HttpClient http, ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
            _http = http;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await _localStorageService.GetItemAsync<string>("token");
            if (string.IsNullOrEmpty(token))
            {
                var anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity() { }));
                return anonymous;
            }
            var userClaimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "Fake Authentication"));
            var loginUser = new AuthenticationState(userClaimPrincipal);

            //Users Details = await _http.GetFromJsonAsync<Users>("api/user/userstate");

            //if (Details != null && Details.Email != null)
            //{
            //    var claimEmail = new Claim(ClaimTypes.Name, Details.Email);
            //    var ClaimGid = new Claim(ClaimTypes.NameIdentifier, Convert.ToString(Details.GID));
            //    var Role = new Claim(ClaimTypes.Role, Convert.ToString(Details.Roles.DescriptionType));

            //    //Create a claim idenetity
            //    var claimsIdentity = new ClaimsIdentity(new[] { claimEmail, ClaimGid,Role }, "serverAuth");

            //    //Create claims principal
            //    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            //    return new AuthenticationState(claimsPrincipal);
            //}
            //else
            //{
            //    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            //}

            return loginUser;
        }
        public void Notify()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}