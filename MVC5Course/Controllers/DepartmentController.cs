using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.ViewModels;

namespace MVC5Course.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DepartmentCreationVM data)
        {
            if (ModelState.IsValid)
            {
                // TODO
                return RedirectToAction("Index");
            }

            return View(data);
        }
    }
}