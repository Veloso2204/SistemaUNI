using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni
{
    internal class Curso
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public List<Curso> PreRequisitos { get; set; } = new List<Curso>();

        public static List<Curso> ListarCursos()
        {
            return new List<Curso>();
        }
    }
}
