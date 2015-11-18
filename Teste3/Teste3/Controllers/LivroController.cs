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
    public class LivroController : Controller
    {
        private biblioteca1Entities db = new biblioteca1Entities();

        // GET: Livro
        public ActionResult Index(string pesquisa = "")

        {
            var q = db.tbl_livro.ToList().AsQueryable();

            if (!string.IsNullOrEmpty(pesquisa))
            

                q = q.Where(c => c.autor.Contains(pesquisa));
                q = q.OrderBy(c => c.autor);
                var tbl_livro = db.tbl_livro.Include(t => t.tbl_categoria);
                return View(tbl_livro.ToList());

            

        }





        // GET: Livro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_livro tbl_livro = db.tbl_livro.Find(id);
            if (tbl_livro == null)
            {
                return HttpNotFound();
            }
            return View(tbl_livro);
        }


        public ActionResult listar_categoria(int? id)
        {

            //tbl_categoria tbl_categori = db.tbl_categoria.Find(id);
            tbl_livro f = new tbl_livro();
            ViewBag.id = id;
            var resultado = db.tbl_livro.Where(x => x.id_livro == 1).ToList();
            return View(resultado);
        }


        // GET: Livro/Create
        public ActionResult Create()
        {
            ViewBag.id_categoria = new SelectList(db.tbl_categoria, "id_categoria", "descricao");
            return View();
        }

        // POST: Livro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_livro,autor,autor_principal,titulo,editora,edicao,volume,id_categoria")] tbl_livro tbl_livro)
        {
            if (ModelState.IsValid)
            {
                db.tbl_livro.Add(tbl_livro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria = new SelectList(db.tbl_categoria, "id_categoria", "descricao", tbl_livro.id_categoria);
            return View(tbl_livro);
        }

        // GET: Livro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_livro tbl_livro = db.tbl_livro.Find(id);
            if (tbl_livro == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categoria = new SelectList(db.tbl_categoria, "id_categoria", "descricao", tbl_livro.id_categoria);
            return View(tbl_livro);
        }

        // POST: Livro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_livro,autor,autor_principal,titulo,editora,edicao,volume,id_categoria")] tbl_livro tbl_livro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_livro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_categoria = new SelectList(db.tbl_categoria, "id_categoria", "descricao", tbl_livro.id_categoria);
            return View(tbl_livro);
        }

        // GET: Livro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_livro tbl_livro = db.tbl_livro.Find(id);
            if (tbl_livro == null)
            {
                return HttpNotFound();
            }
            return View(tbl_livro);
        }

        // POST: Livro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_livro tbl_livro = db.tbl_livro.Find(id);
            db.tbl_livro.Remove(tbl_livro);
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
