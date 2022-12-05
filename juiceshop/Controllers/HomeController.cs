using summercamp.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace juiceshop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Home home = new Home();
            home.Participantes = Participante.GetAll();
            home.Instructores = Instructor.GetAll();
            home.Cursos = Curso.GetAll();

            return View(home);
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
    }
}