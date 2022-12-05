using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using summercamp.Core.Entidades;

namespace summercamp.Controllers
{
    public class ParticipanteController : Controller
    {
        public ActionResult Index()
        {
            List<Participante> Participantees = Participante.GetAll();
            return View(Participantees);
        }
        public ActionResult Registro(int id)
        {
            Participante Participante = Participante.GetById(id);          
            return View(Participante);
        }
        public ActionResult Guardar(int id, string nombre, string telefono, string correo)
        {
            Participante.Guardar(id, nombre, telefono, correo);
            return RedirectToAction("Index");
        }
        public ActionResult Eliminar(int id)
        {
           Participante Participante = Participante.GetById(id);
           Participante.Eliminar(id);
           return RedirectToAction("Index");
        }
    }
}