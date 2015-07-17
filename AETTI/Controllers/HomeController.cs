using AETTI.Models;
using AETTI.Util;
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

        public ActionResult Confirmacion(String textConfirmation)
        {
            ViewBag.TextConfirmacion = textConfirmation;

            return View();
        }
    }
}