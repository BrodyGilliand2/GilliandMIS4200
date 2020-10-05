using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GilliandMIS4200.Models
{
    public class Course
    {
        [Display(Name = "Course Name")]
        public int courseID { get; set; }
        [Display (Name ="Course Name")]
        [Required(ErrorMessage = "Course name required")]
        [StringLength(20)]
        public string courseName { get; set; }
        [Display(Name = "Course Description")]
        [Required(ErrorMessage = "Course description required")]
        [StringLength(5000)]
        public string description { get; set; }
        [Display(Name = "Credit Hours")]
        [Required(ErrorMessage = "Credit hours required - Please enter X.00 to describe the course credit hours")]
        public decimal creditHours { get; set; }
        public ICollection<StudentCourse> studentcourse { get; set; }

    }
}