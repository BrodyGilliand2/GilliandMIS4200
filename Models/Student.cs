using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GilliandMIS4200.Models
{
    public class Student
    {
        [Display(Name = "First Name")]
        public int studentId { get; set; }

        [Display (Name ="First Name")]
        [Required (ErrorMessage ="Student first name required")] 
        [StringLength(20)]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Student last name required")]
        [StringLength(20)]
        public string lastName { get; set; }
        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Student date of birth required")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime dateOfBirth { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Student address required")]
        [StringLength(100)]
        public string address { get; set; }
        public ICollection<StudentCourse> studentcourse { get; set; }
    }
}