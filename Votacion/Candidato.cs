using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votacion
{
    public class Candidato
    {
        public string NombreCandidato { get; set; }
        public int NumeroCandidato { get; set; }

        public static Candidato CrearCandidato(int[] NumerosActuales)
        {
            Candidato candidato = new Candidato();
            Console.WriteLine("Ingrese el nombre del candidato:");
            candidato.NombreCandidato = Console.ReadLine();
            Console.WriteLine("Ingrese el numero del candidato:");
            string res = Console.ReadLine();
            int numero;
            string NumerosInscritos = "";
            foreach (var item in NumerosActuales)
            {
                NumerosInscritos += item.ToString();
                if (item != NumerosActuales.LastOrDefault())
                {
                    NumerosInscritos += ", ";
                }
            }
            while(!int.TryParse(res,out numero) || NumerosActuales.Contains(numero))
            {
                Console.WriteLine("Valor no reconocido.");
                Console.WriteLine($"Ingrese el numero del candidato, no puede ser uno que ya esté registrado. Números registrados: {NumerosInscritos}");
                res = Console.ReadLine();
            }
            candidato.NumeroCandidato = numero;
            return candidato;
        }
        public static Candidato EditarCandidato(Candidato candidato)
        {
            Console.WriteLine($"Ingrese el nombre del candidato. Actual: {candidato.NombreCandidato}");
            candidato.NombreCandidato = Console.ReadLine();
            Console.WriteLine($"Ingrese el numero del candidato. Actual: {candidato.NumeroCandidato}");
            string res = Console.ReadLine();
            int numero;
            while (!int.TryParse(res, out numero))
            {
                Console.WriteLine("Valor no reconocido.");
                Console.WriteLine("Ingrese el numero del candidato:");
                res = Console.ReadLine();
            }
            candidato.NumeroCandidato = numero;
            return candidato;
        }
    }
}
