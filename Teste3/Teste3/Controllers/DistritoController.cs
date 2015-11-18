using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Teste3;

namespace Teste3.Controllers
{
    public class DistritoController : Controller
    {
        private biblioteca1Entities db = new biblioteca1Entities();

        // GET: Distrito
        public ActionResult Index()
        {
            return View(db.tbl_distrito.ToList());
        }

        // GET: Distrito/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_distrito tbl_distrito = db.tbl_distrito.Find(id);
            if (tbl_distrito == null)
            {
                return HttpNotFound();
            }
            return View(tbl_distrito);
        }

        // GET: Distrito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Distrito/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_distrito,descricao")] tbl_distrito tbl_distrito)
        {
            if (ModelState.IsValid)
            {
                db.tbl_distrito.Add(tbl_distrito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_distrito);
        }

        // GET: Distrito/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_distrito tbl_distrito = db.tbl_distrito.Find(id);
            if (tbl_distrito == null)
            {
                return HttpNotFound();
            }
            return View(tbl_distrito);
        }

        // POST: Distrito/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_distrito,descricao")] tbl_distrito tbl_distrito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_distrito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_distrito);
        }

        // GET: Distrito/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_distrito tbl_distrito = db.tbl_distrito.Find(id);
            if (tbl_distrito == null)
            {
                return HttpNotFound();
            }
            return View(tbl_distrito);
        }

        // POST: Distrito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_distrito tbl_distrito = db.tbl_distrito.Find(id);
            db.tbl_distrito.Remove(tbl_distrito);
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
