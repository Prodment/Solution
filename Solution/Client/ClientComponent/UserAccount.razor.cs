using Microsoft.AspNetCore.Components;
using Solution.Client.ClientServices.Account;
using Solution.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.Client.ClientComponent
{
    public partial class UserAccount
    {
        [Inject]
        public IAccountHttpRepo repo { get; set; }

        public string ResponseMessage = "";

        public Users objuser = new Users();

        public List<Roles> lstroles = new List<Roles>();
        public Roles objroles = new Roles();

        public string RoleId { get; set; }

        protected async override Task OnInitializedAsync()
        {
            lstroles = await repo.GetRoles();
        }

        async Task<string> Save()
        {

            objroles.Id = int.Parse(RoleId);
            objuser.Roles = objroles;
            if (await repo.CreateUser(objuser))
            {
                ResponseMessage = "Saved";

                return ResponseMessage;
            };

            ResponseMessage = "Not Saved";
            return ResponseMessage;
        }
    }
}
