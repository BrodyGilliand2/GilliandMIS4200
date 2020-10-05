using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GilliandMIS4200.Models
{
    public class StudentCourse
    {
        public int studentCourseID { get; set; }
        [Display (Name ="First Name")]
        public int studentID { get; set; }
        public int courseID { get; set; }
        [Display(Name = "Enrollment Date")]
        [Required(ErrorMessage = "Enrollment date required")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime enrollmentDate { get; set; }
        public virtual Student student { get; set; }
        public virtual Course course { get; set; }
    }
}