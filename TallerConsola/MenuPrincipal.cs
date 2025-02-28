using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TallerConsola
{
    class MenuPrincipal
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a la Calculadora de Notas");

            List<Asignatura> asignaturas = new List<Asignatura>();

            while (true) 
            {
                Console.WriteLine("\n¿Que desea hacer?");
                Console.WriteLine("1. Agregar nueva asignatura");
                Console.WriteLine("2. Agregar notas a una asignatura");
                Console.WriteLine("3. Ver promedio acumulado de una asignatura");
                Console.WriteLine("4. Calcular el promedio minimo necesario para alcanzar una meta");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opcion: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese el nombre de la asignatura: ");
                        string nombreAsignatura = Console.ReadLine();
                        Console.WriteLine("Ingrese el numero de creditos de la asignatura: ");
                        int creditosAsignatura = int.Parse(Console.ReadLine());
                        asignaturas.Add(new Asignatura(nombreAsignatura, creditosAsignatura));
                        Console.WriteLine("Asignatura agregada exitosamente");
                        break;

                    case 2:

                        Console.WriteLine("Seleccione la asignatura a la que agregar notas: ");
                        for (int i = 0; i < asignaturas.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {asignaturas[i].nombre}");
                        }
                        int seleccion = int.Parse(Console.ReadLine()) - 1;
                        if(seleccion >= 0 && seleccion < asignaturas.Count)
                        {
                            Console.WriteLine("Ingrese el nombre de la nota: ");
                            string nombreNota = Console.ReadLine();
                            Console.WriteLine("Ingrese el valor de la nota: ");
                            double valorNota = double.Parse(Console.ReadLine());
                            Console.WriteLine("Ingrese el porcentaje de la nota: ");
                            double porcentajeNota = double.Parse(Console.ReadLine());
                            asignaturas[seleccion].AgregarNota(nombreNota, valorNota, porcentajeNota);
                            Console.WriteLine("Nota agregada exitosamente");
                        }
                        else
                        {
                            Console.WriteLine("Asignatura no encontrada");
                        }
                        break;

                    case 3:

                        Console.WriteLine("Seleccione la asignatura para ver el promedio acumulado");
                        for (int i = 0; i < asignaturas.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {asignaturas[i].nombre}");
                        }
                        int seleccion = int.Parse(Console.ReadLine()) - 1;
                        if (seleccion >= 0 && seleccion < asignaturas.Count)
                        {
                            Console.WriteLine($"El promedio acumulado de {asignaturas[seleccion].nombre} es: {asignaturas[seleccion].PromedioAcumulado}");
                        }
                        else
                        {
                            Console.WriteLine("Opcion invalida");
                        }
                        break;

                    case 4:

                        Console.WriteLine("Seleccione la asignatura para calcular el promedio necesario: ");
                        for (int i = 0; i < asignaturas.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {asignaturas[i].nombre}");
                        }
                        int seleccion = int.Parse(Console.ReadLine()) - 1;
                        if (seleccion >= 0 && seleccion < asignaturas.Count)
                        {
                            Console.WriteLine("Ingrese la nota deseada: ");
                            double notaDeseada = double.Parse(Console.ReadLine());
                            double promedioNecesario = asignaturas[seleccion].CalcularPromedioNecesario(notaDeseada);
                            if (promedioNecesario == -1)
                            {
                                Console.WriteLine("No se puede calcular el promedio necesario, porque el porcentaje restante es 0.");
                            } else
                            {
                                Console.WriteLine($"Promedio necesario en la siguiente evaluación: {promedioNecesario:F2}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Opcion invalida");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Gracias por usar la Calculadora de Notas");
                        return;

                    default:
                        Console.WriteLine("Opcion invalida");
                        break;
                }
            }
        }
    }
}
