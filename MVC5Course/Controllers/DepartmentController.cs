using MVC5Course.Models;
using MVC5Course.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class DepartmentController : BaseController
    {
        private ContosoUniversityEntities db = new ContosoUniversityEntities();

        // GET: Department
        public ActionResult Index()
        {
            return View(db.Departments.Select(d => new DepartmentCreationVM()
            {
                DepartmentId = d.DepartmentID,
                Budget = d.Budget,
                Name = d.Name,
                StartDate = d.StartDate,
            }));
        }

        [HttpPost]
        public ActionResult Index(DepartmentBatchUpdateVM[] data)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var dept = db.Departments.Find(item.DepartmentId);
                    dept.Name = item.Name;
                    dept.Budget = item.Budget;
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(from p in db.Departments
                        select new DepartmentCreationVM()
                        {
                            DepartmentId = p.DepartmentID,
                            Name = p.Name,
                            Budget = p.Budget,
                            StartDate = p.StartDate
                        });
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