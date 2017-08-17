using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using MileageTracker.Models;



namespace MileageTracker.Controllers
{
    public class RunsController : Controller
    {
        private RunDBContext db = new RunDBContext();

        // GET: Runs
        public ActionResult Index()
        {
            return View(db.Runs.ToList());
        }

        // GET: Runs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Run run = db.Runs.Find(id);
            if (run == null)
            {
                return HttpNotFound();
            }
            return View(run);
        }

        // GET: Runs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Runs/Create

        public ActionResult Create([Bind(Include = "ID,Mileage,RunDate")] Run run)
        {
            if (ModelState.IsValid)
            {
                db.Runs.Add(run);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(run);
        }

        // GET: Runs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Run run = db.Runs.Find(id);
            if (run == null)
            {
                return HttpNotFound();
            }
            return View(run);
        }

        // POST: Runs/Edit/5

        public ActionResult Edit([Bind(Include = "ID,Mileage,RunDate")] Run run)
        {
            if (ModelState.IsValid)
            {
                db.Entry(run).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(run);
        }

        // GET: Runs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Run run = db.Runs.Find(id);
            if (run == null)
            {
                return HttpNotFound();
            }
            return View(run);
        }

        // POST: Runs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Run run = db.Runs.Find(id);
            db.Runs.Remove(run);
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
