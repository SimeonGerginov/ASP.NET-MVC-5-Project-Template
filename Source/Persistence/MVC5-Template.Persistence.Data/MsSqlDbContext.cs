using Microsoft.AspNet.Identity.EntityFramework;
using MVC5_Template.Auth.Models;

namespace MVC5_Template.Persistence.Data
{
    public class MsSqlDbContext : IdentityDbContext<User>
    {
        public MsSqlDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }
    }
}
