using Microsoft.AspNetCore.Components;
using Solution.Client.ClientServices.Account;
using Solution.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.Client.ClientComponent
{
    public partial class CreateProfile
    {
        [Inject]
        public IAccountHttpRepo _repo { get; set; }

        [Parameter]
        public Guid ProfileGID { get; set; }

        Profile profile = new Profile();

        public List<Roles> roles = new List<Roles>();
        protected async override Task OnInitializedAsync()
        {
            roles = await _repo.GetRoles();
        }
    }
}
