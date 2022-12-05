using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using summercamp.Core.Entidades;

namespace summercamp.Controllers
{
    public class InstructorController : Controller
    {
        public ActionResult Index()
        {
            List<Instructor> Instructores = Instructor.GetAll();
            return View(Instructores);
        }
        public ActionResult Registro(int id)
        {
            Instructor instructor = Instructor.GetById(id);          
            return View(instructor);
        }
        public ActionResult Guardar(int id, string nombre, string telefono, string correo)
        {
            Instructor.Guardar(id, nombre, telefono, correo);
            return RedirectToAction("Index");
        }
        public ActionResult Eliminar(int id)
        {
           Instructor Instructor = Instructor.GetById(id);
           Instructor.Eliminar(id);
           return RedirectToAction("Index");
        }
    }
}