using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cis480_project.Models;

namespace cis480_project.Controllers
{
    public class CourseController : Controller
    {
        private CourseDbContext db = new CourseDbContext();

        // GET: /Course/Index/campusId - courses at campus 
        // GET: /Course/Index - all courses
        // GET: /Course/ - all courses
        //This is a hack to overload the Index method since .NET does not allow controller actions (methods) to be overloaded
        //What group of idiots made this framework? // 
        //courses at campus with parameter; all courses without parameter
        public ActionResult Index() {
            return View(model: db.Courses.ToList());
        }

        // GET: Course/Details/id
        public ActionResult Details(int id)
        {
            //404 error if user types in url with course that doesnt exist
            Course course = db.Courses.Find(id);
            if (course == null) {
                return new HttpNotFoundResult();
            }
            //set the campus for the course object so it can be displayed in the view
            return View(model: course);
        }

        // GET: Course/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            System.Diagnostics.Debug.WriteLine(collection.ToString());
            try
            {
                // TODO: Add insert logic here
                Course course = new Course {
                    Name = collection["Name"],
                    Designator = collection["Designator"],
                };
                db.Courses.Add(course);
                //Add units 1 - 5 for the new course
                for (int weekNumber = 1; weekNumber <= 5; weekNumber++) {
                    Unit unit = new Unit {
                        WeekNumber = weekNumber,
                        CourseId = course.Id
                    };
                    db.Units.Add(unit);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            //404 error if user types in url with course that doesnt exist
            Course course = db.Courses.Find(id);
            if (course == null) {
                return new HttpNotFoundResult();
            }
            return View(model: course);
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Course course = db.Courses.Find(id);
                if (course.Name != collection["Name"]) course.Name = collection["Name"];
                if (course.Designator != collection["Designator"]) course.Designator = collection["Designator"];
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            //404 error if user types in url with course that doesnt exist
            Course course = db.Courses.Find(id);
            if (course == null) {
                return new HttpNotFoundResult();
            }
            return View(model: course);
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Course course = db.Courses.Find(id);
                db.Courses.Remove(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
