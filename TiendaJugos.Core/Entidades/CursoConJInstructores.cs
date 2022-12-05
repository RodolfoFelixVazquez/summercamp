using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summercamp.Core.Entidades
{
    public class CursoConInstructores
    {
        public Curso Curso { get; set; }

        public IEnumerable<Instructor> Instructores { get; set; }
    }
}
