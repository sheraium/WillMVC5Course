using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        [Route("robos.txt")]
        public ActionResult Robots()
        {
            return Content(@"User-agent: bingbot
Disallow: /wp-admin/
Disallow: ^test*

sitemap: http://www.abc.com/sitemap.xml
");
        }
    }
}