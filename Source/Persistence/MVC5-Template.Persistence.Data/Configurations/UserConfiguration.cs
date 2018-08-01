using System.Data.Entity.ModelConfiguration;
using MVC5_Template.Auth.Models;

namespace MVC5_Template.Persistence.Data.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.HasIndex(u => u.IsDeleted).IsUnique();
        }
    }
}
