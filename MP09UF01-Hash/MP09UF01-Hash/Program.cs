using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MP09UF01_Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            int menu = 1;
            String texto;
            while (menu != 0) {
                Console.WriteLine("Introduce 1 para crear el hash.");
                Console.WriteLine("Introduce 2 para comprobar la integridad");
                Console.WriteLine("Introduce 0 para salir.");
                menu = Convert.ToInt32(Console.ReadLine());

                if (menu == 1)
                {
                    String nombreArchivo=null;
                    Console.WriteLine("Entra el nombre del archivo: ");
                    
                    while (nombreArchivo == null)
                        nombreArchivo = Console.ReadLine();
                    texto = File.ReadAllText(@nombreArchivo);

                    String hash;
                    hash=calcularHash(texto);

                    Console.WriteLine("Introduce el nombre del archivo:");
                    String nombre = null;
                    while (nombre == null)
                        nombre = Console.ReadLine();

                    File.WriteAllText(nombre, hash);
                }
                else
                {
                    if (menu == 2)
                    {
                        String nombreArchivo = null;
                        Console.WriteLine("Entra el nombre del archivo: ");

                        while (nombreArchivo == null)
                            nombreArchivo = Console.ReadLine();
                        texto = File.ReadAllText(@nombreArchivo);

                        String hash;
                        String nombreHash=null;
                        String hashGuardado;
                        hash = calcularHash(texto);

                        Console.Write("Entra el nombre del hash: ");
                        while (nombreHash == null)
                            nombreHash = Console.ReadLine();

                        hashGuardado = File.ReadAllText(nombreHash);

                        if (hash == hashGuardado)
                        {
                            Console.WriteLine("Es Correcto");
                        }
                        else
                        {
                            Console.WriteLine("No es Correcto");
                        }
                    }
                }
            }
        }

        private static string calcularHash(string texto)
        {
            // Convertim l'string a un array de bytes
            byte[] bytesIn = UTF8Encoding.UTF8.GetBytes(texto);
            // Instanciar classe per fer hash
            SHA512Managed SHA512 = new SHA512Managed();
            // Calcular hash
            byte[] hashResult = SHA512.ComputeHash(bytesIn);

            // Si volem mostrar el hash per pantalla o guardar-lo en un arxiu de text
            // cal convertir-lo a un string

            String hash = BitConverter.ToString(hashResult, 0);  


            // Eliminem la classe instanciada
            SHA512.Dispose();
            return hash;
        }
    }
}
