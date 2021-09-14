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
    public class CountriesListsController : Controller
    {
        private StudentDirectoryEntities db = new StudentDirectoryEntities();

        // GET: CountriesLists
        public ActionResult Index()
        {
            return View(db.CountriesLists.ToList());
        }

        // GET: CountriesLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountriesList countriesList = db.CountriesLists.Find(id);
            if (countriesList == null)
            {
                return HttpNotFound();
            }
            return View(countriesList);
        }

        // GET: CountriesLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountriesLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "C_ID,Country")] CountriesList countriesList)
        {
            if (ModelState.IsValid)
            {
                db.CountriesLists.Add(countriesList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(countriesList);
        }

        // GET: CountriesLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountriesList countriesList = db.CountriesLists.Find(id);
            if (countriesList == null)
            {
                return HttpNotFound();
            }
            return View(countriesList);
        }

        // POST: CountriesLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "C_ID,Country")] CountriesList countriesList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countriesList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(countriesList);
        }

        // GET: CountriesLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountriesList countriesList = db.CountriesLists.Find(id);
            if (countriesList == null)
            {
                return HttpNotFound();
            }
            return View(countriesList);
        }

        // POST: CountriesLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CountriesList countriesList = db.CountriesLists.Find(id);
            db.CountriesLists.Remove(countriesList);
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
