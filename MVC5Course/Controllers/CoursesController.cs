using MVC5Course.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    [RoutePrefix("courses")]
    public class CoursesController : BaseController
    {
        private CourseRepository courseRepo;
        private DepartmentRepository deptRepo;

        public CoursesController()
        {
            courseRepo = RepositoryHelper.GetCourseRepository();
            deptRepo = RepositoryHelper.GetDepartmentRepository(courseRepo.UnitOfWork);
        }

        // GET: Courses
        [Route("")]
        public ActionResult Index()
        {
            var courses = courseRepo.All();
            return View(courses.ToList());
        }

        // GET: Courses/Details/5
        [Route("{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = courseRepo.Find(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        [Route("create")]
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(deptRepo.All(), "DepartmentID", "Name");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create")]
        public ActionResult Create([Bind(Include = "CourseID,Title,Credits,DepartmentID,Location")] Course course)
        {
            if (ModelState.IsValid)
            {
                courseRepo.Add(course);
                courseRepo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(deptRepo.All(), "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        // GET: Courses/Edit/5
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = courseRepo.Find(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(deptRepo.All(), "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{id}")]
        public ActionResult Edit(int id, FormCollection form)
        {
            var course = courseRepo.Find(id);
            if (TryUpdateModel<IEditCourse>(course) && TryValidateModel(course))
            {
                courseRepo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            //if (ModelState.IsValid)
            //{
            //    courseRepo.UnitOfWork.Context.Entry(course).State = EntityState.Modified;
            //    courseRepo.UnitOfWork.Commit();
            //    return RedirectToAction("Index");
            //}
            ViewBag.DepartmentID = new SelectList(deptRepo.All(), "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        // GET: Courses/Delete/5
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = courseRepo.Find(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = courseRepo.Find(id);
            courseRepo.Delete(course);
            courseRepo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

#if !DEBUG
        [NonAction]
#endif

        [OutputCache(NoStore = true, Duration = 0)]
        [Route("debug")]
        public ActionResult Debug()
        {
            return Json(new { OK = 1 }, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                courseRepo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}