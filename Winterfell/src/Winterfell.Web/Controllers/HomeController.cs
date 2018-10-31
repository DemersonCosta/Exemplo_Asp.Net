using System.Web.Mvc;
using Winterfell.Web.Infra.Controllers;

namespace Winterfell.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}