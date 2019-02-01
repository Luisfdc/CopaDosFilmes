using System;
using System.Collections.Generic;
using System.Linq;
using CopaDosFilmes.Aplicacao.Interface;
using CopaDosFilmes.Dominios;
using CopaDosFimes.Repositorio.Interface;


namespace CopaDosFilmes.Aplicacao
{
    public class CopaDosFilmesApl: ICopaDosFilmesApl
    {
        ICopaDosFilmesRepositorio _CopaDosFilmesRepositorio { get; }

        public CopaDosFilmesApl(ICopaDosFilmesRepositorio CopaDosFilmesRepositorio)
        {
            _CopaDosFilmesRepositorio = CopaDosFilmesRepositorio;
        }

        public IEnumerable<Filme> ListarFilmes()
        {
            return _CopaDosFilmesRepositorio.ListarFilmes();
        }

        public Dominios.CopaDosFilmes GerarMeuCampeonato(List<Filme> filmes)
        {
            if (filmes.Count != 8)
                throw new Exception("A quantidade de necessária de filmes para o campeonato é 8");

            var copa = new Dominios.CopaDosFilmes();

            var filmesOrdenados = filmes.OrderBy(x => x.Titulo);

            var primeiraFase = new PrimeiraFase
            {
                Filmes = filmesOrdenados.ToList()
            };

            var semiFinal = primeiraFase.Iniciar();

            copa.Final = semiFinal.Iniciar();

            copa.Campeao = copa.Final.Iniciar();

            return copa;


        }
    }
}
