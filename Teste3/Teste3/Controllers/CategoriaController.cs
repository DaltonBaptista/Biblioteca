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
    public class CategoriaController : Controller
    {
        private biblioteca1Entities db = new biblioteca1Entities();

        // GET: Categoria
        public ActionResult Index()
        {
            return View(db.tbl_categoria.ToList());
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_categoria tbl_categoria = db.tbl_categoria.Find(id);
            if (tbl_categoria == null)
            {
                return HttpNotFound();
            }
            return View(tbl_categoria);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_categoria,descricao")] tbl_categoria tbl_categoria)
        {
            if (ModelState.IsValid)
            {
                db.tbl_categoria.Add(tbl_categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_categoria);
        }

        public ActionResult listar_categoria(int? id) {

            //tbl_categoria tbl_categori = db.tbl_categoria.Find(id);
             tbl_livro f = new tbl_livro();
            ViewBag.id = id;
           var resultado = db.tbl_livro.Where(x => x.id_livro == 1).ToList();
            return View(resultado);
        }

       


        // GET: Categoria/Edit//
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_categoria tbl_categoria = db.tbl_categoria.Find(id);
            if (tbl_categoria == null)
            {
                return HttpNotFound();
            }
            return View(tbl_categoria);
        }

        // POST: Categoria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_categoria,descricao")] tbl_categoria tbl_categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_categoria);
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_categoria tbl_categoria = db.tbl_categoria.Find(id);
            if (tbl_categoria == null)
            {
                return HttpNotFound();
            }
            return View(tbl_categoria);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_categoria tbl_categoria = db.tbl_categoria.Find(id);
            db.tbl_categoria.Remove(tbl_categoria);
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
