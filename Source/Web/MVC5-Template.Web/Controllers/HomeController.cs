using System.Web.Mvc;

namespace MVC5_Template.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
