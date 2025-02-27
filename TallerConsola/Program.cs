using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TallerConsola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
        }


        private List<string> Asignatura = new List<string>();
        private List<int> Creditos = new List<int>();

        private string asignatura;
        private int creditos;
        private void AgregarAsignatura()
        {
            Console.WriteLine("Digite por favor el nombre de la asignatura: ");
            asignatura = Console.ReadLine();
            Console.WriteLine("Digite por favor la cantidad de creditos del asignatura " + asignatura + ": ");
            creditos = int.Parse(Console.ReadLine());
            Asignatura.Add(asignatura);
            Creditos.Add(creditos);
        }

        private void CalcularPromedios()
        {

        }
          
    }
}

    
