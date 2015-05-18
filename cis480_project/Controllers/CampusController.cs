using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using cis480_project.Models;
using Microsoft.Ajax.Utilities;

namespace cis480_project.Controllers
{
    public class CampusController : Controller
    {
        private CampusDbContext db = new CampusDbContext();

        // GET: Campus
        public ActionResult Index()
        {
            return View(model: db.Campuses.ToList());
        }

        // GET: Campus/Details/5
        public ActionResult Details(int id) {
            //display 404 error if no campus with id exists
            Campus selectedCampus = db.Campuses.Find(id);
            if (selectedCampus == null) {
                return new HttpNotFoundResult();
            }
            return View(selectedCampus);
        }

        // GET: Campus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Campus/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                //create a campus with name from form
                //add it to db
                Campus campus = new Campus {Name = collection["Name"]};
                db.Campuses.Add(campus);
                db.SaveChanges();
                //create an alert for user feedback
                ViewBag.Alerts = new List<string>{String.Format("{0} campus has been created", campus.Name)};
                //go to campus/index
                return View("Index", model: db.Campuses);
            }
            catch
            {
                return View();
            }
        }

        // GET: Campus/Edit/5
        public ActionResult Edit(int id)
        {
            //display 404 error if no campus with id exists
            Campus selectedCampus = db.Campuses.Find(id);
            if (selectedCampus == null) {
                return new HttpNotFoundResult();
            }
            return View(selectedCampus);
        }

        // POST: Campus/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                //get the campus from db
                Campus campus = db.Campuses.Find(id);
                //edit the campus
                campus.Name = collection["Name"];
                db.SaveChanges();
                //create alert for user feedback
                ViewBag.Alerts = new List<string>{String.Format("{0} campus has been edited", campus.Name)};
                return View("Index", model: db.Campuses);
            }
            catch
            {
                return View();
            }
        }

        // GET: Campus/Delete/5
        public ActionResult Delete(int id)
        {
            //display 404 error if no campus with id exists
            Campus selectedCampus = db.Campuses.Find(id);
            if (selectedCampus == null) {
                return new HttpNotFoundResult();
            }
            return View(selectedCampus);
        }

        // POST: Campus/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                //find and delete the campus
                Campus campus = db.Campuses.Find(id);
                db.Campuses.Remove(campus);
                db.SaveChanges();
                //create alert for user feedback
                ViewBag.Alerts = new List<string>{String.Format("{0} campus has been deleted", campus.Name)};
                return View("Index", model: db.Campuses);
            }
            catch
            {
                return View();
            }
        }
    }
}
