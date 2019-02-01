using System;
using System.Collections.Generic;
using System.Text;

namespace CopaDosFilmes.Dominios
{
    public class CopaDosFilmes
    {
        public Final Final { get; set; }
        public Filme Campeao { get; set; }
        public Filme Vice => Final.Filmes[0].Id == Campeao.Id ? Final.Filmes[1] : Final.Filmes[0];
    }
}
