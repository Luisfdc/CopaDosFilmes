using System;
using System.Collections.Generic;
using System.Text;

namespace CopaDosFilmes.Dominios
{
    public class Final : Fase<Filme>
    {
        public override Filme Iniciar()
        {
            return Jogar(Filmes[0], Filmes[1]);
        }
    }
}
