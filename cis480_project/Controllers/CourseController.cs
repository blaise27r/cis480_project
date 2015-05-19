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
        private CampusDbContext db = new CampusDbContext();

        // GET: /Course/Index/campusId
        //courses at campus
        public ActionResult Index(int? id = null) {
            if (id == null) {
                return View(model: db.Courses.ToList());
            }
            else {
                ViewBag.Campus = db.Campuses.Find(id);
                return View(model: db.Courses.Where(Course => Course.CampusId == id));
            }
        }

        // GET: Course/Details/id
        public ActionResult Details(int id)
        {
            //404 error if user types in url with course that doesnt exist
            Course course = db.Courses.Find(id);
            if (course == null) {
                return new HttpNotFoundResult();
            }
            return View(model: course);
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

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
