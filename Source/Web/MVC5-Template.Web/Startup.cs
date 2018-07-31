using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5_Template.Web.Startup))]
namespace MVC5_Template.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
