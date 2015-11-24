using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Models;
using MvcApplication3.ViewModels;

namespace MvcApplication3.Controllers
{
    public class HomeController : Controller
    {
        private LikEntities db = new LikEntities();

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("de-AT");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-AT");
        }

        public ActionResult Index()
        {
            var model = new HomePage();
            model.NewRegistrations = db.Registrations.OrderByDescending(r => r.Date).Take(10).ToList();

            model.CoursesToBill = new List<Course>();
            foreach (var course in db.Courses)
            {
                if (course.BillDue != "")
                {
                    model.CoursesToBill.Add(course);
                }
            }

            model.OverdueInvoices = new List<Invoice>();

            var invoices = db.Invoices.Where(
                    i =>
                        i.DateCancellation == null &&
                        i.DateInvoice != null &&
                        i.DatePaid == null);
            foreach (var invoice in invoices)
            {
                if (invoice.DaysOverdue > 0)
                {
                    model.OverdueInvoices.Add(invoice);
                }
            }

            return View(model);
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
