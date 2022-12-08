using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeDetails.Models;

namespace EmployeeDetails.Controllers
{
    public class EmployeeInfoesController : Controller
    {
        private EmployeeDataEntities db = new EmployeeDataEntities();

        // GET: EmployeeInfoes
        public ActionResult Index()
        {
            return View(db.tblEmployeeInfoes.ToList());
        }

        // GET: EmployeeInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployeeInfo tblEmployeeInfo = db.tblEmployeeInfoes.Find(id);
            if (tblEmployeeInfo == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployeeInfo);
        }

        // GET: EmployeeInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpId,EmpName,EmpContact,EmpAddress,EmpDept")] tblEmployeeInfo tblEmployeeInfo)
        {
            if (ModelState.IsValid)
            {
                db.tblEmployeeInfoes.Add(tblEmployeeInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblEmployeeInfo);
        }

        // GET: EmployeeInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployeeInfo tblEmployeeInfo = db.tblEmployeeInfoes.Find(id);
            if (tblEmployeeInfo == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployeeInfo);
        }

        // POST: EmployeeInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpId,EmpName,EmpContact,EmpAddress,EmpDept")] tblEmployeeInfo tblEmployeeInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmployeeInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblEmployeeInfo);
        }

        // GET: EmployeeInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployeeInfo tblEmployeeInfo = db.tblEmployeeInfoes.Find(id);
            if (tblEmployeeInfo == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployeeInfo);
        }

        // POST: EmployeeInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEmployeeInfo tblEmployeeInfo = db.tblEmployeeInfoes.Find(id);
            db.tblEmployeeInfoes.Remove(tblEmployeeInfo);
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
