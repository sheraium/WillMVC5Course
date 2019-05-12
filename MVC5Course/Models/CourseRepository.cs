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
    }

	public  interface ICourseRepository : IRepository<Course>
	{

	}
}