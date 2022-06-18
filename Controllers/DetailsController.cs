using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASM.Models;

namespace ASM.Controllers
{
    public class DetailsController : Controller
    {
        private NLNEntities db = new NLNEntities();

        // GET: Details
        public ActionResult Index()
        {
            var details = db.Details.Include(d => d.Coure).Include(d => d.Student);
            return View(details.ToList());
        }

        // GET: Details/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail detail = db.Details.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }

        // GET: Details/Create
        public ActionResult Create()
        {
            ViewBag.Coures_ID = new SelectList(db.Coures, "Course_ID", "Name");
            ViewBag.Student_ID = new SelectList(db.Students, "Students_ID", "Name");
            return View();
        }

        // POST: Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Detail_ID,Coures_ID,Student_ID")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                db.Details.Add(detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Coures_ID = new SelectList(db.Coures, "Course_ID", "Name", detail.Coures_ID);
            ViewBag.Student_ID = new SelectList(db.Students, "Students_ID", "Name", detail.Student_ID);
            return View(detail);
        }

        // GET: Details/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail detail = db.Details.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.Coures_ID = new SelectList(db.Coures, "Course_ID", "Name", detail.Coures_ID);
            ViewBag.Student_ID = new SelectList(db.Students, "Students_ID", "Name", detail.Student_ID);
            return View(detail);
        }

        // POST: Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Detail_ID,Coures_ID,Student_ID")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Coures_ID = new SelectList(db.Coures, "Course_ID", "Name", detail.Coures_ID);
            ViewBag.Student_ID = new SelectList(db.Students, "Students_ID", "Name", detail.Student_ID);
            return View(detail);
        }

        // GET: Details/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail detail = db.Details.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Detail detail = db.Details.Find(id);
            db.Details.Remove(detail);
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
