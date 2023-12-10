using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAsync
{
    internal class Asincrono
    {
        static async Task Main(string[] _)
        {

            Console.WriteLine("Ingrese la ruta de la carpeta que desea leer en Asincrono:");
            string ruta = Console.ReadLine();

            Stopwatch cronometro = new Stopwatch();

            cronometro.Start();

            string[] archivos = Directory.GetFiles(ruta);

            foreach (string archivo in archivos)
            {
                using (FileStream fs = File.Open(archivo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    byte[] buffer = new byte[fs.Length];

                    await fs.ReadAsync(buffer, 0, (int)fs.Length);

                    string contenido = Encoding.UTF8.GetString(buffer);

                    Console.WriteLine($"Archivo: {archivo}, Tamaño: {contenido.Length} bytes");
                }
            }

            cronometro.Stop();

            Console.WriteLine($"Tiempo: {cronometro.ElapsedMilliseconds} milisegundos");
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();

        }

    }
}
