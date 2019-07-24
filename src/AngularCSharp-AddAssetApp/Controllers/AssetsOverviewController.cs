using System.Web.Mvc;

namespace AngularCSharp_AddAssetApp.Controllers
{
    public class AssetsOverviewController : Controller
    {
        public ActionResult Index()
        {
            return View("Overview");
        }
    }
}