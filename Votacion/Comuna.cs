using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votacion
{
    public class Comuna
    {
        public string NombreComuna { get; set; }
        public List<VotoCandidato> Votos { get; set; }

        public Comuna()
        {
            Votos = new List<VotoCandidato>(); 
        }

        public static List<Comuna> SeedComuna()
        {
            return new List<Comuna>
            {
                new Comuna
                {
                    NombreComuna = "COM 1"
                },
                new Comuna
                {
                    NombreComuna = "COM 2"
                },
                new Comuna
                {
                    NombreComuna = "COM 3"
                },
                new Comuna
                {
                    NombreComuna = "COM 4"
                },
                new Comuna
                {
                    NombreComuna = "COM M"
                }
            };
        }
    }
}
