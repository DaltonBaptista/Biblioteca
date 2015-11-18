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
    public class ClienteController : Controller
    {
        private biblioteca1Entities db = new biblioteca1Entities();

        // GET: Cliente
        public ActionResult Index()
        {
            var tbl_cliente = db.tbl_cliente.Include(t => t.tbl_distrito);
            return View(tbl_cliente.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_cliente tbl_cliente = db.tbl_cliente.Find(id);
            if (tbl_cliente == null)
            {
                return HttpNotFound();
            }
            return View(tbl_cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.id_distrito = new SelectList(db.tbl_distrito, "id_distrito", "descricao");
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cliente,nome,bi,nuit,morada,bairro,telf1,telf2,id_distrito")] tbl_cliente tbl_cliente)
        {
            if (ModelState.IsValid)
            {
                db.tbl_cliente.Add(tbl_cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_distrito = new SelectList(db.tbl_distrito, "id_distrito", "descricao", tbl_cliente.id_distrito);
            return View(tbl_cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_cliente tbl_cliente = db.tbl_cliente.Find(id);
            if (tbl_cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_distrito = new SelectList(db.tbl_distrito, "id_distrito", "descricao", tbl_cliente.id_distrito);
            return View(tbl_cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cliente,nome,bi,nuit,morada,bairro,telf1,telf2,id_distrito")] tbl_cliente tbl_cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_distrito = new SelectList(db.tbl_distrito, "id_distrito", "descricao", tbl_cliente.id_distrito);
            return View(tbl_cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_cliente tbl_cliente = db.tbl_cliente.Find(id);
            if (tbl_cliente == null)
            {
                return HttpNotFound();
            }
            return View(tbl_cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_cliente tbl_cliente = db.tbl_cliente.Find(id);
            db.tbl_cliente.Remove(tbl_cliente);
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
