using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MetroController : Controller
    {
        // GET: Metro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Messages()
        {
            return View();
        }
    }
}