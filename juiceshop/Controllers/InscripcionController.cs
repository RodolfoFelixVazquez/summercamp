using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using summercamp.Core.Entidades;

namespace summercamp.Controllers
{
    public class InscripcionController : Controller
    {
        public ActionResult Index()
        {
            List<Inscripcion> Inscripcions = Inscripcion.GetAll();
            return View(Inscripcions);
        }
        public ActionResult Registro(int id)
        {
            InscripcionConParticpantesCursos inscripcion = new InscripcionConParticpantesCursos();
            inscripcion.Inscripcion = Inscripcion.GetById(id);
            inscripcion.Participantes = Participante.GetAll();
            inscripcion.Cursos = Curso.GetAll();
            
            return View(inscripcion);
        }
        public ActionResult Guardar(int id, int participante, int curso)
        {
            Inscripcion.Guardar(id, participante, curso);
            return RedirectToAction("Index");
        }
        public ActionResult Eliminar(int id)
        {
            Inscripcion Inscripcion = Inscripcion.GetById(id);

            Inscripcion.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}