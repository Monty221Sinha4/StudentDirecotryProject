using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Student__Direcotry_Project;

namespace Student__Direcotry_Project.Controllers
{
    public class UniversityListsController : Controller
    {
        private StudentDirectoryEntities db = new StudentDirectoryEntities();

        // GET: UniversityLists
        public ActionResult Index()
        {
            return View(db.UniversityLists.ToList());
        }

        // GET: UniversityLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversityList universityList = db.UniversityLists.Find(id);
            if (universityList == null)
            {
                return HttpNotFound();
            }
            return View(universityList);
        }

        // GET: UniversityLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniversityLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UniID,University")] UniversityList universityList)
        {
            if (ModelState.IsValid)
            {
                db.UniversityLists.Add(universityList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(universityList);
        }

        // GET: UniversityLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversityList universityList = db.UniversityLists.Find(id);
            if (universityList == null)
            {
                return HttpNotFound();
            }
            return View(universityList);
        }

        // POST: UniversityLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UniID,University")] UniversityList universityList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(universityList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(universityList);
        }

        // GET: UniversityLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversityList universityList = db.UniversityLists.Find(id);
            if (universityList == null)
            {
                return HttpNotFound();
            }
            return View(universityList);
        }

        // POST: UniversityLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UniversityList universityList = db.UniversityLists.Find(id);
            db.UniversityLists.Remove(universityList);
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
