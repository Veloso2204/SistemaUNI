using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni
{
    internal class Nota
    {
        public int ID { get; set; }
        public Aluno Aluno { get; set; }
        public Curso Curso { get; set; }
        public double Valor { get; set; }
    }
}
