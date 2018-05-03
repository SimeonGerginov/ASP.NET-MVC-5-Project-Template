using System.Collections.Generic;

using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace MVC5_Template.Core.ViewModels.Manage
{
    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }
}
