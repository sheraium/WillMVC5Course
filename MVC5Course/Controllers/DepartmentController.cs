﻿using MVC5Course.Models;
using MVC5Course.ViewModels;
using System.Linq;
using System.Web.Mvc;
using MVC5Course.ActionFilters;

namespace MVC5Course.Controllers
{
    public class DepartmentController : BaseController
    {
        private ContosoUniversityEntities db = new ContosoUniversityEntities();

        // GET: Department
        [取得Department清單]
        public ActionResult Index()
        {
            return View(ViewBag.DepartmentList);
        }

        [HttpPost]
        [取得Department清單]
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

            return View(ViewBag.DepartmentList);
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

        public ActionResult Detail(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            var dept = db.Departments.Find(id.Value);
            return View(dept);
        }
    }
}