using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using cis480_project.Models;
using Microsoft.Ajax.Utilities;

namespace cis480_project.Controllers
{
    public class AssignmentController : Controller
    {
        private CourseDbContext db = new CourseDbContext();

        // GET: Assignment
        public ActionResult Index(int courseId) {
            var queryResults = (from a in db.Assignments
                join aeo in db.AssignmentEnablingObjectives on a.Id equals aeo.AssignmentId
                join eo in db.EnablingObjectives on aeo.EnablingObjectiveId equals eo.Id
                join o in db.Objectives on eo.ObjectiveId equals o.Id
                join c in db.Courses on o.CourseId equals c.Id
                where c.Id == courseId
                select new {
                    a
                }).Distinct();

            List<Assignment> assignments = new List<Assignment>();
            foreach (var assignment in queryResults) {
                assignments.Add(assignment.a);
            }
            return View(assignments);
        }

        // GET: Assignment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            var queryResults = (
                from a in db.Assignments
                    join aoe in db.AssignmentEnablingObjectives on a.Id equals aoe.AssignmentId
                    join oe in db.EnablingObjectives on aoe.EnablingObjectiveId equals oe.Id
                    where a.Id == id
                select new {
                    oe
                }
            );
            List<EnablingObjective> enablingObjectives = new List<EnablingObjective>();
            foreach (var enablingObjective in queryResults) {
                enablingObjectives.Add(enablingObjective.oe);
            }
            ViewBag.EnablingObjectives = enablingObjectives;
            return View(assignment);
        }

        // GET: Assignment/Create
        public ActionResult Create(int courseId)
        {
            //get all enabling objectives for this course for a select list
            var courseEnablingObjectivesQueryResult = (
                from eo in db.EnablingObjectives
                join o in db.Objectives on eo.ObjectiveId equals o.Id
                join c in db.Courses on o.CourseId equals c.Id
                where c.Id == courseId
                select eo
            );
            //Pass the enbabling objectives for the course to the view
            ViewBag.CourseEnablingObjectives = courseEnablingObjectivesQueryResult.ToList();
            return View();
        }

        // POST: Assignment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] Assignment assignment, int? courseId) {
            //create enablingObjIds 
            var enablingObjIds = GetEnablingObjIdsFromCheckboxes();
            if (enablingObjIds == null || enablingObjIds.Length == null) {
                //I need to add message to user here
                //cant add assignment without any enabling objectives
                var x = courseId;
                return View(assignment);
            }

            if (ModelState.IsValid)
            {
                db.Assignments.Add(assignment);
                db.SaveChanges();
                //gets autoid of just added items
                int assignmentId = assignment.Id;
                //add row to AssignmentEnablingObjective for each enablingobjective selected
                foreach (var enablingObjId in enablingObjIds) {
                    AssignmentEnablingObjective assignmentEnablingObjective = new AssignmentEnablingObjective {
                        AssignmentId = assignmentId,
                        EnablingObjectiveId = Int32.Parse(enablingObjId)
                    };
                    db.AssignmentEnablingObjectives.Add(assignmentEnablingObjective);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(assignment);
        }

        private string[] GetEnablingObjIdsFromCheckboxes() {
            string[] formKeys = new string[Request.Form.Keys.Count];
            string[] enablingObjIds = new string[formKeys.Length - 2];
            Request.Form.AllKeys.CopyTo(formKeys, 0);
            Array.Copy(formKeys, 2, enablingObjIds, 0, enablingObjIds.Length);
            return enablingObjIds;
        }

        // GET: Assignment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // POST: Assignment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assignment);
        }

        // GET: Assignment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // POST: Assignment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assignment assignment = db.Assignments.Find(id);
            db.Assignments.Remove(assignment);
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
