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
    public class Livros_requisitadosController : Controller
    {
        private biblioteca1Entities db = new biblioteca1Entities();

        // GET: Livros_requisitados
        public ActionResult Index()
        {
            var tbl_livros_requisitados = db.tbl_livros_requisitados.Include(t => t.tbl_cliente).Include(t => t.tbl_livro);
            return View(tbl_livros_requisitados.ToList());
        }

        // GET: Livros_requisitados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_livros_requisitados tbl_livros_requisitados = db.tbl_livros_requisitados.Find(id);
            if (tbl_livros_requisitados == null)
            {
                return HttpNotFound();
            }
            return View(tbl_livros_requisitados);
        }

        // GET: Livros_requisitados/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.tbl_cliente, "id_cliente", "nome");
            ViewBag.id_livro = new SelectList(db.tbl_livro, "id_livro", "autor");
            return View();
        }

        // POST: Livros_requisitados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_livros_requisitados,estado,observacao,id_cliente,id_livro")] tbl_livros_requisitados tbl_livros_requisitados)
        {
            if (ModelState.IsValid)
            {
                db.tbl_livros_requisitados.Add(tbl_livros_requisitados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.tbl_cliente, "id_cliente", "nome", tbl_livros_requisitados.id_cliente);
            ViewBag.id_livro = new SelectList(db.tbl_livro, "id_livro", "autor", tbl_livros_requisitados.id_livro);
            return View(tbl_livros_requisitados);
        }

        // GET: Livros_requisitados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_livros_requisitados tbl_livros_requisitados = db.tbl_livros_requisitados.Find(id);
            if (tbl_livros_requisitados == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.tbl_cliente, "id_cliente", "nome", tbl_livros_requisitados.id_cliente);
            ViewBag.id_livro = new SelectList(db.tbl_livro, "id_livro", "autor", tbl_livros_requisitados.id_livro);
            return View(tbl_livros_requisitados);
        }

        // POST: Livros_requisitados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_livros_requisitados,estado,observacao,id_cliente,id_livro")] tbl_livros_requisitados tbl_livros_requisitados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_livros_requisitados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.tbl_cliente, "id_cliente", "nome", tbl_livros_requisitados.id_cliente);
            ViewBag.id_livro = new SelectList(db.tbl_livro, "id_livro", "autor", tbl_livros_requisitados.id_livro);
            return View(tbl_livros_requisitados);
        }

        // GET: Livros_requisitados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_livros_requisitados tbl_livros_requisitados = db.tbl_livros_requisitados.Find(id);
            if (tbl_livros_requisitados == null)
            {
                return HttpNotFound();
            }
            return View(tbl_livros_requisitados);
        }

        // POST: Livros_requisitados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_livros_requisitados tbl_livros_requisitados = db.tbl_livros_requisitados.Find(id);
            db.tbl_livros_requisitados.Remove(tbl_livros_requisitados);
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
