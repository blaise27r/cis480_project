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
        // GET: Course
        public ActionResult Index() {
            List<Course> courses = new List<Course>();
            courses.Add(new Course {name = "intro to programming", designator = "cis100"});
            courses.Add(new Course {name = "programming 2", designator = "cis200"});
            return View(model: courses);
        }

        // GET: Course/Details/5
        public ActionResult Details(string id)
        {
            List<Course> courses = new List<Course>();
            courses.Add(new Course { name = "intro to programming", designator = "cis100" });
            courses.Add(new Course { name = "programming 2", designator = "cis200" });
            Course selectedCourse = null;
            foreach (Course course in courses) {
                if (course.designator == id) {
                    selectedCourse = course;
                }
            }
            if (selectedCourse == null) {
                return new HttpNotFoundResult();
            }
            else {
                return View(model: selectedCourse);
            }
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
            return View();
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
