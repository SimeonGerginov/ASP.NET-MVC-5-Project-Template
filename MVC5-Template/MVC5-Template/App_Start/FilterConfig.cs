using System.Web.Mvc;
using MVC5_Template.Infrastructure.Attributes;

namespace MVC5_Template.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new SaveChangesAttribute());
        }
    }
}
