using Microsoft.AspNetCore.Components.Authorization;
using Solution.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Solution.Client.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _http;

        public CustomAuthenticationStateProvider(HttpClient http)
        {
            _http = http;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            Users Details = await _http.GetFromJsonAsync<Users>("api/user/userstate");

            if (Details != null && Details.Email != null)
            {
                var claimEmail = new Claim(ClaimTypes.Name, Details.Email);
                var ClaimGid = new Claim(ClaimTypes.NameIdentifier, Convert.ToString(Details.GID));
                //var Role = new Claim(ClaimTypes.Role, Convert.ToString(Details.GID));

                //Create a claim idenetity
                var claimsIdentity = new ClaimsIdentity(new[] { claimEmail, ClaimGid }, "serverAuth");

                //Create claims principal
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                return new AuthenticationState(claimsPrincipal);
            }
            else
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }
    }
}