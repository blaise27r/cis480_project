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
    public class EnablingObjectiveController : Controller
    {
        private CourseDbContext db = new CourseDbContext();

        // GET: EnablingObjective
        public ActionResult Index(int? courseId, int? objectiveId)
        {
            var enablingObjectives = db.EnablingObjectives.Where(EnablingObjective => EnablingObjective.ObjectiveId == objectiveId);
            ViewBag.Objective = db.Objectives.First(Objective => Objective.Id == objectiveId);
            ViewBag.Course = db.Courses.First(Course => Course.Id == courseId);
            return View(enablingObjectives.ToList());
        }

        // GET: EnablingObjective/Details/5
        public ActionResult Details(int? courseId, int? objectiveId, int? enablingObjectiveId)
        {
            if (courseId == null || objectiveId == null || enablingObjectiveId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnablingObjective enablingObjective = db.EnablingObjectives.Find(enablingObjectiveId);
            if (enablingObjective == null)
            {
                return HttpNotFound();
            }
            ViewBag.Objective = db.Objectives.First(Objective => Objective.Id == objectiveId);
            ViewBag.Course = db.Courses.First(Course => Course.Id == courseId);
            return View(enablingObjective);
        }

        // GET: EnablingObjective/Create
        public ActionResult Create(int? courseId, int? objectiveId )
        {
            ViewBag.ObjectiveId = new SelectList(db.Objectives, "Id", "Description");
            ViewBag.Objective = db.Objectives.First(Objective => Objective.Id == objectiveId);
            ViewBag.Course = db.Courses.First(Course => Course.Id == courseId);
            return View();
        }

        // POST: EnablingObjective/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,ObjectiveId")] EnablingObjective enablingObjective)
        {
            if (ModelState.IsValid)
            {
                db.EnablingObjectives.Add(enablingObjective);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ObjectiveId = new SelectList(db.Objectives, "Id", "Description", enablingObjective.ObjectiveId);
            return View(enablingObjective);
        }

        // GET: EnablingObjective/Edit/5
        public ActionResult Edit(int? courseId, int? objectiveId, int? enablingObjectiveId)
        {
            if (courseId == null || objectiveId == null || enablingObjectiveId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnablingObjective enablingObjective = db.EnablingObjectives.Find(enablingObjectiveId);
            if (enablingObjective == null)
            {
                return HttpNotFound();
            }
            ViewBag.ObjectiveId = new SelectList(db.Objectives, "Id", "Description", enablingObjective.ObjectiveId);
            ViewBag.Objective = db.Objectives.First(Objective => Objective.Id == objectiveId);
            ViewBag.Course = db.Courses.First(Course => Course.Id == courseId);
            return View(enablingObjective);
        }

        // POST: EnablingObjective/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,ObjectiveId")] EnablingObjective enablingObjective)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enablingObjective).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ObjectiveId = new SelectList(db.Objectives, "Id", "Description", enablingObjective.ObjectiveId);
            return View(enablingObjective);
        }

        // GET: EnablingObjective/Delete/5
        public ActionResult Delete(int? courseId, int? objectiveId, int? enablingObjectiveId)
        {
            if (courseId == null || objectiveId == null || enablingObjectiveId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnablingObjective enablingObjective = db.EnablingObjectives.Find(enablingObjectiveId);
            if (enablingObjective == null)
            {
                return HttpNotFound();
            }
            ViewBag.Objective = db.Objectives.First(Objective => Objective.Id == objectiveId);
            ViewBag.Course = db.Courses.First(Course => Course.Id == courseId);
            return View(enablingObjective);
        }

        // POST: EnablingObjective/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? courseId, int? objectiveId, int? enablingObjectiveId)
        {
            EnablingObjective enablingObjective = db.EnablingObjectives.Find(enablingObjectiveId);
            db.EnablingObjectives.Remove(enablingObjective);
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
