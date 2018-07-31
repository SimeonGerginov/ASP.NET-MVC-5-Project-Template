using Microsoft.AspNet.Identity.EntityFramework;

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
