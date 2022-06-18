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
    public class CouresController : Controller
    {
        private NLNEntities db = new NLNEntities();

        // GET: Coures
        public ActionResult Index()
        {
            return View(db.Coures.ToList());
        }

        // GET: Coures/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coure coure = db.Coures.Find(id);
            if (coure == null)
            {
                return HttpNotFound();
            }
            return View(coure);
        }

        // GET: Coures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Course_ID,Name,Toeic,Decriptoin,Account_ID,Cat_ID")] Coure coure)
        {
            if (ModelState.IsValid)
            {
                db.Coures.Add(coure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coure);
        }

        // GET: Coures/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coure coure = db.Coures.Find(id);
            if (coure == null)
            {
                return HttpNotFound();
            }
            return View(coure);
        }

        // POST: Coures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Course_ID,Name,Toeic,Decriptoin,Account_ID,Cat_ID")] Coure coure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coure);
        }

        // GET: Coures/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coure coure = db.Coures.Find(id);
            if (coure == null)
            {
                return HttpNotFound();
            }
            return View(coure);
        }

        // POST: Coures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Coure coure = db.Coures.Find(id);
            db.Coures.Remove(coure);
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
