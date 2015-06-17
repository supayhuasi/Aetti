using AETTI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AETTI.Controllers
{
    public class HomeController : Controller
    {
        private TestEntities1 db = new TestEntities1();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Confirmacion(int idPersona, int nroProyecto)
        {
            Persona persona = db.Persona.Find(idPersona);
            ViewBag.TextConfirmacion1 = "Se creo con éxito el proyecto para " + persona.RazonSocial.ToString();
            ViewBag.TextConfirmacion2 = "Su Numero de proyecto es el " + nroProyecto.ToString();

            return View();
        }
    }
}