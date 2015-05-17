using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cis480_project.Models;

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

                return RedirectToAction("Index");
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

                return RedirectToAction("Index");
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

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
