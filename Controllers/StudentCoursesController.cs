using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GilliandMIS4200.DAL;
using GilliandMIS4200.Models;

namespace GilliandMIS4200.Controllers
{
    public class StudentCoursesController : Controller
    {
        private GilliandMIS4200Context db = new GilliandMIS4200Context();

        // GET: StudentCourses
        public ActionResult Index()
        {
            var studentCourses = db.studentCourses.Include(s => s.course).Include(s => s.student);
            return View(studentCourses.ToList());
        }

        // GET: StudentCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourse studentCourse = db.studentCourses.Find(id);
            if (studentCourse == null)
            {
                return HttpNotFound();
            }
            return View(studentCourse);
        }

        // GET: StudentCourses/Create
        public ActionResult Create()
        {
            ViewBag.courseID = new SelectList(db.courses, "courseID", "courseName");
            ViewBag.studentID = new SelectList(db.students, "studentId", "firstName");
            return View();
        }

        // POST: StudentCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "studentCourseID,studentID,courseID,enrollmentDate")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                db.studentCourses.Add(studentCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.courseID = new SelectList(db.courses, "courseID", "courseName", studentCourse.courseID);
            ViewBag.studentID = new SelectList(db.students, "studentId", "firstName", studentCourse.studentID);
            return View(studentCourse);
        }

        // GET: StudentCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourse studentCourse = db.studentCourses.Find(id);
            if (studentCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.courseID = new SelectList(db.courses, "courseID", "courseName", studentCourse.courseID);
            ViewBag.studentID = new SelectList(db.students, "studentId", "firstName", studentCourse.studentID);
            return View(studentCourse);
        }

        // POST: StudentCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "studentCourseID,studentID,courseID,enrollmentDate")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.courseID = new SelectList(db.courses, "courseID", "courseName", studentCourse.courseID);
            ViewBag.studentID = new SelectList(db.students, "studentId", "firstName", studentCourse.studentID);
            return View(studentCourse);
        }

        // GET: StudentCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourse studentCourse = db.studentCourses.Find(id);
            if (studentCourse == null)
            {
                return HttpNotFound();
            }
            return View(studentCourse);
        }

        // POST: StudentCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentCourse studentCourse = db.studentCourses.Find(id);
            db.studentCourses.Remove(studentCourse);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
