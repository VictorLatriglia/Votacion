using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votacion
{
    public class VotoCandidato
    {
        public int NumeroCandidato { get;private set; }
        public int CantidadVotos { get; set; }

        public VotoCandidato(int NumeroCandidato)
        {
            this.NumeroCandidato = NumeroCandidato;
            CantidadVotos = 1;
        }
    }
}
