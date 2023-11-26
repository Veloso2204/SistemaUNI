using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni;

namespace Uni
{
    internal class Departamento
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public List<Professor> Professor { get; set; }
    }
}