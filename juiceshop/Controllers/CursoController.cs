using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using summercamp.Core.Entidades;

namespace summercamp.Controllers
{
    public class CursoController : Controller
    {
        public ActionResult Index()
        {
            List<Curso> Cursos = Curso.GetAll();
            return View(Cursos);
        }
        public ActionResult Registro(int id)
        {
            CursoConInstructores curso = new CursoConInstructores();   
            curso.Curso = Curso.GetById(id);
            curso.Instructores = Instructor.GetAll();
            
            return View(curso);
        }
        public ActionResult Guardar(int id, string nombre, string horario, int instructor)
        {
            Curso.Guardar(id, nombre, horario, instructor);
            return RedirectToAction("Index");
        }
        public ActionResult Eliminar(int id)
        {
            Curso Curso = Curso.GetById(id);

            Curso.Eliminar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Participantes(int id) {
            List<Inscripcion> participantes = Curso.GetParticipantes(id);
            return View(participantes);

        }

      
    }
}