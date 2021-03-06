﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AETTI.Models;
using System.Configuration;
using AETTI.Util;


namespace AETTI.Controllers
{
    public class ProyectoesController : Controller
    {
        private TestEntities1 db = new TestEntities1();

        // GET: Proyectoes
        public ActionResult Index()
        {
            var proyecto = db.Proyecto.Include(p => p.Persona);
            return View(proyecto.ToList());
        }
        //public ActionResult Index(string apellido)
        //{
        //    var proyecto = db.Proyecto.Include(p => p.TipoProyecto);
        //    return View(proyecto.ToList());
        //}

        // GET: Proyectoes/Details/5
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
        public ActionResult Create(int? Id)
        {
            ViewBag.IdTipoProyecto = new SelectList(db.TipoProyecto, "Id", "Descripcion");
            //ViewBag.IdPersona = new SelectList(db.Persona, "Id", "RazonSocial",Id);
            var proyecto = new Proyecto();
            proyecto.IdPersona = Id;
            return View(proyecto);
        }

        // POST: Proyectoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Proyecto proyecto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    db.Proyecto.Add(proyecto);
                    db.SaveChanges();

                    Persona persona = db.Persona.Find(proyecto.IdPersona);

                    string textConfirmation = String.Format("Estimado/a {0}, su proyecto \"{1}\" se creo con éxito con el Numero {2}.", persona.RazonSocial, proyecto.TituloProyecto, proyecto.Id.ToString());

                    SendMails(persona, textConfirmation);

                    return RedirectToAction("Confirmacion", "Home", new { textConfirmation = textConfirmation });
                }
                catch (Exception ex)
                {

                }
            }

            ViewBag.IdTipoProyecto = new SelectList(db.TipoProyecto, "Id", "Descripcion", proyecto.IdTipoProyecto);
            ViewBag.IdPersona = new SelectList(db.Persona, "Id", "RazonSocial", proyecto.IdPersona);
            return View(proyecto);
        }

        private static void SendMails(Persona persona, string textConfirmation)
        {
            string to = persona.Email;
            string cco = ConfigurationManager.AppSettings["MailsOcultos"].ToString();
            string subject = "Creacion de Proyecto AETTI";
            string body = textConfirmation + "\r\rSaludos.\rAETTI";
            new SenderMail().Send(to, cco, subject, body);
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
          //  ViewBag.IdTipoProyecto = new SelectList(db.TipoProyecto, "Id", "Descripcion", proyecto.IdTipoProyecto);
            ViewBag.IdPersona = new SelectList(db.Persona, "Id", "RazonSocial", proyecto.IdPersona);
            return View(proyecto);
        }

        // POST: Proyectoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NroProyecto,TituloProyecto,TipoProyecto,Diagnostico,Producto,Resumen,Actividades,LinkYoutube,IdPersona")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
         //   ViewBag.IdTipoProyecto = new SelectList(db.TipoProyecto, "Id", "Descripcion", proyecto.IdTipoProyecto);
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
