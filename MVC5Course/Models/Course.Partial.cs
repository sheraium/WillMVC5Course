using System.Web.Mvc;
using MVC5Course.DataTypeAttributes;

namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CourseMetaData))]
    public partial class Course : IValidatableObject, IEditCourse
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Credits <=3 && Title.Length >10)
            {
                yield return new ValidationResult("當 Creadits <= 3 時， 課程名稱的長度不能超過 10 個字元", new []{"Credits","Title"});

            }
        }
    }
    public interface IEditCourse
    {
        int CourseID { get; set; }
        string Title { get; set; }
        int Credits { get; set; }
    }
    public partial class CourseMetaData
    {
        [Required]
        public int CourseID { get; set; }
        
        [驗證標題不允許出現特定文字(Words = new []{"Admin"})]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [AllowHtml]
        public string Title { get; set; }
        [Required]
        [Range(1,5, ErrorMessage = "1~5")]
        public int Credits { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Location { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
