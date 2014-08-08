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
    public class CathedralController : Controller
    {
        private DiocesanDBEntities db = new DiocesanDBEntities();

        // GET: /Cathedral/
        public ActionResult Index()
        {
            return View(db.Cathedrals.ToList());
        }

        // GET: /Cathedral/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cathedral cathedral = db.Cathedrals.Find(id);
            if (cathedral == null)
            {
                return HttpNotFound();
            }
            return View(cathedral);
        }

        // GET: /Cathedral/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Cathedral/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CathedralID,CathedralName,Founded,NationalAnthem,DiocesanAnthem,PapalAnthem")] Cathedral cathedral)
        {
            if (ModelState.IsValid)
            {
                db.Cathedrals.Add(cathedral);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cathedral);
        }

        // GET: /Cathedral/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cathedral cathedral = db.Cathedrals.Find(id);
            if (cathedral == null)
            {
                return HttpNotFound();
            }
            return View(cathedral);
        }

        // POST: /Cathedral/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CathedralID,CathedralName,Founded,NationalAnthem,DiocesanAnthem,PapalAnthem")] Cathedral cathedral)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cathedral).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cathedral);
        }

        // GET: /Cathedral/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cathedral cathedral = db.Cathedrals.Find(id);
            if (cathedral == null)
            {
                return HttpNotFound();
            }
            return View(cathedral);
        }

        // POST: /Cathedral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cathedral cathedral = db.Cathedrals.Find(id);
            db.Cathedrals.Remove(cathedral);
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
