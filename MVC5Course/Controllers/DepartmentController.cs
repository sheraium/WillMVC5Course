using MVC5Course.Models;
using MVC5Course.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class DepartmentController : Controller
    {
        private ContosoUniversityEntities db = new ContosoUniversityEntities();

        // GET: Department
        public ActionResult Index()
        {
            return View(db.Departments.Select(d => new DepartmentCreationVM()
            {
                Budget = d.Budget,
                Name = d.Name,
                StartDate = d.StartDate,
            }));
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
                db.Departments.Add(new Department()
                {
                    Budget = data.Budget,
                    Name = data.Name,
                    StartDate = data.StartDate,
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(data);
        }
    }
}