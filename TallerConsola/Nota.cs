using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerConsola
{
    public class Nota
    {
        public Nota (string nombre, double valor, double porcentaje)
        {
            Nombre = nombre;
            Valor = valor;
            Porcentaje = porcentaje;
        }

        public string Nombre { get; set; }
        public double Valor { get; set; }
        public double Porcentaje { get; set; }

    }
}
