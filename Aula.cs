using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni
{
    internal class Aula
    {
        public int ID { get; set; }
        public Curso Curso { get; set; }
        public Professor Professor { get; set; }
        public int Sala { get; set; }
        public int Horario { get; set; }
    }
}
