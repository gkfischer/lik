using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Models;
using MvcApplication3.ViewModels;

namespace MvcApplication3.Controllers
{
    public class HomeController : Controller
    {
        private LikEntities db = new LikEntities();

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            var stats =
                from registration in db.Registrations
                group registration by new
                {
                    registration.Course.Date,
                    registration.Course.Name,
                    registration.Course.Venue,
                    registration.Course.Year
                }
                    into courseGroup
                    orderby courseGroup.Key.Date
                    select new CourseStatistics()
                    {
                        Date = courseGroup.Key.Date,
                        Name = courseGroup.Key.Name,
                        Year = courseGroup.Key.Year,
                        Venue = courseGroup.Key.Venue,
                        NumberOfStudents = courseGroup.Count()
                    };


            return View(stats.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
