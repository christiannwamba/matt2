using System;
using System.Collections.Generic;

using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MathewProject.Models;

namespace MathewProject.Controllers
{
    public class PriestController : Controller
    {
        private DiocesanDBEntities db = new DiocesanDBEntities();

        // GET: /Priest/
        public ActionResult Index()
        {
            var priests = db.Priests.Include(p => p.Cathedral);
            return View(priests.ToList());
        }

        // GET: /Priest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Priest priest = db.Priests.Find(id);
            if (priest == null)
            {
                return HttpNotFound();
            }
            return View(priest);
        }

        // GET: /Priest/Create
        public ActionResult Create()
        {
            ViewBag.CathedralID = new SelectList(db.Cathedrals, "CathedralID", "CathedralName");
            return View();
        }

        // POST: /Priest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PriestID,FirstName,LastName,DOB,State,LGA,CathedralID,YearOfOrdination")] Priest priest)
        {
            if (ModelState.IsValid)
            {
                db.Priests.Add(priest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CathedralID = new SelectList(db.Cathedrals, "CathedralID", "CathedralName", priest.CathedralID);
            return View(priest);
        }

        // GET: /Priest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Priest priest = db.Priests.Find(id);
            if (priest == null)
            {
                return HttpNotFound();
            }
            ViewBag.CathedralID = new SelectList(db.Cathedrals, "CathedralID", "CathedralName", priest.CathedralID);
            return View(priest);
        }

        // POST: /Priest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PriestID,FirstName,LastName,DOB,State,LGA,CathedralID,YearOfOrdination")] Priest priest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CathedralID = new SelectList(db.Cathedrals, "CathedralID", "CathedralName", priest.CathedralID);
            return View(priest);
        }

        // GET: /Priest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Priest priest = db.Priests.Find(id);
            if (priest == null)
            {
                return HttpNotFound();
            }
            return View(priest);
        }

        // POST: /Priest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Priest priest = db.Priests.Find(id);
            db.Priests.Remove(priest);
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
