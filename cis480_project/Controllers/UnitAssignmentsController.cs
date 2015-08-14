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
	public class UnitAssignmentsController : Controller
	{
		private CourseDbContext db = new CourseDbContext();
		
	//Get UnitAssignments
	
	public ActionResult Index(int? courseId, int? assignmentId)
	{
		if (courseId == null || assignmentId == null)
		{
			return HttpNotFound();
		}
		
		var unitassignments = db.UnitAssignments.Where(UnitAssignment => UnitAssignment.Assignment.Id ==assignmentId);
		ViewBag.Assignment = db.Assignments.First(Assignment => Assignment.Id == assignmentId);
		ViewBag.Course = db.Courses.First(Course => Course.Id == courseId);
		return View(unitassignments.ToList());
	}
	
	//Get: UnitAssignments/Details/5
	
	public ActionResult Details(int? courseId, int? assignmentId,)
	}
}