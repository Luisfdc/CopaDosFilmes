
using CopaDosFilmes.Dominios;
using System.Collections.Generic;

namespace CopaDosFilmes.Aplicacao.Interface
{
    public interface ICopaDosFilmesApl
    {
        IEnumerable<Filme> ListarFilmes();
        Dominios.CopaDosFilmes GerarMeuCampeonato(List<Filme> filmes);
    }
}
