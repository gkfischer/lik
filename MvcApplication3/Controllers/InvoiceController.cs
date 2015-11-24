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
    public class InvoiceController : Controller
    {
        private LikEntities db = new LikEntities();

        //
        // GET: /Invoice/

        public ActionResult Index()
        {
            var invoices = db.Invoices.Include(i => i.Registration);
            return View(invoices.ToList());
        }

        //
        // GET: /Invoice/Details/5

        public ActionResult Details(int id = 0)
        {
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        //
        // GET: /Invoice/Create

        public ActionResult Create()
        {
            ViewBag.RegistrationId = new SelectList(db.Registrations, "Id", "Remarks");
            return View();
        }

        //
        // POST: /Invoice/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegistrationId = new SelectList(db.Registrations, "Id", "Remarks", invoice.RegistrationId);
            return View(invoice);
        }

        //
        // GET: /Invoice/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegistrationId = new SelectList(db.Registrations, "Id", "Remarks", invoice.RegistrationId);
            return View(invoice);
        }

        //
        // POST: /Invoice/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegistrationId = new SelectList(db.Registrations, "Id", "Remarks", invoice.RegistrationId);
            return View(invoice);
        }

        //
        // GET: /Invoice/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        //
        // POST: /Invoice/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoices.Find(id);
            db.Invoices.Remove(invoice);
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