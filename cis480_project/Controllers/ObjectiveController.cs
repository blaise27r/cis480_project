using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cis480_project.Models;

namespace cis480_project.Controllers
{
    public class ObjectiveController : Controller
    {
        private CourseDbContext db = new CourseDbContext();

        // GET: couse/courseId/Objective
        public ActionResult Index(int? courseId)
        {
            if (courseId == null) {
                return HttpNotFound();
            }
            var objectives = db.Objectives.Where(Objective => Objective.CourseId == courseId);

            //Get the course name for page Header and id for breabcrumb
            ViewBag.Course = db.Courses.First(Course => Course.Id == courseId);
            return View(objectives.ToList());
        }

        // GET: couse/courseId/Objective/Details/objectiveId
        public ActionResult Details(int? courseId, int? objectiveId)
        {
            if (objectiveId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objective objective = db.Objectives.Find(objectiveId);
            if (objective == null)
            {
                return HttpNotFound();
            }
            objective.Course = db.Courses.Find(objective.CourseId);
            return View(objective);
        }

        // GET: couse/courseId/Objective/Create
        public ActionResult Create(int? courseId) {
            ViewBag.Course = db.Courses.Find(courseId);
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name");
            return View();
        }

        // POST: couse/courseId/Objective/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,CourseId")] Objective objective)
        {
            if (ModelState.IsValid)
            {
                db.Objectives.Add(objective);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", objective.CourseId);
            return View(objective);
        }

        // GET: couse/courseId/Objective/Edit/objectiveId
        public ActionResult Edit(int? courseId, int? objectiveId)
        {
            if (objectiveId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objective objective = db.Objectives.Find(objectiveId);
            if (objective == null)
            {
                return HttpNotFound();
            }
            objective.Course = db.Courses.Find(objective.CourseId);
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", objective.CourseId);
            return View(objective);
        }

        // POST: couse/courseId/Objective/Edit/objectiveId
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,CourseId")] Objective objective)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objective).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", objective.CourseId);
            return View(objective);
        }

        // GET: couse/courseId/Objective/Delete/objectiveId
        public ActionResult Delete(int? courseId, int? objectiveId)
        {
            if (objectiveId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objective objective = db.Objectives.Find(objectiveId);
            if (objective == null)
            {
                return HttpNotFound();
            }
            objective.Course = db.Courses.Find(objective.CourseId);
            return View(objective);
        }

        // POST: couse/courseId/Objective/Delete/objectiveId
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int courseId, int objectiveId)
        {
            Objective objective = db.Objectives.Find(objectiveId);
            db.Objectives.Remove(objective);
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
