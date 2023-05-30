using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FacilitatorSystem;

namespace FacilitatorSystem.Controllers
{

    public class StudentsTablesController : Controller
    {
        private StudentsEntities db = new StudentsEntities();

        // GET: StudentsTables
        public ActionResult Index()
        {
            return View(db.StudentsTables.ToList());
        }

        // GET: StudentsTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsTable studentsTable = db.StudentsTables.Find(id);
            if (studentsTable == null)
            {
                return HttpNotFound();
            }
            return View(studentsTable);
        }

        // GET: StudentsTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FirstName,LastName,Address_1,Address_2,EmailID")] StudentsTable studentsTable)
        {
            if (ModelState.IsValid)
            {
                db.StudentsTables.Add(studentsTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentsTable);
        }

        // GET: StudentsTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsTable studentsTable = db.StudentsTables.Find(id);
            if (studentsTable == null)
            {
                return HttpNotFound();
            }
            return View(studentsTable);
        }

        // POST: StudentsTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FirstName,LastName,Address_1,Address_2,EmailID")] StudentsTable studentsTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentsTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentsTable);
        }

        // GET: StudentsTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsTable studentsTable = db.StudentsTables.Find(id);
            if (studentsTable == null)
            {
                return HttpNotFound();
            }
            return View(studentsTable);
        }

        // POST: StudentsTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentsTable studentsTable = db.StudentsTables.Find(id);
            db.StudentsTables.Remove(studentsTable);
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
