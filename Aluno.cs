using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni
{
    internal class Aluno
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public List<Nota> Notas { get; set; } = new List<Nota>();


        public void VisualizarNotas()
        {
            foreach (var nota in Notas)
            {
                Console.WriteLine($"Curso: {nota.Curso.Nome}, Nota: {nota.Valor}");
            }
        }
    }
}
