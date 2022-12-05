using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summercamp.Core.Entidades
{
    public class Home
    {
        public IEnumerable<Participante> Participantes { get; set; }
        public IEnumerable<Instructor> Instructores { get; set; }
        public IEnumerable<Curso> Cursos { get; set; }
    }
}
