using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drones.Modelo
{
    [Serializable]
    public class Medicamentos
    {
        public Medicamentos(string v1, int v2, string v3, string v4)
        {
        }

        public string Nombre { get; set; }
        public int peso { get; set; }
        public string codigo { get; set; }
        public string imagen { get; set; }

     
    }
}
