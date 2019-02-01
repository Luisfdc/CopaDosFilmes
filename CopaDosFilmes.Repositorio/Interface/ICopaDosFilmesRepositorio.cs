using CopaDosFilmes.Dominios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CopaDosFimes.Repositorio.Interface
{
    public interface ICopaDosFilmesRepositorio
    {
        IEnumerable<Filme> ListarFilmes();
    }
}
