using Microsoft.AspNetCore.Components;
using Solution.Client.ClientServices.Account;
using Solution.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.Client.ClientComponent
{
    public partial class Profile
    {
        [Inject]
        public IAccountHttpRepo _Repo { get; set; }

        [Parameter]
        public Guid ProfileGID { get; set; }

        [Parameter]
        public Profile objProfile { get; set; }


    }
}
