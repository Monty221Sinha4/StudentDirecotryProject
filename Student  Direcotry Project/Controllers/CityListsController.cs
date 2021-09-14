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
    public class CityListsController : Controller
    {
        private StudentDirectoryEntities db = new StudentDirectoryEntities();

        // GET: CityLists
        public ActionResult Index()
        {
            return View(db.CityLists.ToList());
        }

        // GET: CityLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityList cityList = db.CityLists.Find(id);
            if (cityList == null)
            {
                return HttpNotFound();
            }
            return View(cityList);
        }

        // GET: CityLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CityLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cty_ID,City")] CityList cityList)
        {
            if (ModelState.IsValid)
            {
                db.CityLists.Add(cityList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cityList);
        }

        // GET: CityLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityList cityList = db.CityLists.Find(id);
            if (cityList == null)
            {
                return HttpNotFound();
            }
            return View(cityList);
        }

        // POST: CityLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cty_ID,City")] CityList cityList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cityList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cityList);
        }

        // GET: CityLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityList cityList = db.CityLists.Find(id);
            if (cityList == null)
            {
                return HttpNotFound();
            }
            return View(cityList);
        }

        // POST: CityLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CityList cityList = db.CityLists.Find(id);
            db.CityLists.Remove(cityList);
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
