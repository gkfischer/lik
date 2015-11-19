using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Models;

namespace MvcApplication3.Controllers
{
    public class RegistrationController : Controller
    {
        private LikEntities db = new LikEntities();

        //
        // GET: /Registration/

        public ActionResult Index()
        {
            var registrations = db.Registrations.Include(r => r.Course).Include(r => r.Person);
            return View(registrations.ToList());
        }

        public ActionResult IndexForPerson(int personId)
        {
            var person = db.People.Include(p => p.Registrations).First(p => p.Id == personId);
            return View(person);
        }

        public ActionResult IndexForCourse(int courseId)
        {
            var course = db.Courses.Include(p => p.Registrations).First(p => p.Id == courseId);
            return View(course);
        }

        //
        // GET: /Registration/Details/5

        public ActionResult Details(int id = 0)
        {
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        //
        // GET: /Registration/Create

        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Venue");
            ViewBag.PersonId = new SelectList(db.People, "Id", "FirstName");
            return View();
        }

        //
        // POST: /Registration/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Registrations.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Venue", registration.CourseId);
            ViewBag.PersonId = new SelectList(db.People, "Id", "FirstName", registration.PersonId);
            return View(registration);
        }

        //
        // GET: /Registration/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Venue", registration.CourseId);
            ViewBag.PersonId = new SelectList(db.People, "Id", "FirstName", registration.PersonId);
            return View(registration);
        }

        //
        // POST: /Registration/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Venue", registration.CourseId);
            ViewBag.PersonId = new SelectList(db.People, "Id", "FirstName", registration.PersonId);
            return View(registration);
        }

        //
        // GET: /Registration/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        //
        // POST: /Registration/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registration registration = db.Registrations.Find(id);
            db.Registrations.Remove(registration);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}