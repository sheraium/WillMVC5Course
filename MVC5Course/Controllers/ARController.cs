using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return PartialView();
        }

        public ActionResult ContextTest()
        {
            return Content("123456789");
        }

        [Route("robots.txt")]
        public ActionResult Robots()
        {
            return Content(@"User-agent: bingbot
Disallow: /wp-admin/
Disallow: ^test*

sitemap: http://www.abc.com/sitemap.xml
");
        }

        public ActionResult FileTest(int dl = 0)
        {
            var file = Server.MapPath("~/Content/file.jpg");
            if (dl == 1)
            {
                return File(file, "image/jpeg", "Download.jpg");
            }
            else
            {
                return File(file, "image/jpeg", "Download.jpg");
            }
        }
    }
}