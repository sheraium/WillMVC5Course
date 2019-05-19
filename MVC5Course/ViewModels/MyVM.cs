using System.ComponentModel.DataAnnotations;

namespace MVC5Course.ViewModels
{
    public class MyVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Count { get; set; }
    }
}