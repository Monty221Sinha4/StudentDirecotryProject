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
    public class SutdentListsController : Controller
    {
        private StudentDirectoryEntities db = new StudentDirectoryEntities();

        // GET: SutdentLists
        public ActionResult Index()
        {
            var sutdentLists = db.SutdentLists.Include(s => s.CityList).Include(s => s.CountriesList).Include(s => s.GenderList).Include(s => s.Subject).Include(s => s.UniversityList);
            return View(sutdentLists.ToList());
        }

        // GET: SutdentLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SutdentList sutdentList = db.SutdentLists.Find(id);
            if (sutdentList == null)
            {
                return HttpNotFound();
            }
            return View(sutdentList);
        }

        // GET: SutdentLists/Create
        public ActionResult Create()
        {
            ViewBag.CtyID = new SelectList(db.CityLists, "Cty_ID", "City");
            ViewBag.C_ID = new SelectList(db.CountriesLists, "C_ID", "Country");
            ViewBag.Gen_ID = new SelectList(db.GenderLists, "Gen_ID", "Gender");
            ViewBag.SubID = new SelectList(db.Subjects, "Sub_ID", "Subject1");
            ViewBag.UniID = new SelectList(db.UniversityLists, "UniID", "University");
            return View();
        }

        // POST: SutdentLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Stud_ID,Firstname,Lastname,DateOfBirth,Gen_ID,UniID,SubID,CtyID,C_ID")] SutdentList sutdentList)
        {
            if (ModelState.IsValid)
            {
                db.SutdentLists.Add(sutdentList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CtyID = new SelectList(db.CityLists, "Cty_ID", "City", sutdentList.CtyID);
            ViewBag.C_ID = new SelectList(db.CountriesLists, "C_ID", "Country", sutdentList.C_ID);
            ViewBag.Gen_ID = new SelectList(db.GenderLists, "Gen_ID", "Gender", sutdentList.Gen_ID);
            ViewBag.SubID = new SelectList(db.Subjects, "Sub_ID", "Subject1", sutdentList.SubID);
            ViewBag.UniID = new SelectList(db.UniversityLists, "UniID", "University", sutdentList.UniID);
            return View(sutdentList);
        }

        // GET: SutdentLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SutdentList sutdentList = db.SutdentLists.Find(id);
            if (sutdentList == null)
            {
                return HttpNotFound();
            }
            ViewBag.CtyID = new SelectList(db.CityLists, "Cty_ID", "City", sutdentList.CtyID);
            ViewBag.C_ID = new SelectList(db.CountriesLists, "C_ID", "Country", sutdentList.C_ID);
            ViewBag.Gen_ID = new SelectList(db.GenderLists, "Gen_ID", "Gender", sutdentList.Gen_ID);
            ViewBag.SubID = new SelectList(db.Subjects, "Sub_ID", "Subject1", sutdentList.SubID);
            ViewBag.UniID = new SelectList(db.UniversityLists, "UniID", "University", sutdentList.UniID);
            return View(sutdentList);
        }

        // POST: SutdentLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Stud_ID,Firstname,Lastname,DateOfBirth,Gen_ID,UniID,SubID,CtyID,C_ID")] SutdentList sutdentList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sutdentList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CtyID = new SelectList(db.CityLists, "Cty_ID", "City", sutdentList.CtyID);
            ViewBag.C_ID = new SelectList(db.CountriesLists, "C_ID", "Country", sutdentList.C_ID);
            ViewBag.Gen_ID = new SelectList(db.GenderLists, "Gen_ID", "Gender", sutdentList.Gen_ID);
            ViewBag.SubID = new SelectList(db.Subjects, "Sub_ID", "Subject1", sutdentList.SubID);
            ViewBag.UniID = new SelectList(db.UniversityLists, "UniID", "University", sutdentList.UniID);
            return View(sutdentList);
        }

        // GET: SutdentLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SutdentList sutdentList = db.SutdentLists.Find(id);
            if (sutdentList == null)
            {
                return HttpNotFound();
            }
            return View(sutdentList);
        }

        // POST: SutdentLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SutdentList sutdentList = db.SutdentLists.Find(id);
            db.SutdentLists.Remove(sutdentList);
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
