using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace ProyectoAsync
{
    internal class Paralelo
    {
        
        
            static void Main(string[] _)
            {

                Console.WriteLine("Ingrese la ruta de la carpeta que desea leer en Paralelo:");
                string ruta = Console.ReadLine();

                Stopwatch cronometro = new Stopwatch();

                cronometro.Start();

                string[] archivos = Directory.GetFiles(ruta);

                Parallel.ForEach(archivos, archivo =>
                {

                    string contenido = File.ReadAllText(archivo);

                    Console.WriteLine($"Archivo: {archivo}, Tamaño: {contenido.Length} bytes");
                });

                cronometro.Stop();
                Console.WriteLine($"Tiempo: {cronometro.ElapsedMilliseconds} milisegundos");
                Console.WriteLine("Presione cualquier tecla para salir...");
                Console.ReadKey();
            }
        }

    }

