using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GilliandMIS4200.Models;

namespace GilliandMIS4200.DAL
{
    public class GilliandMIS4200Context : DbContext
    {
        public GilliandMIS4200Context() : base ("name=DefaultConnection")
        {

        }
        public DbSet<StudentCourse> studentCourses { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses { get; set; }
    }
}