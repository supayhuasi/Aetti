using AETTI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            Proyecto proyecto = db.Proyecto.Find(nroProyecto);

            string textConfirmation = String.Format("Estimado/a {0}, su proyecto \"{1}\" se creo con éxito con el Numero {2}.", persona.RazonSocial, proyecto.TituloProyecto, nroProyecto.ToString());
            ViewBag.TextConfirmacion = textConfirmation;

            SendMails(persona, textConfirmation);

            return View();
        }

        private static void SendMails(Persona persona, string textConfirmation)
        {
            string to = persona.Email + "," + ConfigurationManager.AppSettings["MailsOcultos"].ToString();
            string subject = "Creacion de Proyecto AETTI";
            string body = textConfirmation + "\r\rSaludos.\rAETTI";
            new SenderMail().Send(to, subject, body);
        }
    }
}