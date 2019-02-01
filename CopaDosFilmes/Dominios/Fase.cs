using System;
using System.Collections.Generic;
using System.Text;

namespace CopaDosFilmes.Dominios
{
    public abstract class Fase<T>: Partida
    {
        public List<Filme> Filmes { get; set; }

        public abstract T Iniciar();
    }
}
