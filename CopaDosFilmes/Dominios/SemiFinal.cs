using System;
using System.Collections.Generic;
using System.Text;

namespace CopaDosFilmes.Dominios
{
    public class SemiFinal : Fase<Final>
    {

        public override Final Iniciar()
        {
            var final = new Final
            {
                Filmes = new List<Filme>
                {
                    Jogar(Filmes[0], Filmes[1]),
                    Jogar(Filmes[2], Filmes[3])
                }
            };

            return final;
        }

    }
}
