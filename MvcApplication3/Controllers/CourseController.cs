using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Models;
using PagedList;

namespace MvcApplication3.Controllers
{
    public class CourseController : Controller
    {
        private LikEntities db = new LikEntities();

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("de-AT");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-AT");
        }

        //
        // GET: /Default1/

        //public ActionResult Index()
        //{

        //    return View(db.Courses.ToList());
        //}

        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder; 
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name";
            ViewBag.DateSortParm = sortOrder == "date" ? "date_desc" : "date";
            ViewBag.VenueSortParm = sortOrder == "venue" ? "venue_desc" : "venue";
            ViewBag.YearSortParm = sortOrder == "year" ? "year_desc" : "year";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var courses = from c in db.Courses
                select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(c => c.Name.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    courses = courses.OrderByDescending(c => c.Name);
                    break;
                case "date_desc":
                    courses = courses.OrderByDescending(c => c.Date);
                    break;
                case "date":
                    courses = courses.OrderBy(c => c.Date);
                    break;
                case "venue":
                    courses = courses.OrderBy(c => c.Venue);
                    break;
                case "venue_desc":
                    courses = courses.OrderByDescending(c => c.Venue);
                    break;
                case "year":
                    courses = courses.OrderBy(c => c.Year);
                    break;
                case "year_desc":
                    courses = courses.OrderByDescending(c => c.Year);
                    break;

                default:
                    courses = courses.OrderBy(c => c.Name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(courses.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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