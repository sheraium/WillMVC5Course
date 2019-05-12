using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class CourseRepository : EFRepository<Course>, ICourseRepository
	{

	}

	public  interface ICourseRepository : IRepository<Course>
	{

	}
}