using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AETTI.Models;
using AETTI.ViewModels;

namespace AETTI.Controllers
{
    public class BusquedaController : Controller
    {
        private AETTI.Models.TestEntities1 db = new TestEntities1();
        // GET: Busqueda
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(BusquedaViewModel busqueda)
        {
            var proyecto = db.Proyecto.Include(p=>p.Persona).          
            Where(x => x.NroProyecto == busqueda.NroProyecto || x.Persona.RazonSocial == busqueda.RazonSocial);
            return View("Busqueda",proyecto.ToList());
            
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // GET: Proyectoes/Create
        public ActionResult Create()
        {
           // ViewBag.IdTipoProyecto = new SelectList(db.TipoProyecto, "Id", "Descripcion");
            ViewBag.IdPersona = new SelectList(db.Persona, "Id", "RazonSocial");
            return View();
        }

        // POST: Proyectoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NroProyecto,TituloProyecto,IdTipoProyecto,Diagnostico,Producto,Resumen,Actividades,LinkYoutube,IdPersona")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Proyecto.Add(proyecto);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                }
            }

            //ViewBag.IdTipoProyecto = new SelectList(db.TipoProyecto, "Id", "Descripcion", proyecto.IdTipoProyecto);
            ViewBag.IdPersona = new SelectList(db.Persona, "Id", "RazonSocial", proyecto.IdPersona);
            return View(proyecto);
        }

        // GET: Proyectoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            //ViewBag.IdTipoProyecto = new SelectList(db.TipoProyecto, "Id", "Descripcion", proyecto.IdTipoProyecto);
            ViewBag.IdPersona = new SelectList(db.Persona, "Id", "RazonSocial", proyecto.IdPersona);
            return View(proyecto);
        }

        // POST: Proyectoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NroProyecto,TituloProyecto,IdTipoProyecto,Diagnostico,Producto,Resumen,Actividades,LinkYoutube,IdPersona")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          //  ViewBag.IdTipoProyecto = new SelectList(db.TipoProyecto, "Id", "Descripcion", proyecto.IdTipoProyecto);
            ViewBag.IdPersona = new SelectList(db.Persona, "Id", "RazonSocial", proyecto.IdPersona);
            return View(proyecto);
        }

        // GET: Proyectoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: Proyectoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proyecto proyecto = db.Proyecto.Find(id);
            db.Proyecto.Remove(proyecto);
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