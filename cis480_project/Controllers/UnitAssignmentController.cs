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
	public class UnitAssignmentController : Controller
	{
		private CourseDbContext db = new CourseDbContext();
		
	//Get UnitAssignments
	
	public ActionResult Index(int? courseId, int? assignmentId)
	{
		if (courseId == null || assignmentId == null)
		{
			return HttpNotFound();
		}
		
		var unitAssignments = db.UnitAssignments.Where(UnitAssignment => UnitAssignment.Assignment.Id ==assignmentId);
		ViewBag.Assignment = db.Assignments.First(Assignment => Assignment.Id == assignmentId);
		ViewBag.Course = db.Courses.First(Course => Course.Id == courseId);
		return View(unitAssignments.ToList());
	}
	
	//Get: UnitAssignments/Details/5
	
	public ActionResult Details(int? courseId, int? unitId, int? unitAssignmentsId)
	{
		if (courseId == null || unitId == null || unitAssignmentsId == null)
		{
			return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		}
		UnitAssignment unitAssignment = db.UnitAssignments.Find(unitAssignmentsId);
		if (unitAssignment == null)
		{
			return HttpNotFound();
		}
		ViewBag.Unit = db.Units.First(Unit => Unit.Id == unitId);
		ViewBag.Course = db.Courses.First(Course => Course.Id == courseId);
		return View(unitAssignmentsId);
	}
	
	//Get: UnitAssignments/Create
	
	public ActionResult Create(int? courseId, int? unitId)
	{
		ViewBag.UnitId = new SelectList(db.Units, "Id", "Description");
		ViewBag.Unit = db.Units.First(Unit => Unit.Id == unitId);
		ViewBag.Course = db.Courses.First(Course => Course.Id == courseId);
		return View();
	}
	 // POST: UnitAssignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
	}
}