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
    public class tblDepartmentsController : Controller
    {
        private SchoolDBEntities db = new SchoolDBEntities();

        // GET: tblDepartments
        public ActionResult Index()
        {
            return View(db.tblDepartments.ToList());
        }

        // GET: tblDepartments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDepartment tblDepartment = db.tblDepartments.Find(id);
            if (tblDepartment == null)
            {
                return HttpNotFound();
            }
            return View(tblDepartment);
        }

        // GET: tblDepartments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblDepartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentID,DepartmentName")] tblDepartment tblDepartment)
        {
            if (ModelState.IsValid)
            {
                db.tblDepartments.Add(tblDepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblDepartment);
        }

        // GET: tblDepartments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDepartment tblDepartment = db.tblDepartments.Find(id);
            if (tblDepartment == null)
            {
                return HttpNotFound();
            }
            return View(tblDepartment);
        }

        // POST: tblDepartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentID,DepartmentName")] tblDepartment tblDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblDepartment);
        }

        // GET: tblDepartments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDepartment tblDepartment = db.tblDepartments.Find(id);
            if (tblDepartment == null)
            {
                return HttpNotFound();
            }
            return View(tblDepartment);
        }

        // POST: tblDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDepartment tblDepartment = db.tblDepartments.Find(id);
            db.tblDepartments.Remove(tblDepartment);
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
