using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TallerConsola
{
    public class Asignatura
    {
        public Asignatura(string nombre, int creditos)
        {
            this.nombre = nombre;
            this.creditos = creditos;
            notas = new List<Nota>();
        }

        public string nombre { get; set; }
        public int creditos { get; set; }
        public List<Nota> notas { get; set; }

        public void AgregarNota(string nombreNota, double valorNota, double porcentajeNota)
        {
            double porcentajeTotal = 0;

            foreach (var nota in notas)
            {
                porcentajeTotal += nota.Porcentaje;
            }

            if (porcentajeTotal + porcentajeNota > 100)
            {
                Console.WriteLine("Error: El porcentaje total no puede ser mayor a 100%");
                return;
            }

            notas.Add(new Nota(nombreNota, valorNota, porcentajeNota));
        }

        public double CalcularPromedio()
        {
            double total = 0;
            double porcentajeTotal = 0;
            foreach (var nota in notas)
            {
                total += nota.Valor * (nota.Porcentaje / 100);
                porcentajeTotal += nota.Porcentaje;
            }

            return porcentajeTotal == 0 ? 0 : total / porcentajeTotal;

        }

        public double CalcularPromedioMinimo(double notaDeseada)
        {
            double totalPorcentaje = 0;

            foreach (var nota in notas)
            {
                totalPorcentaje += nota.Porcentaje;
            }

            double porcentajeRestante = 100 - totalPorcentaje;

            if (porcentajeRestante <= 0)
            {
                Console.WriteLine("Error: Ya se han completado todas las notas.");
                return 0;
            }

            double valorNecesario = (notaDeseada * 100 - CalcularPromedio() * totalPorcentaje) / porcentajeRestante;

            return valorNecesario;
        }
    }
}
