using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class CourseRepository : EFRepository<Course>, ICourseRepository
	{
        public Course Find(int id)
        {
            return All().FirstOrDefault(c => c.CourseID == id);
        }

        public override IQueryable<Course> All()
        {
            return base.All().Where(p => p.Credits >= 1).OrderBy(p => p.CourseID);
        }
    }

	public  interface ICourseRepository : IRepository<Course>
	{

	}
}