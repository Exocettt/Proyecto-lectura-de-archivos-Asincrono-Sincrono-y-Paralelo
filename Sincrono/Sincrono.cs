using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAsync
{
    internal class Sincrono
    {
        static void Main(string[] _)
        {

            Console.WriteLine("Ingrese la ruta de la carpeta que desea leer en Sincrono:");
            string ruta = Console.ReadLine();

            Stopwatch cronometro = new Stopwatch();

            cronometro.Start();

            try
            {
                string[] archivos = Directory.GetFiles(ruta);

                foreach (string archivo in archivos)
                {

                    string contenido = File.ReadAllText(archivo);

                    Console.WriteLine("Archivo: {0}, Tamaño: {1} bytes", archivo, contenido.Length);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine($"Error: {e.Message}");
            }

            cronometro.Stop();

            double tiempo = cronometro.Elapsed.TotalSeconds;
            Console.WriteLine("Tiempo que tardo en leer los archivos: {0} segundos", tiempo);
        }
    }
}