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
    public class ParishController : Controller
    {
        private DiocesanDBEntities db = new DiocesanDBEntities();

        // GET: /Parish/
        public ActionResult Index()
        {
            var parishes = db.Parishes.Include(p => p.Cathedral).Include(p => p.Priest);
            return View(parishes.ToList());
        }

        // GET: /Parish/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parish parish = db.Parishes.Find(id);
            if (parish == null)
            {
                return HttpNotFound();
            }
            return View(parish);
        }

        // GET: /Parish/Create
        public ActionResult Create()
        {
            ViewBag.CathedralID = new SelectList(db.Cathedrals, "CathedralID", "CathedralName");
            ViewBag.PriestID = new SelectList(db.Priests, "PriestID", "FirstName");
            return View();
        }

        // POST: /Parish/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ParishID,ParishName,Founded,Anthem,Location,CathedralID,PriestID")] Parish parish)
        {
            if (ModelState.IsValid)
            {
                db.Parishes.Add(parish);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CathedralID = new SelectList(db.Cathedrals, "CathedralID", "CathedralName", parish.CathedralID);
            ViewBag.PriestID = new SelectList(db.Priests, "PriestID", "FirstName", parish.PriestID);
            return View(parish);
        }

        // GET: /Parish/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parish parish = db.Parishes.Find(id);
            if (parish == null)
            {
                return HttpNotFound();
            }
            ViewBag.CathedralID = new SelectList(db.Cathedrals, "CathedralID", "CathedralName", parish.CathedralID);
            ViewBag.PriestID = new SelectList(db.Priests, "PriestID", "FirstName", parish.PriestID);
            return View(parish);
        }

        // POST: /Parish/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ParishID,ParishName,Founded,Anthem,Location,CathedralID,PriestID")] Parish parish)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parish).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CathedralID = new SelectList(db.Cathedrals, "CathedralID", "CathedralName", parish.CathedralID);
            ViewBag.PriestID = new SelectList(db.Priests, "PriestID", "FirstName", parish.PriestID);
            return View(parish);
        }

        // GET: /Parish/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parish parish = db.Parishes.Find(id);
            if (parish == null)
            {
                return HttpNotFound();
            }
            return View(parish);
        }

        // POST: /Parish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parish parish = db.Parishes.Find(id);
            db.Parishes.Remove(parish);
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
