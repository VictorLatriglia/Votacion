using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Votacion votacion = new Votacion();

            Votacion(votacion);
            Console.WriteLine("Gracias por utilizar la aplicación, pulse cualquier tecla para finalizar");
            Console.ReadKey();
        }
        public static void Votacion(Votacion votacion)
        {
            Console.WriteLine("Bienvenido, que desea hacer?");
            Console.WriteLine("1. Comenzar votación");
            Console.WriteLine("2. Registrar candidatos");
            Console.WriteLine("3. Salir");
            string res = Console.ReadLine();
            int opt = 0;
            while (!int.TryParse(res, out opt) || (opt != 1 && opt != 2 && opt != 3))
            {
                Console.Clear();
                Console.WriteLine("Accion no reconocida, ingrese una opcion adecuada: ");
                Console.WriteLine("1. Comenzar votación");
                Console.WriteLine("2. Registrar candidatos");
                Console.WriteLine("3. Salir");
                res = Console.ReadLine();
            }
            bool Reiniciar = true;
            Console.Clear();
            switch (opt)
            {
                case 1:
                    votacion.ComenzarVotacion();
                    break;
                case 2:
                    votacion.RegistrarCandidatos();
                    break;
                case 3:
                    Reiniciar = false;
                    break;
            }
            if (Reiniciar)
            {
                Console.Clear();
                Votacion(votacion);
            }
        }
    }
}
