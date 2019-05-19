using System.Linq;
using System.Web.Mvc;
using MVC5Course.Models;
using MVC5Course.ViewModels;

namespace MVC5Course.ActionFilters
{
    public class 取得Department清單Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            using (var db = new ContosoUniversityEntities())
            {
                filterContext.Controller.ViewBag.DepartmentList
                    = (from p in db.Departments
                        select new DepartmentCreationVM()
                        {
                            DepartmentId = p.DepartmentID,
                            Name = p.Name,
                            Budget = p.Budget,
                            StartDate = p.StartDate
                        }).ToList();
            }
                

            base.OnActionExecuting(filterContext);
        }
    }
}