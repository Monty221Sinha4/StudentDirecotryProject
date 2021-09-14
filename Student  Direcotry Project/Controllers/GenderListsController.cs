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
    public class GenderListsController : Controller
    {
        private StudentDirectoryEntities db = new StudentDirectoryEntities();

        // GET: GenderLists
        public ActionResult Index()
        {
            return View(db.GenderLists.ToList());
        }

        // GET: GenderLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenderList genderList = db.GenderLists.Find(id);
            if (genderList == null)
            {
                return HttpNotFound();
            }
            return View(genderList);
        }

        // GET: GenderLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenderLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Gen_ID,Gender")] GenderList genderList)
        {
            if (ModelState.IsValid)
            {
                db.GenderLists.Add(genderList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genderList);
        }

        // GET: GenderLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenderList genderList = db.GenderLists.Find(id);
            if (genderList == null)
            {
                return HttpNotFound();
            }
            return View(genderList);
        }

        // POST: GenderLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Gen_ID,Gender")] GenderList genderList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genderList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genderList);
        }

        // GET: GenderLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenderList genderList = db.GenderLists.Find(id);
            if (genderList == null)
            {
                return HttpNotFound();
            }
            return View(genderList);
        }

        // POST: GenderLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GenderList genderList = db.GenderLists.Find(id);
            db.GenderLists.Remove(genderList);
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
