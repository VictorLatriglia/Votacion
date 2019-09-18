using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Votacion
{
    public class Votacion
    {
        List<Comuna> Comunas = new List<Comuna>();
        List<Candidato> Candidatos = new List<Candidato>();
        public Votacion()
        {
            Comunas = Comuna.SeedComuna();
        }

        public void ComenzarVotacion()
        {
            if (Candidatos.Count > 1)
            {
                Console.WriteLine("Bienvenido al sistema de votacion...");
                Console.WriteLine("Las siguientes comunas son las registradas: ");
                foreach (var comuna in Comunas)
                {
                    Console.WriteLine($"{Comunas.IndexOf(comuna)}. {comuna.NombreComuna}.");
                }
                Console.WriteLine("Si su comuna no se encuentra registrada por favor comuniquese con el asesor");
                Console.WriteLine("Ingrese el número de su comuna");
                string res = Console.ReadLine();
                //Si se escribe el comando "salir" se dejarán de tomar votos, cerrando la votacion
                if (!res.Equals("salir"))
                {
                    int numero;
                    while (!int.TryParse(res, out numero) || (Comunas[numero] == null))
                    {
                        Console.WriteLine("Valor no reconocido.");
                        Console.WriteLine("Ingrese el numero de la comuna:");
                        res = Console.ReadLine();
                    }
                    Comuna comunaSeleccionada = Comunas[numero];
                    Console.WriteLine("Candidatos actuales:");
                    foreach (var candidato in Candidatos)
                    {
                        Console.WriteLine($"{candidato.NumeroCandidato}. {candidato.NombreCandidato}");
                    }
                    Console.WriteLine("Ingrese el numero del candidato por el cual desea votar:");
                    res = Console.ReadLine();
                    int numeroCandidato;
                    while (!int.TryParse(res, out numeroCandidato) && !Candidatos.Select(x => x.NumeroCandidato).Contains(numeroCandidato))
                    {
                        Console.WriteLine("Valor no reconocido.");
                        Console.WriteLine("Ingrese el numero del candidato:");
                        res = Console.ReadLine();
                    }
                    Candidato candidatoRegistrado = Candidatos.FirstOrDefault(x => x.NumeroCandidato == numeroCandidato);
                    if (comunaSeleccionada.Votos.FirstOrDefault(x => x.NumeroCandidato == numeroCandidato) is VotoCandidato votoCandidato)
                    {
                        votoCandidato.CantidadVotos += 1;
                    }
                    else
                    {
                        comunaSeleccionada.Votos.Add(new VotoCandidato(candidatoRegistrado.NumeroCandidato));
                    }
                    Console.WriteLine("Gracias por su voto, el sistema recibirá una nueva votacion en 5 segundos");
                    Thread.Sleep(5000);
                    Console.Clear();
                    ComenzarVotacion();
                }
                else
                {
                    TerminarVotacion();
                }
            }
            else
            {
                Console.WriteLine("No existen candidatos registrados, por favor registre mínimo 2");
                Thread.Sleep(2000);
                Console.Clear();
                RegistrarCandidatos();
            }
        }

        public void RegistrarCandidatos()
        {
            Console.WriteLine("Bienvenido al registro de candidatos.");
            Console.WriteLine($"Candidatos actuales: {Candidatos.Count}");
            foreach (var candidato in Candidatos)
            {
                Console.WriteLine($"{candidato.NumeroCandidato}. {candidato.NombreCandidato}");
            }
            Console.WriteLine("Que desea hacer?");
            Console.WriteLine("1. Agregar candidato");
            Console.WriteLine("2. Editar candidato");
            Console.WriteLine("3. Eliminar Candidato");
            Console.WriteLine("4. Salir");
            string res = Console.ReadLine();
            int opt = 0;
            while (!int.TryParse(res, out opt) || (opt != 1 && opt != 2 && opt != 3 && opt != 4))
            {
                Console.WriteLine("Accion no reconocida, ingrese una opcion adecuada: ");
                Console.WriteLine("Que desea hacer?");
                Console.WriteLine("1. Agregar candidato");
                Console.WriteLine("2. Editar candidato");
                Console.WriteLine("3. Eliminar Candidato");
                Console.WriteLine("4. Salir");
                res = Console.ReadLine();
            }
            bool Reiniciar = true;
            switch (opt)
            {
                case 1:
                    Candidatos.Add(Candidato.CrearCandidato(Candidatos.Select(x => x.NumeroCandidato).ToArray()));
                    Console.WriteLine("Candidato añadido correctamente");
                    break;
                case 2:
                    if (Candidatos.Count > 0)
                    {
                        Console.WriteLine("Ingrese el numero del candidato:");
                        res = Console.ReadLine();
                        int numero;
                        while (!int.TryParse(res, out numero) && !Candidatos.Select(x => x.NumeroCandidato).Contains(numero))
                        {
                            Console.WriteLine("Valor no reconocido.");
                            Console.WriteLine("Ingrese el numero del candidato:");
                            res = Console.ReadLine();
                        }
                        Candidato candidatoRegistrado = Candidatos.FirstOrDefault(x => x.NumeroCandidato == numero);
                        candidatoRegistrado = Candidato.EditarCandidato(candidatoRegistrado);
                        Console.WriteLine("Candidato editado correctamente");
                    }
                    else
                    {
                        Console.WriteLine("No se encontraron candidatos, será direccionado a crear uno.");
                        Candidatos.Add(Candidato.CrearCandidato(Candidatos.Select(x => x.NumeroCandidato).ToArray()));
                    }
                    break;
                case 3:
                    if (Candidatos.Count > 0)
                    {
                        Console.WriteLine("Ingrese el numero del candidato:");
                        res = Console.ReadLine();
                        int numero;
                        while (!int.TryParse(res, out numero) && !Candidatos.Select(x => x.NumeroCandidato).Contains(numero))
                        {
                            Console.WriteLine("Valor no reconocido.");
                            Console.WriteLine("Ingrese el numero del candidato:");
                            res = Console.ReadLine();
                        }
                        Candidato candidatoRegistrado = Candidatos.FirstOrDefault(x => x.NumeroCandidato == numero);
                        Console.WriteLine($"Escriba 'si' para borrar al candidato: ({candidatoRegistrado.NumeroCandidato}) {candidatoRegistrado.NombreCandidato}");
                        if (Console.ReadLine().Equals("si"))
                        {
                            Candidatos.Remove(candidatoRegistrado);
                            Console.WriteLine("Candidato eliminado correctamente");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontraron candidatos, será direccionado a crear uno.");
                        Candidatos.Add(Candidato.CrearCandidato(Candidatos.Select(x => x.NumeroCandidato).ToArray()));
                    }
                    break;
                case 4:
                    Reiniciar = false;
                    break;
            }
            if (Reiniciar)
            {
                Console.Clear();
                RegistrarCandidatos();
            }
        }

        private void TerminarVotacion()
        {
            Console.Clear();
            Console.WriteLine("La votacion ha terminado.");
            Console.WriteLine("Calculando resultados de la votacion...");
            List<VotoCandidato> ConteoTotal = new List<VotoCandidato>();
            foreach (var comuna in Comunas)
            {
                foreach (var voto in comuna.Votos)
                {
                    if (ConteoTotal.FirstOrDefault(x => x.NumeroCandidato == voto.NumeroCandidato) is VotoCandidato votoCandidato)
                    {
                        votoCandidato.CantidadVotos += voto.CantidadVotos;
                    }
                    else
                    {
                        ConteoTotal.Add(voto);
                    }
                }
            }
            Candidato CandidatoGanador = Candidatos.FirstOrDefault(x => x.NumeroCandidato == ConteoTotal.FirstOrDefault(y => y.CantidadVotos == ConteoTotal.Max(z => z.CantidadVotos)).NumeroCandidato);
            Console.WriteLine($"El ganador fué el candidato {CandidatoGanador.NombreCandidato} ({CandidatoGanador.NumeroCandidato}), con {ConteoTotal.FirstOrDefault(x => x.NumeroCandidato == CandidatoGanador.NumeroCandidato).CantidadVotos} votos");
            Console.WriteLine("El resultado general fué el siguiente: ");
            string CandidatosNombre = "\t";
            foreach (var Candidato in Candidatos)
            {
                CandidatosNombre += $"{Candidato.NombreCandidato}\t\t";
            }
            Console.WriteLine(CandidatosNombre);
            string resultadoComuna = "";
            foreach (var Comuna in Comunas)
            {
                resultadoComuna = Comuna.NombreComuna + "\t";
                foreach (var Candidato in Candidatos)
                {
                    resultadoComuna += $"{Comuna.Votos.FirstOrDefault(x => x.NumeroCandidato == Candidato.NumeroCandidato)?.CantidadVotos ?? 0}\t\t";
                }
                Console.WriteLine(resultadoComuna);
            }
            Console.WriteLine("Presione cualquier tecla para finalizar.");
            Console.WriteLine("ATENCION: LOS CANDIDATOS NO SERAN ELIMINADOS PERO LOS VOTOS SERÁN REESTABLECIDOS A CERO");
            foreach (var comuna in Comunas)
            {
                comuna.Votos = new List<VotoCandidato>();
            }
            Console.ReadKey();
        }
    }
}
