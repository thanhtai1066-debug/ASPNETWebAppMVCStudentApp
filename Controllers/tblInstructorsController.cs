using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPNETWebAppMVCStudentApp;

namespace ASPNETWebAppMVCStudentApp.Controllers
{
    public class tblInstructorsController : Controller
    {
        private SchoolDBEntities db = new SchoolDBEntities();

        // GET: tblInstructors
        public ActionResult Index()
        {
            return View(db.tblInstructors.ToList());
        }

        // GET: tblInstructors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInstructor tblInstructor = db.tblInstructors.Find(id);
            if (tblInstructor == null)
            {
                return HttpNotFound();
            }
            return View(tblInstructor);
        }

        // GET: tblInstructors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblInstructors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstructorID,InstructorName,DepartmentID")] tblInstructor tblInstructor)
        {
            if (ModelState.IsValid)
            {
                db.tblInstructors.Add(tblInstructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblInstructor);
        }

        // GET: tblInstructors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInstructor tblInstructor = db.tblInstructors.Find(id);
            if (tblInstructor == null)
            {
                return HttpNotFound();
            }
            return View(tblInstructor);
        }

        // POST: tblInstructors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstructorID,InstructorName,DepartmentID")] tblInstructor tblInstructor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblInstructor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblInstructor);
        }

        // GET: tblInstructors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInstructor tblInstructor = db.tblInstructors.Find(id);
            if (tblInstructor == null)
            {
                return HttpNotFound();
            }
            return View(tblInstructor);
        }

        // POST: tblInstructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblInstructor tblInstructor = db.tblInstructors.Find(id);
            db.tblInstructors.Remove(tblInstructor);
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
