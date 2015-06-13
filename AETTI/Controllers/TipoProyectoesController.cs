using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AETTI.Models;

namespace AETTI.Controllers
{
    public class TipoProyectoesController : Controller
    {
        private TestEntities1 db = new TestEntities1();

        // GET: TipoProyectoes
        public ActionResult Index()
        {
            return View(db.TipoProyecto.ToList());
        }

        // GET: TipoProyectoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProyecto tipoProyecto = db.TipoProyecto.Find(id);
            if (tipoProyecto == null)
            {
                return HttpNotFound();
            }
            return View(tipoProyecto);
        }

        // GET: TipoProyectoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoProyectoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Descripcion")] TipoProyecto tipoProyecto)
        {
            if (ModelState.IsValid)
            {
                db.TipoProyecto.Add(tipoProyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoProyecto);
        }

        // GET: TipoProyectoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProyecto tipoProyecto = db.TipoProyecto.Find(id);
            if (tipoProyecto == null)
            {
                return HttpNotFound();
            }
            return View(tipoProyecto);
        }

        // POST: TipoProyectoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Descripcion")] TipoProyecto tipoProyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoProyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoProyecto);
        }

        // GET: TipoProyectoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProyecto tipoProyecto = db.TipoProyecto.Find(id);
            if (tipoProyecto == null)
            {
                return HttpNotFound();
            }
            return View(tipoProyecto);
        }

        // POST: TipoProyectoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoProyecto tipoProyecto = db.TipoProyecto.Find(id);
            db.TipoProyecto.Remove(tipoProyecto);
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
