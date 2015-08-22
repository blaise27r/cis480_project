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
	public class UnitController : Controller
	{
		private CourseDbContext db = new CourseDbContext();
		
		// GET: Unit
		public ActionResult (int? courseId)
		{
			if (courseId == null)
			{
				return HttpNotFound();
			}
			var queryResults = (from u in db.Units
				join ua in db.UnitAssignments on u.Id equals ua.UnitId
				join c in db.Courses on u.CourseId equals c.Id
				where c.Id == courseId
				select new {
					u
				}).Distinct();
				
			List<Unit> Units = new List<Unit>();
			foreach (var assignment in queryResults)
			{
				units.Add(unit.u);
			}
			
			ViewBag.Course = db.Courses.First(Course => Course.Id == courseId);
			
			 return View(assignments);
		}
		
		//GET: Unit/Details/5
		 public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            var queryResults = (
                from u in db.Units
                join ua in db.UnitAssignments on u.Id equals ua.UnitId
				join c in db.Courses on u.CourseId equals c.Id
				where u.Id == id
                select new {
                    ua
                }
            );
			  List<UnitAssignment> unitAssignments = new List<UnitAssignment>();
            foreach (var enablingObjective in queryResults) {
                UnitAssignments.Add(unitAssignments.ua);
            }
            ViewBag.UnitAssignments = unitAssignments;
            return View(unit);
		}
		
		   public ActionResult Create(int courseId)
        {
            //get all enabling objectives for this course for a select list
            var courseUnitAssignmentsQueryResult = (
                from ua in db.UnitAssignments
                join u in db.Units on u.UnitId equals u.Id
                join c in db.Courses on o.CourseId equals c.Id
                where c.Id == courseId
                select ua
            );
            //Pass the enbabling objectives for the course to the view
            ViewBag.CourseUnitAssignments = courseUnitAssignmentsQueryResult.ToList();
            return View();
        }
		// POST: Assignment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] Unit unit, int? courseId) {
            //create enablingObjIds 
            var unitAssignIds = GetUnitAssignIdsFromCheckboxes();
            if (unitAssignIds == null || unitAssignIds.Length == null) {
                //I need to add message to user here
                //cant add assignment without any enabling objectives
                var x = courseId;
                return View(unit);
            }

            if (ModelState.IsValid)
            {
                db.UnitAssignments.Add(unitAssignment);
                db.SaveChanges();
                //gets autoid of just added items
                int unitAssignmentId = unitAssignment.Id;
                //add row to AssignmentEnablingObjective for each enablingobjective selected
                foreach (var unitAssignmentId in unitAssignmentIds) {
                    UnitAssignment unitAssignment = new UnitAssignment {
                        UnitAssignmentId = unitassignmentId,
                        UnitAssignmentId = Int32.Parse(unitAssignId)
                    };
                    db.UnitAssignments.Add(unitAssignment);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(unit);
        }
         private string[] GetUnitAssignIdsFromCheckboxes() {
            string[] formKeys = new string[Request.Form.Keys.Count];
            string[] unitAssignIds = new string[formKeys.Length - 2];
            Request.Form.AllKeys.CopyTo(formKeys, 0);
            Array.Copy(formKeys, 2, unitAssignIds, 0, unitAssignIds.Length);
            return unitAssignIds;
        }

        // GET: Assignment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Assignment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unit);
        }

        // GET: Assignment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Assignment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unit assignment = db.Units.Find(id);
            db.Assignments.Remove(unit);
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
