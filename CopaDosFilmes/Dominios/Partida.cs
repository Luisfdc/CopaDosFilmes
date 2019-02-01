using System;
using System.Collections.Generic;
using System.Text;

namespace CopaDosFilmes.Dominios
{
    public class Partida
    {

        public Filme Jogar(Filme filmeUm, Filme filmeDois)
        {
            if (filmeUm.Nota > filmeDois.Nota)
                return filmeUm;
            else if (filmeUm.Nota < filmeDois.Nota)
                return filmeDois;
            else
                return string.Compare(filmeUm.Titulo, filmeDois.Titulo) < 0 ? filmeUm : filmeDois;
        }
    }
}
