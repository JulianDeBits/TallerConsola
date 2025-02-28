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
        public double PromedioAcumulado { get; private set; }

        public void AgregarNota(string nombre, double valor, double porcentaje)
        {
            double porcentajeTotal = 0;

            foreach (Nota nota in notas)
            {
                porcentajeTotal += nota.Porcentaje;
            }

            if (porcentajeTotal + porcentaje > 100)
            {
                Console.WriteLine("Erro: El porcentaje total de las notas no puede exceder el 100%");
                return;
            }

            notas.Add(new Nota(nombre, valor, porcentaje));
            CalcularPromedioAcumulado();
        }

        public void CalcularPromedioAcumulado()
        {
            double sumaPonderada = 0;
            double porcentajeTotal = 0;

            foreach (Nota nota in notas)
            {
                sumaPonderada += (nota.Valor * nota.Porcentaje) / 100;
                porcentajeTotal += nota.Porcentaje;
            }

            PromedioAcumulado = sumaPonderada / (porcentajeTotal / 100);
        }

        public double CalcularPromedioNecesario(double notaDeseada)
        {
            double sumaPonderada = 0;
            double porcentajeTotal = 0;

            foreach (Nota nota in notas)
            {
                sumaPonderada += (nota.Valor * nota.Porcentaje) / 100;
                porcentajeTotal += nota.Porcentaje;
            }

            double porcentajeRestante = 100 - porcentajeTotal;

            if(porcentajeRestante <= 0)
            {
                return -1;
            }

            double valorRestanteNecesario = (notaDeseada * 100) - sumaPonderada;
            return valorRestanteNecesario / porcentajeRestante * 100;
        }

    }
}
