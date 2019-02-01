using System;
using System.Collections.Generic;
using System.Text;

namespace CopaDosFilmes.Dominios
{
    public class PrimeiraFase : Fase<SemiFinal>
    {
        public override SemiFinal Iniciar()
        {
            var semiFinal = new SemiFinal
            {
                Filmes = new List<Filme>
                {
                    Jogar(Filmes[0], Filmes[7]),
                    Jogar(Filmes[1], Filmes[6]),
                    Jogar(Filmes[2], Filmes[5]),
                    Jogar(Filmes[3], Filmes[4])
                }
            };

            return semiFinal;
        }
    }
}
