﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.ViewModels;

namespace MVC5Course.Controllers
{
    public class MBController : BaseController
    {
        // GET: MB
        public ActionResult Index(string key1, string key2)
        {
            ViewData["key1"] = key1;
            ViewBag.key2 = key2;
            
            ViewData.Model = "4";
            return View();
        }

        public ActionResult WriteTemp()
        {
            TempData["key3"] = "3";

            Session["key5"] = "5";

            return RedirectToAction("Index");
        }

        public ActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Test(DepartmentCreationVM form)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            //ModelState.Clear();
            //ModelState.Remove("Budget");
            //ModelState["Budget"].Errors.Clear();
            //ModelState["Budget"].Value.AttemptedValue;
            //ModelState.Add()
            foreach (var item in ModelState["Budget"].Errors)
            {
                //item.ErrorMessage;
            }
            //ModelState.AddModelError("Budget", "My ERROR");
            return View(form);
        }

        public ActionResult Test2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Test2(MyVM data)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(data);
        }
    }
}