using System.Data.Entity;

using MVC5_Template.Persistence.Data;
using MVC5_Template.Persistence.Data.Migrations;

namespace MVC5_Template.Web.Infrastructure.Configs
{
    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MsSqlDbContext, Configuration>());
        }
    }
}
